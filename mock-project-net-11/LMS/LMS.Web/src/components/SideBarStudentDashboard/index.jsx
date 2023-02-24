import React from 'react';
import SendFeedbackIcon from '../SendFeedback/SendFeedbackIcon/SendFeedbackIcon';
import SettingIcon from '../Setting/SettingIcon';

SideBarStudentDashboard.propTypes = {

};

function SideBarStudentDashboard (props) {

    return (
        <>
            <nav className="vertical_nav">
                <div className="left_section menu_left" id="js-menu">
                <div className="left_section">
                    <ul>
                    <li className="menu--item">
                        <a href="student_dashboard.html" className="menu--link active" title="Dashboard">
                        <i className="uil uil-apps menu--icon" />
                        <span className="menu--label">Dashboard</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_courses.html" className="menu--link" title="Courses">
                        <i className="uil uil-book-alt menu--icon" />
                        <span className="menu--label">Purchased Courses</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_messages.html" className="menu--link" title="Messages">
                        <i className="uil uil-comments menu--icon" />
                        <span className="menu--label">Messages</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_notifications.html" className="menu--link" title="Notifications">
                        <i className="uil uil-bell menu--icon" />
                        <span className="menu--label">Notifications</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_my_certificates.html" className="menu--link" title="My Certificates">
                        <i className="uil uil-award menu--icon" />
                        <span className="menu--label">My Certificates</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_all_reviews.html" className="menu--link" title="Reviews">
                        <i className="uil uil-star menu--icon" />
                        <span className="menu--label">Reviews</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_credits.html" className="menu--link" title="Credits">
                        <i className="uil uil-wallet menu--icon" />
                        <span className="menu--label">Credits</span>
                        </a>
                    </li>
                    <li className="menu--item">
                        <a href="student_statements.html" className="menu--link" title="Statements">
                        <i className="uil uil-file-alt menu--icon" />
                        <span className="menu--label">Statements</span>
                        </a>
                    </li>
                    </ul>
                </div>
                <div className="left_section pt-2">
                    <ul>
                    <li className="menu--item">
                        <SettingIcon />
                    </li>
                    <li className="menu--item">
                        <SendFeedbackIcon />
                    </li>
                    </ul>
                </div>
                </div>
            </nav>
        </>
    );
}
export default SideBarStudentDashboard;