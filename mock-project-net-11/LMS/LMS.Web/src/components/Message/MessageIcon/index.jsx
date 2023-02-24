import React from 'react';
import PropTypes from 'prop-types';

MessageIcon.propTypes = {

};

function MessageIcon (props) {
  return (
    <>
        <li className="ui dropdown">
                <a href="#" className="option_links" title="Messages">
                  <i className="uil uil-envelope-alt" />
                  <span className="noti_count">3</span>
                </a>
                <div className="menu dropdown_ms">
                  <a href="#" className="channel_my item">
                    <div className="profile_link">
                      <img src="images/left-imgs/img-6.jpg" alt="" />
                      <div className="pd_content">
                        <h6>Zoena Singh</h6>
                        <p>
                          Hi! Sir, How are you. I ask you one thing please explain it this video
                          price.
                        </p>
                        <span className="nm_time">2 min ago</span>
                      </div>
                    </div>
                  </a>
                  <a href="#" className="channel_my item">
                    <div className="profile_link">
                      <img src="images/left-imgs/img-5.jpg" alt="" />
                      <div className="pd_content">
                        <h6>Joy Dua</h6>
                        <p>Hello, I paid you video tutorial but did not play error 404.</p>
                        <span className="nm_time">10 min ago</span>
                      </div>
                    </div>
                  </a>
                  <a href="#" className="channel_my item">
                    <div className="profile_link">
                      <img src="images/left-imgs/img-8.jpg" alt="" />
                      <div className="pd_content">
                        <h6>Jass</h6>
                        <p>Thanks Sir, Such a nice video.</p>
                        <span className="nm_time">25 min ago</span>
                      </div>
                    </div>
                  </a>
                  <a className="vbm_btn" href="instructor_messages.html">
                    View All <i className="uil uil-arrow-right" />
                  </a>
                </div>
              </li>
    </>
  );
}

export default MessageIcon;
