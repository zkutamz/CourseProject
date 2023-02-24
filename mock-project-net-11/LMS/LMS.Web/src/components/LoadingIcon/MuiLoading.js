import { Backdrop } from '@mui/material';
import CircularProgress from '@mui/material/CircularProgress';


const MuiLoading = (props) => {
    return (
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
            open={props.isLoading}
        >
            <CircularProgress color="inherit" />
        </Backdrop>
    )
}

export default MuiLoading;