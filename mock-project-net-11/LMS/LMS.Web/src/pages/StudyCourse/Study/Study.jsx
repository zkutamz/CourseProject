import { width } from '@mui/system';
import React, { useContext, useEffect, useState } from 'react';
import { Route, Switch } from 'react-router-dom';
import studyCourseAPI from '../../../api/studyCourseAPI';
import Spinner from '../../../components/LoadingIcon/SpinnerIcon';
import AuthContext from '../../../store/auth-context';
import AboutCourse from '../About/AboutCourse';
import LectureSidebar from '../LectureSidebar/LectureSidebar';
import NextPrev from '../NextPrev/NextPrev';
import NoteCourse from '../Notes/NoteCourse';
import TabOverView from '../TabOverView/TabOverView';
import Lesson from '../DetailCourse/Lesson';
import Assignment from '../DetailCourse/Assignment';
import Quiz from '../DetailCourse/Quiz';
import './styles.css';
Study.propTypes = {};

function Study({ courseID }) {
  const authContext = useContext(AuthContext);
  const [loading, setLoading] = useState(true);
  const [loadingSections, setLoadingSection] = useState(true);
  const [loadingUser, setLoadingUser] = useState(false);
  const [overviewCourse, setOverviewCourse] = useState({});
  const [section, setSection] = useState({});
  const [totalItemCourse, setTotalItemCourse] = useState(0);
  const [totalItemCourseOfUSer, setTotalItemCourseOfUser] = useState(0);
  const [lessonCurrent, setLessonCurrent] = useState(1);
  const [quizCurrent, setQuizCurrent] = useState(0);
  const [assignmentCurrent, setAssignmentCurrent] = useState(0);
  const [changeItem, setChangeItem] = useState(false);
  const [checkQuiz, setCheckQuiz] = useState(false);
  const [updateInformation, setUpdateInformation] = useState(false);
  const [lessonStudy, setLessonStudy] = useState({});
  let userID = authContext.userId;
  useEffect(() => {
    const fetchOverViewCourse = async () => {
      try {
        const overview = await studyCourseAPI.getOverviewCourse(courseID);
        setOverviewCourse(overview.data);
        setLoading(false);
        //console.log(overviewCourse);
      } catch (error) {
        console.log('Failed to fetch overview course: ', error.message);
      }
    };
    const fetchTotalItemCourse = async () => {
      try {
        const totalItem = await studyCourseAPI.getTotalItemCourse(courseID);
        setTotalItemCourse(totalItem.data);
      } catch (error) {
        console.log('Failed to section study: ', error.message);
      }
    };
    const fetchTotalItemCourseOfUser = async () => {
      const params = {
        userId: userID > 0 ? userID : 0,
        courseId: courseID,
      };
      try {
        //console.log(params.userId);
        if (params.userId === 0) {
          setLoadingUser(!loadingUser);
        }
        const totalItem = await studyCourseAPI.getTotalItemCourseOfUser(params);
        setTotalItemCourseOfUser(totalItem.data);
      } catch (error) {
        console.log('Failed to section study: ', error.message);
      }
    };
    fetchTotalItemCourseOfUser();
    fetchOverViewCourse();
    fetchTotalItemCourse();
  }, []);
  useEffect(() => {
    const fetchTotalItemCourseOfUser = async () => {
      const params = {
        userId: userID > 0 ? userID : 0,
        courseId: courseID,
      };
      try {
        //console.log(params.userId);
        if (params.userId === 0) {
          setLoadingUser(!loadingUser);
        }
        const totalItem = await studyCourseAPI.getTotalItemCourseOfUser(params);
        setTotalItemCourseOfUser(totalItem.data);
      } catch (error) {
        console.log('Failed to section study: ', error.message);
      }
    };
    const fetchSectionsStudy = async () => {
      try {
        let sections = await studyCourseAPI.getSectionsStudy(courseID);
        //console.log(sections);
        setSection(sections.data);
        setLoadingSection(false);
      } catch (error) {
        console.log('Failed to section study of course: ', error.message);
      }
    };
    fetchTotalItemCourseOfUser();
    fetchSectionsStudy();
  }, [loadingUser, updateInformation]);
  useEffect(() => {
    const getLessonCurrent = async () => {
      try {
        if (lessonCurrent > 0) {
          //console.log('lesson');
          const lesson = await studyCourseAPI.getLessonCurrent(lessonCurrent);
          setLessonStudy(lesson.data);
          setCheckQuiz(false);
        }
        if (quizCurrent > 0) {
          //console.log('quiz');
          const quiz = await studyCourseAPI.getQuizCurrent(quizCurrent);
          setLessonStudy(quiz.data);
          setCheckQuiz(true);
        }
        if (assignmentCurrent > 0) {
          //console.log('assignment');
          const ass = await studyCourseAPI.getAssignmentCurrent(assignmentCurrent);
          setLessonStudy(ass.data);
          setCheckQuiz(false);
        }
      } catch (error) {
        console.log('Failed to get lesson current for study: ', error.message);
      }
    };
    getLessonCurrent();
  }, [changeItem]);
  const handleClickItem = (data) => {
    //console.log(data);
    setLessonCurrent(data.lesson);
    setQuizCurrent(data.quiz);
    setAssignmentCurrent(data.assignment);
    setChangeItem(!changeItem);
  };
  const handleNextPrev = (data) => {
    let tam = lessonCurrent + data;
    setLessonCurrent(tam);
  };
  const handleSubmitQuiz = (data) => {
    console.log(data);
  };
  const handleEndLesson = (lessonID) => {
    const fetchUserEndLesson = async () => {
      const params = {
        LessonId: lessonID,
        UserId: userID > 0 ? userID : 0,
      };
      try {
        if (params.UserId === 0) {
          setLoadingUser(!loadingUser);
        }
        const result = await studyCourseAPI.postUserCompleteLesson(params);
        console.log(result);
      } catch (error) {
        console.log('Failed to complete lesson for user: ', error.response);
      }
    };
    fetchUserEndLesson();
    setUpdateInformation(!updateInformation);
    setLoadingUser(!loadingUser);
  };
  //console.log(totalItemCourseOfUSer);
  return (
    <>
      <NextPrev
        totalItemCourseOfUSer={totalItemCourseOfUSer}
        totalItemCourse={totalItemCourse}
        handleNextPrev={handleNextPrev}
      />
      <div className="lecture-container-wrap d-flex">
        <div className="lecture-sidebar">
          {loadingSections ? (
            <div style={{ textAlign: 'center' }}>
              <Spinner />
            </div>
          ) : (
            <LectureSidebar
              handleClickItem={handleClickItem}
              titleCourse={overviewCourse.title}
              section={section}
              lessonCurrent={lessonCurrent}
              quizCurrent={quizCurrent}
              assignmentCurrent={assignmentCurrent}
            />
          )}
        </div>
        <div className="lecture-container">
          <h2 className="lecture-title mb-4">{lessonStudy.title}</h2>
          {lessonCurrent > 0 ? (
            <Lesson lessonStudy={lessonStudy} handleEndLesson={handleEndLesson} />
          ) : (
            <></>
          )}
          {assignmentCurrent > 0 ? <Assignment lessonStudy={lessonStudy} /> : <></>}
          {quizCurrent > 0 && checkQuiz ? (
            <Quiz handleSubmitQuiz={handleSubmitQuiz} lessonStudy={lessonStudy} />
          ) : (
            <></>
          )}
          <TabOverView />
          <div className="_215b17">
            {loading ? (
              <div style={{ textAlign: 'center' }}>
                <Spinner />
              </div>
            ) : (
              <div className="container-fluid">
                <div className="row">
                  <div className="col-lg-12">
                    <div className="course_tab_content">
                      <div className="tab-content" id="nav-tabContent">
                        <Switch>
                          <Route path="/study_course" exact>
                            <AboutCourse overviewCourse={overviewCourse} />
                          </Route>
                          <Route path="/study_course/note" exact>
                            <NoteCourse
                              courseId={courseID}
                              lessonId={lessonCurrent}
                              userId={userID}
                            />
                          </Route>
                        </Switch>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            )}
          </div>
        </div>
      </div>
    </>
  );
}

export default Study;
