import { Alert, Snackbar } from '@mui/material'

const MuiSnackBar = (props) => {
    const onCloseHandler = () => props.onClose();

    return (
        <Snackbar open={props.open} autoHideDuration={6000} onClose={onCloseHandler}>
            <Alert onClose={onCloseHandler} severity={props.severity} sx={{ width: '100%' }}>
                {props.message}
            </Alert>
        </Snackbar>
    )
}

export default MuiSnackBar;