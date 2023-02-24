import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { CircularProgress, FormControlLabel, IconButton, InputAdornment } from "@mui/material";
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import TextField from '@mui/material/TextField';
import { useFormik } from 'formik';
import { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import * as yup from 'yup';
import authApi from '../../api/authAPI';
import MuiSnackBar from '../SnackBars/MuiSnackBar';


const validationSchema = yup.object({
    firstName: yup.string('Enter your first name').required('First name is required'),
    lastName: yup.string('Enter your last name').required('Last name is required'),
    email: yup.string('Enter your email').email('Email is invalid').required('Email is required'),
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
        .required('Password is required'),
    description: yup
        .string('Enter your confirm description')
        .min(10, 'Description should be of minimum 10 characters length')
        .required('Description is required'),
});
export default function SignUp() {
    const [message, setMessage] = useState('');
    const [success, setSuccess] = useState(false);
    const [error, setError] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const history = useHistory();
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);


    const formik = useFormik({
        initialValues: {
            firstName: 'client',
            lastName: 'customer',
            email: 'client@mail.com',
            password: 'Abc@123',
            confirmPassword: 'Abc@123',
            description: 'Hello i am a client',
            type: 'STUDENT',
        },
        validationSchema: validationSchema,
        onSubmit: async (values) => {
            values = { ...values, remember: true }
            setIsSubmitting(true);
            try {
                var res = await authApi.signUp(values);
                if (res.data.statusCode === 201) {
                    setMessage(res.data.message);
                    setSuccess(true);
                    setError(false);

                    setTimeout(() => {
                        history.replace('check-mail');
                    }, 2000);
                } else {
                    setMessage(res.data.message);
                    setSuccess(false);
                    setError(true);
                    setIsSubmitting(false);
                }
            } catch (error) {

                if (error.response.data.statusCode === 400) {
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

    const handleClickShowConfirmPassword = () => setShowConfirmPassword(!showConfirmPassword);
    const handleMouseDownConfirmPassword = () => setShowConfirmPassword(!showConfirmPassword);

    return (
        <div className="sign_form">
            <h2>Welcome to Cursus</h2>
            <p>Sign Up and Start Learning!</p>
            <form onSubmit={formik.handleSubmit}>
                <div className="ui search focus">
                    <div className="ui left icon input swdh11 swdh19">
                        <TextField

                            fullWidth
                            className="prompt srch_explore"
                            name="firstName"
                            label="First Name"
                            value={formik.values.firstName}
                            onChange={formik.handleChange}
                            error={formik.touched.firstName && Boolean(formik.errors.firstName)}
                            helperText={formik.touched.firstName && formik.errors.firstName}
                        />
                    </div>

                </div>
                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh11 swdh19">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            name="lastName"
                            label="Last Name"
                            value={formik.values.lastName}
                            onChange={formik.handleChange}
                            error={formik.touched.lastName && Boolean(formik.errors.lastName)}
                            helperText={formik.touched.lastName && formik.errors.lastName}
                        />
                    </div>

                </div>
                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh11 swdh19">
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
                    <div className="ui left icon input swdh11 swdh19">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            label="Password"
                            name="password"
                            type={showPassword ? "text" : "password"}
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
                    <div className="ui left icon input swdh11 swdh19">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            name="confirmPassword"
                            label="Confirm Password"
                            type={showConfirmPassword ? "text" : "password"}
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

                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh11 swdh19">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            name="description"
                            label="Description"
                            value={formik.values.description}
                            onChange={formik.handleChange}
                            error={formik.touched.description && Boolean(formik.errors.description)}
                            helperText={formik.touched.description && formik.errors.description}
                        />
                    </div>
                </div>

                <div className="ui search focus mt-15">
                    <div className="ui left icon input swdh11 swdh19">
                        <RadioGroup
                            row
                            aria-labelledby="demo-radio-buttons-group-label"
                            defaultValue="STUDENT"
                            name="type"
                            onChange={formik.handleChange}
                        >
                            <FormControlLabel value="STUDENT" control={<Radio />} label="STUDENT" />
                            <FormControlLabel value="INSTRUCTOR" control={<Radio />} label="INSTRUCTOR" />
                        </RadioGroup>
                    </div>
                </div>

                <button
                    className={isSubmitting ? "login-btn disabled" : "login-btn"}
                    type='submit'
                    style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                >
                    <span style={{ marginRight: '8px' }}>Sign Up</span>
                    {isSubmitting && <CircularProgress mr={'15px'} size={16} color='inherit' />}

                </button>
            </form>
            <p className="sgntrm145">By signing up, you agree to our <a href="terms_of_use.html">Terms of Use</a> and <a href="terms_of_use.html">Privacy Policy</a>.</p>
            <p className="mb-0 mt-30">Already have an account? <Link to={"/sign-in"}>Sign In</Link></p>
            <MuiSnackBar open={success} severity="success" message={message} onClose={() => { setSuccess(false) }} />
            <MuiSnackBar open={error} severity="error" message={message} onClose={() => { setError(false) }} />
        </div>
    );
}
