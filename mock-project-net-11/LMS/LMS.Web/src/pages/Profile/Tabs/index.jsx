import React from 'react';
import { NavLink } from 'react-router-dom';
Tabs.propTypes = {};

function Tabs(props) {
  const [value, setValue] = React.useState('1');

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  return (
    <div className="_215b15">
      <div className="container-fluid">
        <div className="row">
          <div className="col-lg-12">
            <div className="course_tabs">
              <nav>
                <div className="nav nav-tabs tab_crse" id="nav-tab" role="tablist">
                  <div>
                    <NavLink
                      to="/profile"
                      className="nav-item nav-link"
                      exact
                      activeClassName="active"
                    >
                      About
                    </NavLink>
                  </div>
                  <NavLink
                    to="/profile/courses"
                    className="nav-item nav-link"
                    id="nav-courses-tab"
                    data-toggle="tab"
                    href="#nav-courses"
                    role="tab"
                    aria-selected="false"
                    exact
                  >
                    Courses
                  </NavLink>
                  <a
                    className="nav-item nav-link"
                    id="nav-purchased-tab"
                    data-toggle="tab"
                    href="#nav-purchased"
                    role="tab"
                    aria-selected="false"
                  >
                    Purchased
                  </a>
                  <div>
                    <NavLink
                      to="/profile/discussion"
                      className="nav-item nav-link"
                      activeClassName="active"
                      exact
                    >
                      Discussion
                    </NavLink>
                  </div>
                  <a
                    className="nav-item nav-link"
                    id="nav-subscriptions-tab"
                    data-toggle="tab"
                    href="#nav-subscriptions"
                    role="tab"
                    aria-selected="false"
                  >
                    Subscriptions
                  </a>
                </div>
              </nav>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
export default Tabs;
