import Alert from '@mui/material/Alert';
import CircularProgress from '@mui/material/CircularProgress';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import { useFormik } from 'formik';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import * as yup from 'yup';
import authApi from '../../api/authAPI';


const validationSchema = yup.object({
    emailAddress: yup
        .string('Enter your email address')
        .email('Email address is invalid')
        .required('Email address is required')
});

export default function ForgotPassword() {
    const [error, setError] = useState(false);
    const [success, setSuccess] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);

    const formik = useFormik({
        initialValues: {
            emailAddress: 'client@mail.com',
        },
        validationSchema: validationSchema,
        onSubmit: (values) => {
            setIsSubmitting(true);
            forgotPassword(values);
        },
    });

    const forgotPassword = async (values) => {
        try {
            var res = await authApi.forgotPassword(values);
            if (res.data.statusCode === 201) {
                setSuccess(true);
                setError(false);

            } else {
                setError(true);
                setSuccess(false);
            }
            setIsSubmitting(false);
        } catch (error) {
            setError(true);
            setSuccess(false);
            setIsSubmitting(false);
        }
    }

    return (
        <div className="sign_form">
            <h2>Forgot password!</h2>
            <form onSubmit={formik.handleSubmit}>
                <div className="ui search focus">
                    <div className="ui left icon input swdh11 swdh19">
                        <TextField
                            fullWidth
                            className="prompt srch_explore"
                            name="emailAddress"
                            label="EmailAddress"
                            value={formik.values.emailAddress}
                            onChange={formik.handleChange}
                            error={formik.touched.emailAddress && Boolean(formik.errors.emailAddress)}
                            helperText={formik.touched.emailAddress && formik.errors.emailAddress}
                        />
                    </div>
                    {error ? <div className="ui left icon input swdh11 swdh19 mt-15">
                        <Stack sx={{ width: '100%' }} spacing={2}>
                            <Alert severity="error">There is no email address in the system!</Alert>
                        </Stack>
                    </div> : ''}
                    {success ? <div className="ui left icon input swdh11 swdh19 mt-15">
                        <Stack sx={{ width: '100%' }} spacing={2}>
                            <Alert severity="success">Please check your email for password reset instructions!</Alert>
                        </Stack>
                    </div> : ''}

                    <button
                        className={isSubmitting ? "login-btn disabled" : "login-btn"}
                        type='submit'
                        style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                    >
                        <span style={{ marginRight: '8px' }}>Submit</span>
                        {isSubmitting && <CircularProgress mr={'15px'} size={16} color='inherit' />}
                    </button>
                </div>
            </form>
            <p className="mb-0 mt-30 hvsng145">Remember your account? <Link to={"/sign-in"}>Sign In</Link></p>
        </div>
    )
}
