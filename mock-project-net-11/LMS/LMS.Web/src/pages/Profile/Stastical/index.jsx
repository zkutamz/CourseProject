import React from 'react';
import PropTypes from 'prop-types';

Stastical.propTypes = {};

function Stastical({ totalSubcriber, totalCourse, totalEnrollStudent, totalCourseReview }) {
  return (
    <ul className="_ttl120">
      <li>
        <div className="_ttl121">
          <div className="_ttl122">Enroll Students</div>
          <div className="_ttl123">{totalEnrollStudent}</div>
        </div>
      </li>
      <li>
        <div className="_ttl121">
          <div className="_ttl122">Courses</div>
          <div className="_ttl123">{totalCourse}</div>
        </div>
      </li>
      <li>
        <div className="_ttl121">
          <div className="_ttl122">Reviews</div>
          <div className="_ttl123">{totalCourseReview}</div>
        </div>
      </li>
      <li>
        <div className="_ttl121">
          <div className="_ttl122">Subscriptiohs</div>
          <div className="_ttl123">{totalSubcriber}</div>
        </div>
      </li>
    </ul>
  );
}

export default Stastical;
