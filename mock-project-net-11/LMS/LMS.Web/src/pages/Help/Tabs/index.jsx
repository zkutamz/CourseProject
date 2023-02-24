import React from 'react';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';

Tabs.propTypes = {};

function Tabs(props) {
  return (
    <div className="_215b15">
      <div className="container">
        <div className="row">
          <div className="col-lg-12">
            <div className="course_tabs">
              <nav>
                <div
                  className="nav nav-tabs help_tabs tab_crse justify-content-center"
                  id="nav-tab"
                  role="tablist"
                >
                  <NavLink
                    to="/help"
                    className="nav-item nav-link"
                    id="nav-instructor-tab"
                    exact
                    activeClassName="active"
                  >
                    Instructor
                  </NavLink>
                  <NavLink
                    to="/help/student"
                    className="nav-item nav-link"
                    id="nav-student-tab"
                    exact
                    activeClassName="active"
                  >
                    Student
                  </NavLink>
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
