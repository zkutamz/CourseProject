import React from 'react';

function AboutHeader() {
  return (
    <header className="header clearfix">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="back_link">
              <a href="index.html" className="hde151">
                Back To Cursus
              </a>
              <a href="index.html" className="hde152">
                Back
              </a>
            </div>
            <div className="ml_item">
              <div className="main_logo main_logo15" id="logo">
                <a href="index.html">
                  <img src="images/logo.svg" alt="" />
                </a>
                <a href="index.html">
                  <img className="logo-inverse" src="images/ct_logo.svg" alt="" />
                </a>
              </div>
            </div>
            <div className="header_right pr-0">
              <ul>
                <li className="ui top right pointing dropdown">
                  <a href="#" className="opts_account">
                    <img src="images/hd_dp.jpg" alt="" />
                  </a>
                  <div className="menu dropdown_account">
                    <div className="channel_my">
                      <div className="profile_link">
                        <img src="images/hd_dp.jpg" alt="" />
                        <div className="pd_content">
                          <div className="rhte85">
                            <h6>Joginder Singh</h6>
                            <div className="mef78" title="Verify">
                              <i className="uil uil-check-circle" />
                            </div>
                          </div>
                          <span>
                            <a
                              href="/cdn-cgi/l/email-protection"
                              className="__cf_email__"
                              data-cfemail="c5a2a4a8a7aaa9fcf1f685a2a8a4aca9eba6aaa8"
                            >
                              [email&nbsp;protected]
                            </a>
                          </span>
                        </div>
                      </div>
                      <a href="my_instructor_profile_view.html" className="dp_link_12">
                        View Instructor Profile
                      </a>
                    </div>
                    <div className="night_mode_switch__btn">
                      <a href="#" id="night-mode" className="btn-night-mode">
                        <i className="uil uil-moon" /> Night mode
                        <span className="btn-night-mode-switch">
                          <span className="uk-switch-button" />
                        </span>
                      </a>
                    </div>
                    <a href="instructor_dashboard.html" className="item channel_item">
                      Cursus Dashboard
                    </a>
                    <a href="sign_in.html" className="item channel_item">
                      Sign Out
                    </a>
                  </div>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </header>
  );
}
export default AboutHeader;
