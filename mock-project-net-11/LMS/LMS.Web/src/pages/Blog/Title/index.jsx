import React from 'react';
import PropTypes from 'prop-types';

Title.propTypes = {};

function Title(props) {
  return (
    <div className="_215cd2">
      <div className="container">
        <div className="row">
          <div className="col-lg-12">
            <div className="course_tabs">
              <nav>
                <div className="nav nav-tabs tab_crse  justify-content-center">
                  <a className="nav-item nav-link" href="about_us.html">
                    About
                  </a>
                  <a className="nav-item nav-link active" href="our_blog.html">
                    Blog
                  </a>
                  <a className="nav-item nav-link" href="company_details.html">
                    Company
                  </a>
                  <a className="nav-item nav-link" href="career.html">
                    Careers
                  </a>
                  <a className="nav-item nav-link" href="press.html">
                    Press
                  </a>
                </div>
              </nav>
            </div>
            <div className="title129 mt-35 mb-35">
              <h2>Insights, ideas, and stories</h2>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Title;
