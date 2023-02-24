
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { CircularProgress, IconButton, InputAdornment, TextField } from "@mui/material";
import { useFormik } from 'formik';
import queryString from 'query-string';
import React, { useContext, useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import * as yup from 'yup';
import authApi from '../../api/authAPI';
import AuthContext from '../../store/auth-context';
import MuiSnackBar from '../SnackBars/MuiSnackBar';


const validationSchema = yup.object({
    password: yup
        .string('Enter your password')
        .min(6, 'Password should be of minimum 6 characters length')
        .matches(/^(?=.*[a-z])/, 'Should have at least one lower case')
        .matches(/(?=.*[A-Z])/, 'Should have at least one upper case')
        .matches(/(?=.*\d)/, 'Should have at least one number')
        .matches(/(?=.*[#$^+=!*()@%&])/, 'Should have at least one special character')
        .required('Password is required'),
    confirmPassword: yup
        .string('Enter your confirm password')
        .min(6, 'Password should be of minimum 6 characters length')
        .oneOf([yup.ref('password'), null], 'Confirm password is not match')
        .matches(/^(?=.*[a-z])/, 'Should have at least one lower case')
        .matches(/(?=.*[A-Z])/, 'Should have at least one upper case')
        .matches(/(?=.*\d)/, 'Should have at least one number')
        .matches(/(?=.*[#$^+=!*()@%&])/, 'Should have at least one special character')
        .required('Confirm password is required'),
});

export default function ResetPassword() {
    const [message, setMessage] = useState('');
    const [success, setSuccess] = useState(false);
    const [error, setError] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const history = useHistory();
    const authContext = useContext(AuthContext);
    const [tokenReset, setTokenReset] = useState('');
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);

    useEffect(() => {
        const { token } = queryString.parse(window.location.search);
        setTokenReset(token);

    }, []);

    const formik = useFormik({
        initialValues: {
            password: '',
            confirmPassword: ''
        },
        validationSchema: validationSchema,
        onSubmit: (values) => {
            values = { tokenReset, ...values };
            setIsSubmitting(true);
            resetPassword(values);
        },
    });

    const resetPassword = async (values) => {
        try {
            let res = await authApi.resetPassword(values);
            if (res.data.statusCode === 201) {
                setMessage("Reset password successfully");
                setSuccess(true);
                setTimeout(() => {
                    history.replace('/sign-in');
                }, 2000);
            } else {
                setMessage("Reset password failed");
                setError(true);
                setIsSubmitting(false);
            }
        } catch (error) {
            setMessage("Something went wrong!");
            setError(true);
            setIsSubmitting(false);
        }
    }

    const handleClickShowPassword = () => setShowPassword(!showPassword);
    const handleMouseDownPassword = () => setShowPassword(!showPassword);

    const handleClickShowConfirmPassword = () => setShowConfirmPassword(!showConfirmPassword);
    const handleMouseDownConfirmPassword = () => setShowConfirmPassword(!showConfirmPassword);

    return (
        <div className="sign_form" >
            <h2>Reset password</h2>
            <form onSubmit={formik.handleSubmit}>
                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh95">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            type={showPassword ? "text" : "password"}
                            name="password"
                            label="New Password"
                            value={formik.values.password}
                            onChange={formik.handleChange}
                            error={formik.touched.password && Boolean(formik.errors.password)}
                            helperText={formik.touched.password && formik.errors.password}
                            InputProps={{ // <-- This is where the toggle button is added.
                                endAdornment: (
                                    <InputAdornment position="end">
                                        <IconButton
                                            aria-label="toggle password visibility"
                                            onClick={handleClickShowPassword}
                                            onMouseDown={handleMouseDownPassword}
                                        >
                                            {showPassword ? <Visibility /> : <VisibilityOff />}
                                        </IconButton>
                                    </InputAdornment>
                                )
                            }}
                        />
                    </div>
                </div>
                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh95">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            type={showConfirmPassword ? "text" : "password"}
                            name="confirmPassword"
                            label="Confirm new password"
                            value={formik.values.confirmPassword}
                            onChange={formik.handleChange}
                            error={formik.touched.confirmPassword && Boolean(formik.errors.confirmPassword)}
                            helperText={formik.touched.confirmPassword && formik.errors.confirmPassword}
                            InputProps={{ // <-- This is where the toggle button is added.
                                endAdornment: (
                                    <InputAdornment position="end">
                                        <IconButton
                                            aria-label="toggle password visibility"
                                            onClick={handleClickShowConfirmPassword}
                                            onMouseDown={handleMouseDownConfirmPassword}
                                        >
                                            {showConfirmPassword ? <Visibility /> : <VisibilityOff />}
                                        </IconButton>
                                    </InputAdornment>
                                )
                            }}
                        />
                    </div>
                </div>
                <button
                    className={isSubmitting ? "login-btn disabled" : "login-btn"}
                    type='submit'
                    style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                >
                    <span style={{ marginRight: '8px' }}>Submit</span>
                    {isSubmitting && <CircularProgress mr={'15px'} size={16} color='inherit' />}
                </button>
            </form>
            <MuiSnackBar open={success} severity="success" message={message} onClose={() => { setSuccess(false) }} />
            <MuiSnackBar open={error} severity="error" message={message} onClose={() => { setError(false) }} />
        </div>
    );
}
