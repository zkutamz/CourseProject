import React from 'react';
import PropTypes from 'prop-types';
import { FaBookOpen } from 'react-icons/fa';
import './styles.css';
NextPrev.propTypes = {
  handleNextPrev: PropTypes.func,
};
NextPrev.defaultProps = {
  handleNextPrev: () => {},
};
function NextPrev({ handleNextPrev, totalItemCourse, totalItemCourseOfUSer }) {
  const handleNextPrevCurrent = (data) => {
    handleNextPrev(data);
  };
  return (
    <div className="lecture-header d-flex">
      <div className="lecture-header-left d-flex">
        <div className="progressStudy">
          <FaBookOpen className="iconProgress" />
          <p className="totalProgress">
            ( {totalItemCourseOfUSer}/{totalItemCourse} )
          </p>
          <h5 className="titleProgress">Your Progress</h5>
        </div>
        <a href="javascript:;" className="nav-icon-list d-sm-block d-md-block d-lg-none">
          <i className="fas fa-list" />
        </a>
      </div>
      <div className="lecture-header-right d-flex">
        <a onClick={() => handleNextPrev(-1)} className="nav-btn disabled">
          <span className="nav-text">
            <i className="fas fa-long-arrow-alt-left mr-2" />
            Previous
          </span>
        </a>
        <a onClick={() => handleNextPrev(1)} className="nav-btn" href="#">
          <span className="nav-text">
            Next
            <i className="fas fa-long-arrow-alt-right ml-2" />
          </span>
        </a>
      </div>
    </div>
  );
}

export default NextPrev;
