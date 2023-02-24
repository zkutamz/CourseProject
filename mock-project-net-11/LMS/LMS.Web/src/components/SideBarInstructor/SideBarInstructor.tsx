import { Drawer } from '@mui/material';
import React from 'react';
import { NavLink } from 'react-router-dom';

const SideBarInstructor: React.FC<{ minify: boolean }> = (props) => {
    return (
        <nav className={`vertical_nav ${props.minify ? '' : 'vertical_nav__minify'}`}>
            <div className="left_section menu_left" id="js-menu">
                <div className="left_section">
                    <ul>
                        <li className="menu--item">
                            <NavLink to="/instructor" className="menu--link" activeClassName='active' >
                                <i className="uil uil-apps menu--icon" />
                                <span className="menu--label">Dashboard</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/courses" className="menu--link" activeClassName='active' >
                                <i className="uil uil-book-alt menu--icon" />
                                <span className="menu--label">Courses</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/analytics" className="menu--link" activeClassName='active' >
                                <i className="uil uil-analysis menu--icon" />
                                <span className="menu--label">Analytics</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/create-course" className="menu--link" activeClassName='active' >
                                <i className="uil uil-plus-circle menu--icon" />
                                <span className="menu--label">Create Course</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/messages" className="menu--link" activeClassName='active' >
                                <i className="uil uil-comments menu--icon" />
                                <span className="menu--label">Messages</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/notifications" className="menu--link" activeClassName='active' >
                                <i className="uil uil-bell menu--icon" />
                                <span className="menu--label">Notifications</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-award menu--icon" />
                                <span className="menu--label">My Certificates</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-star menu--icon" />
                                <span className="menu--label">Reviews</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-dollar-sign menu--icon" />
                                <span className="menu--label">Earning</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-wallet menu--icon" />
                                <span className="menu--label">Payout</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-file-alt menu--icon" />
                                <span className="menu--label">Statements</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-check-circle menu--icon" />
                                <span className="menu--label">Verification</span>
                            </NavLink>
                        </li>
                    </ul>
                </div>
                <div className="left_section pt-2">
                    <ul>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-cog menu--icon" />
                                <span className="menu--label">Setting</span>
                            </NavLink>
                        </li>
                        <li className="menu--item">
                            <NavLink to="/instructor/dashboard" className="menu--link" activeClassName='active' >
                                <i className="uil uil-comment-alt-exclamation menu--icon" />
                                <span className="menu--label">Send Feedback</span>
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default SideBarInstructor;