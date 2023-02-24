import './style.css';
import React, { useEffect, useState } from 'react';
import profileAPI from '../../../api/profileAPI';
export default function Courses() {
  const [instructorActiveCourses, setInstructorActiveCourses] = useState([]);
  useEffect(async () => {
    await  profileAPI.getInstructorCourse().then(res =>{
      console.log(res.data);
      setInstructorActiveCourses(res.data)
    })
    }, []);

  return (
    <div className="tab-pane fade" id="nav-courses" role="tabpanel">
      <div className="crse_content">
        <h3>My courses {instructorActiveCourses.length}</h3>
        <div className="_14d25">
          <div className="row">
            {instructorActiveCourses? instructorActiveCourses.map((course) => (
              <div className="col-lg-3 col-md-4">
                <div className="fcrse_1 mt-30" key={course.id}>
                  <a href="course_detail_view.html" className="fcrse_img">
                    <img src="images/courses/img-1.jpg" alt="" />
                    <div className="course-overlay">
                      <div className="badge_seller">{course.title}</div>
                      <div className="crse_reviews">
                        <i className="uil uil-star"></i>4.5
                      </div>
                      <span className="play_btn1">
                        <i className="uil uil-play"></i>
                      </span>
                      <div className="crse_timer">25 hours</div>
                    </div>
                  </a>
                  <div className="fcrse_content">
                    <div className="eps_dots more_dropdown">
                      <a href="#">
                        <i className="uil uil-ellipsis-v"></i>
                      </a>
                      <div className="dropdown-content">
                        <span>
                          <i className="uil uil-share-alt"></i>Share
                        </span>
                        <span>
                          <i className="uil uil-clock-three"></i>Save
                        </span>
                        <span>
                          <i className="uil uil-ban"></i>Not Interested
                        </span>
                        <span>
                          <i className="uil uil-windsock"></i>Report
                        </span>
                      </div>
                    </div>
                    <div className="vdtodt">
                      <span className="vdt14">109k views</span>
                      <span className="vdt14">15 days ago</span>
                    </div>
                    <a href="course_detail_view.html" className="crse14s">
                      {course.certificateCatgoryName}
                    </a>
                    <a href="#" className="crse-cate">
                       {course.categoryName}
                    </a>
                    <div className="auth1lnkprce">
                      <p className="cr1fot">
                        By <a href="#">John Doe</a>
                      </p>
                      <div className="prce142">$10</div>
                      <button className="shrt-cart-btn" title="cart">
                        <i className="uil uil-shopping-cart-alt"></i>
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            )): <></>}
          </div>
        </div>
      </div>
    </div>
  );
}
