import React, { useEffect, useState } from 'react'
import authApi from '../../api/authAPI';
import queryString from 'query-string';
import { Link, useHistory } from 'react-router-dom';

export default function VerifyEmail() {
    const [emailStatus, setEmailStatus] = useState('Verifying');
    const history = useHistory();
    useEffect(() => {
        const { token } = queryString.parse(window.location.search);

        history.replace(window.location.pathname);

        verifyEmail(token);

    });

    const verifyEmail = async (token) => {
        let res = await authApi.verify(token);
        if (res.status === 200) {
            setEmailStatus('Success');
            setTimeout(() => {
                history.replace('/sign-in');
            }, 1000);
        }
        else {
            setEmailStatus('Failed');
        }
    }

    const getBody = () => {
        switch (emailStatus) {
            case 'Verifying':
                return <div>Verifying...</div>;
            case 'Success':
                return <div>Verify success</div>;
            case 'Failed':
                return <div>Verification failed, you can also verify your account using the <Link to="forgot-password">forgot password</Link> page.</div>;
        }
    }

    return (
        <div className="sign_form">
            <h2>Verify Email</h2>
            <div>{getBody()}</div>
        </div>
    )
}
