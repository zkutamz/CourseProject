import React, { useCallback, useEffect, useState } from 'react';
import authApi from '../api/authAPI';

let logoutTimer: any;

type AuthContextObject = {
    token: string | null,
    isLoggedIn: boolean,
    role: string | null,
    userId: number | null,
    email: string | null,
    fullName: string | null,
    login: (token: string, expiration: string, user: any, role: string) => void,
    logout: () => void
};

const AuthContext = React.createContext<AuthContextObject>({
    token: '',
    isLoggedIn: false,
    role: '',
    userId: 0,
    email: '',
    fullName: '',
    login: (token: string, expiration: string, user: any, role: string) => { },
    logout: () => { }
});

/**
 * Helper function to calculate the remaining time of a token
 */
const calculateRemainingTime = (expirationTime: string): number => {
    const currentTime = new Date().getTime();

    const adjustedExpirationTime = new Date(expirationTime).getTime();

    const remainingDuration = adjustedExpirationTime - currentTime;

    return remainingDuration;
}

/**
 * Get a refreshed token from the API if the remaining time passed in
 * is less than 10 mins and more than 1 min.
 */
const getRefreshToken = async (remainingTime: number): Promise<{
    token: string,
    expiration: string
} | null> => {
    if (remainingTime > 60000 && remainingTime <= 600000) {
        const response = await authApi.refreshTokenAsync();

        if (response.data.statusCode === 201) {
            var data = response.data.data;

            return {
                token: data.token,
                expiration: data.expires
            }
        }
    }

    return null;
}

/**
 * Get the token and its expiration time in the local storage.
 * Check if there is still enough time left. Else remove both token and time.
 * If ok, return both of the stored values
 */
const retrieveStoredToken = async (): Promise<{
    token: string,
    role: string,
    userId: number,
    email: string,
    fullName: string,
    duration: number
} | null> => {
    let storedToken: string | null = localStorage.getItem('token');
    let expiration: string = localStorage.getItem('expiration')!;
    const role: string | null = localStorage.getItem('role');
    const userId: number | null = parseInt(localStorage.getItem('userID')!);
    const email: string | null = localStorage.getItem('email');
    const fullName: string | null = localStorage.getItem('fullName');

    // get exp time
    const remainingTime = calculateRemainingTime(expiration);

    // If the remain time is more than 1 min and less than 10 min
    // Send a request for a refresh token and replace the existing token

    let newToken = await getRefreshToken(remainingTime);

    if (newToken) {
        storedToken = newToken.token;
        localStorage.setItem('token', storedToken);
        localStorage.setItem('expiration', newToken.expiration);
    };

    // If the remaining time is less than 1 min
    // Remove the user's info from the local storage
    if (remainingTime <= 60000) {
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        localStorage.removeItem('expiration');
        localStorage.removeItem('email');
        localStorage.removeItem('userID');
        localStorage.removeItem('fullName');

        return null;
    }
    // if remaining time < some millisecond. Send a get refresh token request.

    return {
        token: storedToken!,
        role: role!,
        userId: userId,
        email: email!,
        fullName: fullName!,
        duration: remainingTime
    }
};

export const AuthContextProvider: React.FC = (props) => {
    const [token, setToken] = useState<string | null>(null);
    const [userId, setUserId] = useState<number | null>(null);
    const [email, setEmail] = useState<string | null>(null);
    const [fullName, setFullName] = useState<string | null>(null);
    const [role, setRole] = useState<string | null>(null);
    const [shouldRefresh, setShouldRefresh] = useState<boolean>(false);

    let tokenData: any;

    const refreshCurrentToken = useCallback(() => {
        if (logoutTimer) {
            clearTimeout(logoutTimer);
        }

        setShouldRefresh(prev => !prev);
    }, []);

    useEffect(() => {
        const fetchTokenData = async () => {
            tokenData = await retrieveStoredToken();
            if (tokenData) {
                setToken(tokenData.token);
                setUserId(tokenData.userId);
                setEmail(tokenData.email);
                setFullName(tokenData.fullName);
                setRole(tokenData.role);

                logoutTimer = setTimeout(refreshCurrentToken, tokenData.duration - 120000);
            }
        }

        fetchTokenData();
    }, [shouldRefresh]);

    /**
     * Same as if checks token !== null.
     */
    const userIsLoggedIn: boolean = !!token;

    const logOutHandler = () => {
        setToken(null);

        localStorage.removeItem('token');
        localStorage.removeItem('expiration');
        localStorage.removeItem('role');
        localStorage.removeItem('userID');
        localStorage.removeItem('fullName');
        localStorage.removeItem('email');
    };

    const logInHandler = async (token: string, expiration: string, user: any, role: string) => {
        await setUserInfo(user);
        setToken(token);
        setRole(role);

        localStorage.setItem('token', token);
        localStorage.setItem('role', role);
        localStorage.setItem('expiration', expiration.toString());

        const remainingTime = calculateRemainingTime(expiration);
        logoutTimer = setTimeout(refreshCurrentToken, remainingTime - 120000);
    }

    /**
     * Save the user's info (id, email, fullName) into states and localStorage.
     */
    const setUserInfo = async (user: any) => {
        setUserId(user.id);
        setEmail(user.email);

        const newFullName: string = user.firstName + user.lastName

        setFullName(newFullName);

        localStorage.setItem('userID', user.id.toString());
        localStorage.setItem('email', user.email);
        localStorage.setItem('fullName', newFullName);
    };

    const authContext = {
        token: token,
        isLoggedIn: userIsLoggedIn,
        role: role,
        userId: userId,
        email: email,
        fullName: fullName,
        login: logInHandler,
        logout: logOutHandler
    }

    return (
        <AuthContext.Provider value={authContext}>
            {props.children}
        </AuthContext.Provider>
    )
}

export default AuthContext;