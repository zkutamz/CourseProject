import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../../../store/auth-context';

function UserIcon() {
    const authContext = useContext(AuthContext);

    return (
        <li className="ui dropdown">
            <a type='button' data-bs-toggle="dropdown" id="dropdownMenuButton1" className="dropdown-toggle opts_account" title="Account" aria-expanded="false">
                <img src="images/hd_dp.jpg" alt="" />
            </a>
            <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                <li>
                    <Link to={`/profile/${authContext.userId}`} className='dropdown-item'>
                        <div className="channel_my">
                            <div className="profile_link">
                                <img src="images/hd_dp.jpg" alt="" />
                                <div className="pd_content">
                                    <div className="rhte85">
                                        <h6>{authContext.fullName}</h6>
                                        <div className="mef78" title="Verify">
                                            <i className="uil uil-check-circle" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <Link to={`/profile/${authContext.userId}`} className="dp_link_12">
                                View Profile
                            </Link>
                        </div>
                    </Link>
                </li>
                <li>
                    {
                        authContext.role === "Instructor" &&
                        <Link to="/instructor" className='dropdown-item'>
                            Instructor Dashboard
                        </Link>
                    }
                    {
                        authContext.role === "Student" &&
                        <Link to="/student" className='dropdown-item'>
                            Dashboard
                        </Link>
                    }
                    {
                        authContext.role === "Admin" &&
                        <Link to={{ pathname: "http://localhost:3001/#/dashboard" }} target="blank">
                            Admin Dashboard
                        </Link>
                    }
                </li>
                <li>
                    <Link to="/" className='dropdown-item'>
                        Setting
                    </Link>
                </li>
                <li>
                    <Link className='dropdown-item' to='/help'>
                        Help
                    </Link>
                </li>
                <li>
                    <Link to="/" className='dropdown-item'>
                        Send Feedback
                    </Link>
                </li>
                <li>
                    <Link className='dropdown-item' onClick={authContext.logout} to="sign-in">
                        Sign Out
                    </Link>
                </li>
            </ul>
        </li>
    );
}

export default UserIcon;