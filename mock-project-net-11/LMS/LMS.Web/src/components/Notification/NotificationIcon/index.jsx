import React from 'react';
import PropTypes from 'prop-types';

NotificationIcon.propTypes = {

};

function NotificationIcon (props) {
  return (
    <>
        <li className="ui dropdown">
                <a href="#" className="option_links" title="Notifications">
                  <i className="uil uil-bell" />
                  <span className="noti_count">3</span>
                </a>
                <div className="menu dropdown_mn">
                  <a href="#" className="channel_my item">
                    <div className="profile_link">
                      <img src="images/left-imgs/img-1.jpg" alt="" />
                      <div className="pd_content">
                        <h6>Rock William</h6>
                        <p>
                          Like Your Comment On Video <strong>How to create sidebar menu</strong>.
                        </p>
                        <span className="nm_time">2 min ago</span>
                      </div>
                    </div>
                  </a>
                  <a href="#" className="channel_my item">
                    <div className="profile_link">
                      <img src="images/left-imgs/img-2.jpg" alt="" />
                      <div className="pd_content">
                        <h6>Jassica Smith</h6>
                        <p>
                          Added New Review In Video <strong>Full Stack PHP Developer</strong>.
                        </p>
                        <span className="nm_time">12 min ago</span>
                      </div>
                    </div>
                  </a>
                  <a href="#" className="channel_my item">
                    <div className="profile_link">
                      <img src="images/left-imgs/img-9.jpg" alt="" />
                      <div className="pd_content">
                        <p>
                          {' '}
                          Your Membership Approved <strong>Upload Video</strong>.
                        </p>
                        <span className="nm_time">20 min ago</span>
                      </div>
                    </div>
                  </a>
                  <a className="vbm_btn" href="instructor_notifications.html">
                    View All <i className="uil uil-arrow-right" />
                  </a>
                </div>
        </li>
    </>
  );
}

export default NotificationIcon;
