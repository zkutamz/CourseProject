import React, { useContext } from 'react';
import { NavLink } from 'react-router-dom';
import AuthContext from '../../store/auth-context';
import CategorySideBar from '../Category/CategorySideBar';
import ReportHistoryIcon from '../ReportHistory/ReportHistoryIcon';
import SendFeedbackIcon from '../SendFeedback/SendFeedbackIcon/SendFeedbackIcon';
import SettingIcon from '../Setting/SettingIcon';
import Explore from './Explore';
import Tests from './Tests';

const SideBarHome = (props) => {
  const authContext = useContext(AuthContext);

  return (
    <>
      <nav className={`vertical_nav ${props.minify ? '' : 'vertical_nav__minify'}`}>
        <div className="left_section menu_left" id="js-menu">
          <div className="left_section">
            <ul>
              <li className="menu--item">
                <NavLink to="/" className="menu--link" activeClassName='active' title="Home">
                  <i className="uil uil-home-alt menu--icon" />
                  <span className="menu--label">Home</span>
                </NavLink>
              </li>
              <li className="menu--item">
                <Explore />
              </li>
              <li className="menu--item menu--item__has_sub_menu">
                <CategorySideBar />
              </li>
              {
                authContext.isLoggedIn &&
                <li>
                  <Tests />
                </li>
              }
              {
                !authContext.isLoggedIn &&
                <li>
                  <NavLink to="/sign-in" activeClassName='active' className="menu--item  menu--item__has_sub_menu">
                    <Tests />
                  </NavLink>
                </li>
              }
              {
                authContext.isLoggedIn &&
                <li className="menu--item">
                  <NavLink to="/favorites">
                    <i className="uil uil-heart-alt menu--icon" />
                    <span className="menu--label">Favorites Courses</span>
                  </NavLink>
                </li>
              }
              {
                !authContext.isLoggedIn &&
                <li className="menu--item">
                  <NavLink to="/sign-in">
                    <i className="uil uil-heart-alt menu--icon" />
                    <span className="menu--label">Favorites Courses</span>
                  </NavLink>
                </li>
              }
              {/* <li className="menu--item  menu--item__has_sub_menu">
                  <Pages isLogin={this.state.token ? true : false} />
                </li> */}
            </ul>
          </div>
          <div className="left_section">
            {
              authContext.isLoggedIn &&
              <h6 className="left_title">SUBSCRIPTIONS</h6>
              &&
              <ul>
                <li className="menu--item">
                  <a href="instructor_profile_view.html" className="menu--link user_img">
                    <img src="images/left-imgs/img-1.jpg" alt="" />
                    Rock Smith
                    <div className="alrt_dot" />
                  </a>
                </li>
                <li className="menu--item">
                  <a href="instructor_profile_view.html" className="menu--link user_img">
                    <img src="images/left-imgs/img-2.jpg" alt="" />
                    Jassica William
                  </a>
                  <div className="alrt_dot" />
                </li>
                <li className="menu--item">
                  <a href="all_instructor.html" className="menu--link" title="Browse Instructors">
                    <i className="uil uil-plus-circle menu--icon" />
                    <span className="menu--label">Browse Instructors</span>
                  </a>
                </li>
              </ul>
            }
          </div>
          <div className="left_section pt-2">
            <ul>
              <li className="menu--item">
                {
                  authContext.isLoggedIn &&
                  <SettingIcon />
                }
                {
                  !authContext.isLoggedIn &&
                  <NavLink to="/sign-in" activeClassName='active'>
                    <SettingIcon />
                  </NavLink>
                }

              </li>
              <li className="menu--item">
                <NavLink to="/help" className="menu--link" activeClassName='active' title="Help">
                  <i className="uil uil-question-circle menu--icon" />
                  <span className="menu--label">Help</span>
                </NavLink>
              </li>
              <li className="menu--item">
                {
                  authContext.isLoggedIn &&
                  <ReportHistoryIcon />
                }
                {
                  !authContext.isLoggedIn &&
                  <NavLink to="/sign-in" activeClassName='active'>
                    <ReportHistoryIcon />
                  </NavLink>
                }
              </li>
              <li className="menu--item">
                {
                  authContext.isLoggedIn &&
                  <SendFeedbackIcon />
                }
                {
                  !authContext.isLoggedIn &&
                  <NavLink to="/sign-in" activeClassName='active'>
                    <SendFeedbackIcon />
                  </NavLink>
                }
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </>
  );
}

export default SideBarHome;
