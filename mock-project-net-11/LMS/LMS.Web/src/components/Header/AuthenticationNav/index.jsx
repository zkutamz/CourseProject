import LoginIcon from '@mui/icons-material/Login';
import LogoutIcon from '@mui/icons-material/Logout';
import { Button } from '@mui/material';
import React from 'react';

function AuthenticationNav() {
  return (
    <div className="position-absolute" style={{ right: 0 }}>
      <Button
        href="/sign-in"
        variant="contained"
        className="mr-md-2"
        startIcon={<LoginIcon />}>Sign In</Button>
      <Button
        href="/sign-up"
        variant="contained"
        color="error"
        startIcon={<LogoutIcon />}>Sign Up</Button>
    </div>
  );
}

export default AuthenticationNav;
