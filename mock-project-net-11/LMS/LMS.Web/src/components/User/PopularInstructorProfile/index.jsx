import React, { useEffect, useState } from 'react';
import Carousel from 'react-multi-carousel';
import profileAPI from '../../../api/profileAPI';
import courseApi from '../../../api/courseAPI';
import responsiveCourse from '../../../js/responsiveCarouselCourse';
import PropTypes from 'prop-types';

PopularInstructorProfile.propTypes = {};
function PopularInstructorProfile(props) {
  const [popularInstructor, setPopularInstructor] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await profileAPI.getPopularInstructorProfile();
        const data = response.data;
        console.log(data);
        setPopularInstructor(data);
      } catch (error) {
        console.log('Fail to get popular instructor profile', error.message);
      }
    }
    fetchData();
  }, []);

  return (
    <div>
      <div className="section3125 mt-30">
        <h4 className="item_title">Popular Instructor</h4>
        <a href="#" className="see150">
          See all
        </a>
        <div className="la5lo1">
          <Carousel responsive={responsiveCourse}>
            {popularInstructor.map((popularInstructorItem) => (
              <div key={popularInstructorItem.id} className="item">
                <div className="fcrse_1 mb-20">
                  <div className="tutor_img">
                    <a href="instructor_profile_view.html">
                      <img src={popularInstructorItem.profileImageUrl} alt="" />
                    </a>
                  </div>
                  <div className="tutor_content_dt">
                    <div className="tutor150">
                      <a href="instructor_profile_view.html" className="tutor_name">
                        {popularInstructorItem.firstName} {popularInstructorItem.lastName}
                      </a>
                      <div className="mef78" title="Verify">
                        <i className="uil uil-check-circle"></i>
                      </div>
                    </div>
                    <div className="tutor_cate"> {popularInstructorItem.intro}</div>
                    <ul className="tutor_social_links">
                      <li>
                        <a href="#" className="fb">
                          <i className="fab fa-facebook-f"></i>
                        </a>
                      </li>
                      <li>
                        <a href="#" className="tw">
                          <i className="fab fa-twitter"></i>
                        </a>
                      </li>
                      <li>
                        <a href="#" className="ln">
                          <i className="fab fa-linkedin-in"></i>
                        </a>
                      </li>
                      <li>
                        <a href="#" className="yu">
                          <i className="fab fa-youtube"></i>
                        </a>
                      </li>
                    </ul>
                    <div className="tut1250">
                      <span className="vdt15">{popularInstructorItem.totalStudent} Students</span>
                      <span className="vdt15">{popularInstructorItem.totalCourse} Courses</span>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </Carousel>

          <div className="owl-carousel featured_courses owl-theme"></div>
        </div>
      </div>
    </div>
  );
}
export default PopularInstructorProfile;
