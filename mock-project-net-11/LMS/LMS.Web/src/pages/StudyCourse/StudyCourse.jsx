import React from 'react';
import Study from './Study/Study';

StudyCourse.propTypes = {};

function StudyCourse({ courseID }) {
  return (
    <>
      <Study courseID={1} />
    </>
  );
}

export default StudyCourse;
