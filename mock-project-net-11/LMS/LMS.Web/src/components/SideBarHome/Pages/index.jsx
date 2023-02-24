import React from 'react';
import PropTypes from 'prop-types';

Pages.propTypes = {

};

function Pages (props) {
    let toggle = false;
    function pageClicked(e) {
        toggle = !toggle;
        if(toggle){
            document.getElementById("content-page-list").style.display = 'block';
        }else {
            document.getElementById("content-page-list").style.display = 'none';
        }
    }

    return (
        <>
            <label onClick={pageClicked} className="menu--link" title="Pages">
                <i className="uil uil-file menu--icon" />
                <span className="menu--label">Pages</span>
            </label>
            <ul className="sub_menu" id="content-page-list" >
                {
                    !props.isLogin &&
                    <li className="sub_menu--item">
                        <a href="about_us.html" className="sub_menu--link">
                            About
                        </a>
                    </li>
                }
                {
                    !props.isLogin &&
                    <li className="sub_menu--item">
                        <a href="sign_in.html" className="sub_menu--link">
                            Sign In
                        </a>
                    </li>
                }
                {
                    !props.isLogin &&
                    <li className="sub_menu--item">
                        <a href="sign_up.html" className="sub_menu--link">
                            Sign Up
                        </a>
                    </li>
                }
                {
                    !props.isLogin &&
                    <li className="sub_menu--item">
                        <a href="sign_up_steps.html" className="sub_menu--link">
                            Sign Up Steps
                        </a>
                    </li>
                }
                {
                    props.isLogin &&
                    <li className="sub_menu--item">
                        <a href="membership.html" className="sub_menu--link">
                            Paid Membership
                        </a>
                    </li>
                }
                {
                    props.isLogin &&
                    <li className="sub_menu--item">
                    <a href="add_streaming.html" className="sub_menu--link">
                        Add live Stream
                    </a>
                    </li>
                }
                <li className="sub_menu--item">
                <a href="invoice.html" className="sub_menu--link">
                    Invoice
                </a>
                </li>
                <li className="sub_menu--item">
                <a href="career.html" className="sub_menu--link">
                    Career
                </a>
                </li>
                <li className="sub_menu--item">
                <a href="apply_job.html" className="sub_menu--link">
                    Job Apply
                </a>
                </li>
                <li className="sub_menu--item">
                <a href="our_blog.html" className="sub_menu--link">
                    Our Blog
                </a>
                </li>
                <li className="sub_menu--item">
                <a href="company_details.html" className="sub_menu--link">
                    Company Details
                </a>
                </li>
                <li className="sub_menu--item">
                <a href="press.html" className="sub_menu--link">
                    Press
                </a>
                </li>
            </ul>
        </>
    );
}

export default Pages;