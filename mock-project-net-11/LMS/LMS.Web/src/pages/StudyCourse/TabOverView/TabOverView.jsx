import React from 'react';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';

TabOverView.propTypes = {};

function TabOverView(props) {
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
                      to="/study_course"
                      className="nav-item nav-link"
                      exact
                      activeClassName="active"
                    >
                      About
                    </NavLink>
                  </div>
                  <div>
                    <NavLink
                      to="/study_course/note"
                      className="nav-item nav-link"
                      activeClassName="active"
                      exact
                    >
                      Notes
                    </NavLink>
                  </div>
                  <a
                    className="nav-item nav-link"
                    id="nav-purchased-tab"
                    data-toggle="tab"
                    href="#nav-purchased"
                    role="tab"
                    aria-selected="false"
                  >
                    Contact Us
                  </a>
                  <a
                    className="nav-item nav-link"
                    id="nav-purchased-tab"
                    data-toggle="tab"
                    href="#nav-purchased"
                    role="tab"
                    aria-selected="false"
                  >
                    Developers
                  </a>
                  <a
                    className="nav-item nav-link"
                    id="nav-subscriptions-tab"
                    data-toggle="tab"
                    href="#nav-subscriptions"
                    role="tab"
                    aria-selected="false"
                  >
                    CopyRight
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

export default TabOverView;
