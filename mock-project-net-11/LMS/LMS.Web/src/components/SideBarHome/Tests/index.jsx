import React from 'react';
import PropTypes from 'prop-types';

Tests.propTypes = {

};

function Tests (props) {
  return (
    <>
        <label className="menu--link" title="Tests">
            <i className="uil uil-clipboard-alt menu--icon" />
            <span className="menu--label">Tests</span>
        </label>
        <ul className="sub_menu">
            <li className="sub_menu--item">
            <a href="certification_center.html" className="sub_menu--link">
                Certification Center
            </a>
            </li>
            <li className="sub_menu--item">
            <a href="certification_start_form.html" className="sub_menu--link">
                Certification Fill Form
            </a>
            </li>
            <li className="sub_menu--item">
            <a href="certification_test_view.html" className="sub_menu--link">
                Test View
            </a>
            </li>
            <li className="sub_menu--item">
            <a href="certification_test__result.html" className="sub_menu--link">
                Test Result
            </a>
            </li>
            <li className="sub_menu--item">
            <a
                href="http://www.gambolthemes.net/html-items/edututs+/Instructor_Dashboard/my_certificates.html"
                className="sub_menu--link"
            >
                My Certification
            </a>
            </li>
        </ul>
    </>
  );
}

export default Tests;