import React from 'react';
import PropTypes from 'prop-types';
import ReactPlayer from 'react-player';
Lesson.propTypes = {
  lessonStudy: PropTypes.object,
  handleEndLesson: PropTypes.func,
};
Lesson.defaultProps = {
  lessonStudy: {},
  handleEndLesson: () => {},
};
function Lesson({ lessonStudy, handleEndLesson }) {
  const endLesson = () => {
    handleEndLesson(lessonStudy.id);
  };
  return (
    <>
      <div className="lecture-content-inner mt-35">
        <div className="lecture-content-inner-video">
          <div className="video-responsive">
            <ReactPlayer
              controls
              url={
                lessonStudy.videoUrl
                  ? lessonStudy.videoUrl
                  : 'http://www.youtube.com/embed/oHg5SJYRHA0?autoplay=1'
              }
              light={
                lessonStudy.imageUrl
                  ? lessonStudy.imageUrl
                  : 'https://lms11storagemain.blob.core.windows.net/lms11storagemain/khang-profile.png'
              }
              onEnded={endLesson}
            />
          </div>
        </div>
      </div>
      <p className="contentLesson">{lessonStudy.content}</p>
    </>
  );
}

export default Lesson;
