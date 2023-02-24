import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import studyCourseAPI from '../../../api/studyCourseAPI';
import './styles.css';
Assignment.propTypes = {};

function Assignment({ lessonStudy }) {
  // console.log(lessonStudy);
  const [file, setLinkfile] = useState('');
  useEffect(() => {
    const params = {
      fileUrl: lessonStudy.assignmentUrl
        ? lessonStudy.assignmentUrl
        : 'https://lms11storagemain.blob.core.windows.net/lms11storagemain/Diagram-Update-17-01-Time-10-41.png',
    };
    setLinkfile(
      'https://lmsnet11be.azurewebsites.net/api/Files/download-file-from-azure?fileUrl=' +
        params.fileUrl
    );
  }, []);
  return (
    <>
      <div className="lecture-content-inner mt-35">
        <div className="lecture-content-inner-video">
          <div className="video-responsive">
            <iframe
              className="lec-responsive-width"
              src={
                lessonStudy.imageUrl
                  ? lessonStudy.imageUrl
                  : 'http://dainam.edu.vn/img/system/no-image.png'
              }
              frameborder="0"
            >
              {lessonStudy.imageUrl}
            </iframe>
          </div>
        </div>
        <a className="dowloadFile" href={file} download>
          Click to download
        </a>
      </div>
      <p className="contentLesson">{lessonStudy.content}</p>
    </>
  );
}

export default Assignment;
