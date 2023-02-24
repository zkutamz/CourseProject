import React, { useState, useEffect, useContext } from 'react';
import PropTypes from 'prop-types';
import { Link, BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Discussion from './Discussion';
import Tabs from './Tabs';
import About from './About';
import Courses from './Courses';
import profileAPI from '../../api/profileAPI';
import Stastical from './Stastical';
import AuthContext from '../../store/auth-context';
// Profile.propTypes = {
//   userId: props.propTypes(Number)
// };

function Profile(props) {
  const authContext = useContext(AuthContext);
  let userID = authContext.userId;
  // console.log(authContext);
  const [totalSubcriber, setTotalSubcriber] = useState(Number);
  const [totalCourse, setTotalCourse] = useState(Number);
  const [totalEnrollStudent, setTotalEnrollStudent] = useState(Number);
  const [totalCourseReview, setTotalCourseReview] = useState(Number);
  const [instructorInfo, setInstructorInfor] = useState({});
  const [instructorId, setInstructorId] = useState(Number);
  useEffect(() => {
    const fetchStastical = async () => {
      try {
        const dataSubcriber = await profileAPI.getTotalSubcriberOfInstructor(userID);
        setTotalSubcriber(dataSubcriber.data.value);
        const dataCourse = await profileAPI.getTotalCourseOfInstructor(userID);
        setTotalCourse(dataCourse.data.value);
        const dataEnrollStudent = await profileAPI.getTotalEnrollStudentOfInstructor(userID);
        setTotalEnrollStudent(dataEnrollStudent.data.value);
        const dataCourseReview = await profileAPI.getTotalReviewOfInstructor(userID);
        setTotalCourseReview(dataCourseReview.data.value);
      } catch (error) {
        console.log('Failed to fetch  fetch Stastical for instructor:  ', error.message);
      }
    };
    fetchStastical();
  }, []);
  return (
    <>
      <div className="_216b01">
        <div className="container-fluid">
          <div className="row justify-content-md-center">
            <div className="col-md-10">
              <div className="section3125 rpt145">
                <div className="row">
                  <div className="col-lg-7">
                    <a href="#" className="_216b22">
                      <span>
                        <i className="uil uil-cog" />
                      </span>
                      Setting
                    </a>
                    <div className="dp_dt150">
                      <div className="img148">
                        <img src="/images/hd_dp.jpg" alt="" />
                      </div>
                      <div className="prfledt1">
                        <h2>
                          {instructorInfo.firstName} {instructorInfo.lastName}
                        </h2>
                        <span>{instructorInfo.intro}</span>
                      </div>
                    </div>
                    <Stastical
                      totalSubcriber={totalSubcriber}
                      totalCourse={totalCourse}
                      totalEnrollStudent={totalEnrollStudent}
                      totalCourseReview={totalCourseReview}
                    />
                  </div>
                  <div className="col-lg-5">
                    <a href="setting.html" className="_216b12">
                      <span>
                        <i className="uil uil-cog" />
                      </span>
                      Setting
                    </a>
                    <div className="rgt-145">
                      <ul className="tutor_social_links">
                        <li>
                          <Link to={`${instructorInfo.facebookLink}`} className="fb">
                            <i className="fab fa-facebook-f" />
                          </Link>
                        </li>
                        <li>
                          <Link to={`${instructorInfo.twitterLink}`} className="tw">
                            <i className="fab fa-twitter" />
                          </Link>
                        </li>
                        <li>
                          <Link to={`${instructorInfo.linkedInLink}`} className="ln">
                            <i className="fab fa-linkedin-in" />
                          </Link>
                        </li>
                        <li>
                          <Link to={`${instructorInfo.youtubeLink}`} className="yu">
                            <i className="fab fa-youtube" />
                          </Link>
                        </li>
                      </ul>
                    </div>
                    <ul className="_bty149">
                      <li>
                        <button
                          className="studio-link-btn btn500"
                          onclick="window.location.href = 'instructor_dashboard.html';"
                        >
                          Cursus Studio
                        </button>
                      </li>
                      <li>
                        <button
                          className="msg125 btn500"
                          onclick="window.location.href = 'setting.html';"
                        >
                          Edit
                        </button>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Tabs></Tabs>
      <div className="_215b17">
        <div className="container-fluid">
          <div className="row">
            <div className="col-lg-12">
              <div className="course_tab_content">
                <div className="tab-content" id="nav-tabContent">
                  <Switch>
                    <Route path="/profile" exact>
                      <About />
                    </Route>
                    <Route path="/profile/courses" exact>
                      <Courses />
                    </Route>
                    <Route path="/profile/about" exact>
                      <About />
                    </Route>
                    <Route path="/profile/discussion" exact>
                      <Discussion isLoggedIn={true} />
                    </Route>
                  </Switch>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Profile;
