import PropTypes from 'prop-types';
import React from 'react';
import { FaCheckSquare, FaSquare } from 'react-icons/fa';
import './styles.css';
LectureSidebar.propTypes = {
  section: PropTypes.array,
  handleViewLesson: PropTypes.func,
};
LectureSidebar.defaultProps = {
  section: null,
  handleViewLesson: () => {},
};
function LectureSidebar({
  section,
  titleCourse,
  handleClickItem,
  lessonCurrent,
  quizCurrent,
  assignmentCurrent,
}) {
  //console.log(section);
  const handleClickLesson = (id) => {
    const data = {
      lesson: id,
      quiz: 0,
      assignment: 0,
    };
    handleClickItem(data);
  };
  const handleClickQuiz = (id) => {
    const data = {
      lesson: 0,
      quiz: id,
      assignment: 0,
    };
    handleClickItem(data);
  };
  const handleClickAssignment = (id) => {
    const data = {
      lesson: 0,
      quiz: 0,
      assignment: id,
    };
    handleClickItem(data);
  };
  const listSection = section.map((section) => (
    <div key={section.name} className="course-course-section">
      <div className="section-header pp-2 d-flex">
        <span className="section-name flex-grow-1 ms-2 d-flex">
          <strong className="flex-grow-1">{section.name}</strong>
        </span>
      </div>
      <div className="course-section-body">
        {section.lessons.map((lesson) => (
          <div key={lesson.id} className="sidebar-section-item ">
            {lesson.id === lessonCurrent && lessonCurrent > 0 ? (
              <div className="section-item-title">
                <a
                  onClick={() => handleClickLesson(lesson.id)}
                  className="pp-2 d-flex activeLesson"
                >
                  <span className="lecture-status-icon pr-1">
                    {lesson.isComplete ? <FaCheckSquare /> : <FaSquare />}
                  </span>
                  <div className="title-container pl-2 flex-grow-1 d-flex">
                    <span className="lecture-name flex-grow-1">{lesson.title}</span>
                  </div>
                </a>
              </div>
            ) : (
              <div className="section-item-title">
                <a onClick={() => handleClickLesson(lesson.id)} className="pp-2 d-flex">
                  <span className="lecture-status-icon pr-1">
                    {lesson.isComplete ? <FaCheckSquare /> : <FaSquare />}
                  </span>
                  <div className="title-container pl-2 flex-grow-1 d-flex">
                    <span className="lecture-name flex-grow-1">{lesson.title}</span>
                  </div>
                </a>
              </div>
            )}
          </div>
        ))}
        {section.quizSections.map((quiz) => (
          <div key={quiz.quiz.id} className="sidebar-section-item ">
            {quiz.quiz.id === quizCurrent && quizCurrent > 0 ? (
              <div className="section-item-title">
                <a
                  onClick={() => handleClickQuiz(quiz.quiz.id)}
                  className="pp-2 d-flex activeLesson"
                >
                  <span className="lecture-status-icon pr-1">
                    {quiz.quiz.isComplete ? <FaCheckSquare /> : <FaSquare />}
                  </span>
                  <div className="title-container pl-2 flex-grow-1 d-flex">
                    <span className="lecture-name flex-grow-1">{quiz.quiz.title}</span>
                  </div>
                </a>
              </div>
            ) : (
              <div className="section-item-title">
                <a onClick={() => handleClickQuiz(quiz.quiz.id)} className="pp-2 d-flex">
                  <span className="lecture-status-icon pr-1">
                    {quiz.quiz.isComplete ? <FaCheckSquare /> : <FaSquare />}
                  </span>
                  <div className="title-container pl-2 flex-grow-1 d-flex">
                    <span className="lecture-name flex-grow-1">{quiz.quiz.title}</span>
                  </div>
                </a>
              </div>
            )}
          </div>
        ))}
        {section.assignments.map((ass) => (
          <div key={ass.id} className="sidebar-section-item ">
            {ass.id === assignmentCurrent && assignmentCurrent > 0 ? (
              <div className="section-item-title">
                <a
                  onClick={() => handleClickAssignment(ass.id)}
                  className="pp-2 d-flex activeLesson"
                >
                  <span className="lecture-status-icon pr-1">
                    {ass.isComplete ? <FaCheckSquare /> : <FaSquare />}
                  </span>
                  <div className="title-container pl-2 flex-grow-1 d-flex">
                    <span className="lecture-name flex-grow-1">{ass.title}</span>
                  </div>
                </a>
              </div>
            ) : (
              <div className="section-item-title">
                <a onClick={() => handleClickAssignment(ass.id)} className="pp-2 d-flex">
                  <span className="lecture-status-icon pr-1">
                    {ass.isComplete ? <FaCheckSquare /> : <FaSquare />}
                  </span>
                  <div className="title-container pl-2 flex-grow-1 d-flex">
                    <span className="lecture-name flex-grow-1">{ass.title}</span>
                  </div>
                </a>
              </div>
            )}
          </div>
        ))}
      </div>
    </div>
  ));
  return (
    <>
      <h4 className="p-4 lecture-sidebar-course-title">{titleCourse}</h4>
      <div className="lecture-sidebar-curriculum-wrap">{listSection}</div>
    </>
  );
}

export default LectureSidebar;
