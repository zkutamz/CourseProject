import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { IconButton, InputAdornment, TextField } from "@mui/material";
import CircularProgress from '@mui/material/CircularProgress';
import { useFormik } from 'formik';
import React, { useContext, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import * as yup from 'yup';
import authApi from '../../api/authAPI';
import AuthContext from '../../store/auth-context';
import MuiSnackBar from '../SnackBars/MuiSnackBar';

const validationSchema = yup.object({
    email: yup
        .string('Enter your email')
        .email('Email is invalid')
        .required('Email is required'),
    password: yup
        .string('Enter your password')
        .min(6, 'Password should be of minimum 6 characters length')
        .matches(/^(?=.*[a-z])/, 'Should have at least one lower case')
        .matches(/(?=.*[A-Z])/, 'Should have at least one upper case')
        .matches(/(?=.*\d)/, 'Should have at least one number')
        .matches(/(?=.*[#$^+=!*()@%&])/, 'Should have at least one special character')
        .required('Password is required')
        
});

export default function SignIn() {
    const [message, setMessage] = useState('');
    const [success, setSuccess] = useState(false);
    const [error, setError] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const history = useHistory();
    const authContext = useContext(AuthContext);
    const [showPassword, setShowPassword] = useState(false);

    const formik = useFormik({
        initialValues: {
            email: 'admin@mail.com',
            password: 'Abc@123'
        },
        validationSchema: validationSchema,
        onSubmit: async (values) => {
            values = { ...values, remember: true }
            setIsSubmitting(true);
            try {
                let res = await authApi.signIn(values);

                const data = res.data;

                if (data.statusCode === 201) {
                    setMessage("Login success");

                    await authContext.login(data.data.token, data.data.expires, data.data.user, data.data.roles);
                }
                else {
                    setMessage("Login failed");
                    setError(true);
                    setIsSubmitting(false);
                }

                history.replace('/');
            } catch (error) {
                if (error.response.data.statusCode === 404 || error.response.data.statusCode === 400) {
                    setMessage(error.response.data.message);
                }
                else {
                    setMessage("Something went wrong!");
                }
                setSuccess(false);
                setError(true);
                setIsSubmitting(false);
            }
        },
    });

    const handleClickShowPassword = () => setShowPassword(!showPassword);
    const handleMouseDownPassword = () => setShowPassword(!showPassword);

    return (
        <div className="sign_form" >
            <h2>Welcome to Cursus</h2>
            <p>Log In to Your Edututs+ Account!</p>
            <form onSubmit={formik.handleSubmit}>
                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh95">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            name="email"
                            label="Email"
                            value={formik.values.email}
                            onChange={formik.handleChange}
                            error={formik.touched.email && Boolean(formik.errors.email)}
                            helperText={formik.touched.email && formik.errors.email}
                        />
                    </div>
                </div>
                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh95">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            type={showPassword ? "text" : "password"}
                            name="password"
                            label="Password"
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
                <button
                    className={isSubmitting ? "login-btn disabled" : "login-btn"}
                    type='submit'
                    style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                >
                    <span style={{ marginRight: '8px' }}>Sign In</span>
                    {isSubmitting && <CircularProgress mr={'15px'} size={16} color='inherit' />}
                </button>
            </form>
            <p className="sgntrm145">Or <Link to="forgot-password">Forgot Password</Link>.</p>
            <p className="mb-0 mt-30 hvsng145">Don't have an account? <Link to={"/sign-up"}>Sign Up</Link></p>
            <MuiSnackBar open={success} severity="success" message={message} onClose={() => { setSuccess(false) }} />
            <MuiSnackBar open={error} severity="error" message={message} onClose={() => { setError(false) }} />
        </div>
    );
}
