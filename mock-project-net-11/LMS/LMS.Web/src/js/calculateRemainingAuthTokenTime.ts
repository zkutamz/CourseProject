/**
 * Calculate the remaining time of an authentication token.
 * Return the remaining time in millisecond.
 */
const CalculateRemainingAuthTokenTime = (expirationTime: string): number => {
    const currentTime = new Date().getTime();

    const currentExpirationTime = new Date(expirationTime).getTime();

    return currentExpirationTime - currentTime;
};

export default CalculateRemainingAuthTokenTime;