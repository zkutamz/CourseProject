import React from 'react';
import PropTypes from 'prop-types';
import './styles.css';
import moment from 'moment';
import ReactStars from 'react-stars';
import SecondToHour from '../../../js/secondToHour';
AboutCourse.propTypes = {};

function AboutCourse({ overviewCourse }) {
  //console.log(overviewCourse);
  const listSection = overviewCourse.sections.map((section) => (
    <p key={section.id} className="rvds10">
      {section.name + '       ( ' + SecondToHour(section.totalTime) + ' hour ) '}
    </p>
  ));
  return (
    <div className="lecture-content-txt mt-35">
      <div className="titleOverview">
        <h4>{overviewCourse.title}</h4>
      </div>
      <div className="review_all120 reviewFeature">
        <div className="review_item">
          <p className="titleOverview--author">
            Author: {overviewCourse.appUser.firstName + ' ' + overviewCourse.appUser.lastName}
          </p>
          <div className="titleOverview--author">
            <p className="inforAuthor">
              {overviewCourse.appUser.firstName + ' ' + overviewCourse.appUser.lastName}
            </p>
            <p className="inforAuthor">Total reviews: {overviewCourse.totalReviewed}</p>
            <p className="inforAuthor">Total students: {overviewCourse.totalStudents}</p>
          </div>
        </div>
      </div>
      <p className="mb-0">{overviewCourse.description}</p>
      <div className="review_all120 reviewFeature">
        <div className="review_item">
          <h3>Feature Review</h3>
          <div className="review_usr_dt">
            <div className="rv1458">
              <ReactStars count={5} value={10} size={24} edit={false} color2={'#f2b01e'} />
              <span className="time_145">
                {moment(overviewCourse.featuredReview.updatedAt, moment.ISO_8601).fromNow()}
              </span>
            </div>
          </div>
          <p className="rvds10">{overviewCourse.featuredReview.content}</p>
        </div>
      </div>
      <div className="review_all120 reviewFeature">
        <div className="review_item">
          <h3>PREREQUISITES</h3>
          <div className="review_usr_dt">
            <div className="">{listSection}</div>
          </div>
        </div>
      </div>
      <div className="review_all120 reviewFeature">
        <div className="review_item">
          <h3>Requirements</h3>
          <div className="review_usr_dt">
            <div className="requirement">{overviewCourse.requirement}</div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default AboutCourse;
