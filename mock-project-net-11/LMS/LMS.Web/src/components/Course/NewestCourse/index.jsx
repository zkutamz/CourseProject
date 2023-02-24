import { useEffect, useState } from 'react';
import Carousel from 'react-multi-carousel';
import { Link } from 'react-router-dom';
import courseApi from '../../../api/courseAPI';
import responsiveCourse from '../../../js/responsiveCarouselCourse';

NewestCourse.propTypes = {};
function NewestCourse(props) {
  const [course, setCourse] = useState([]);
  const [test, setTest] = useState({});
  const test1 = [{ id: 1 }, { id: 2 }, { id: 3 }];

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await courseApi.getNewestCourses();
        const data = response.data;
        setCourse(data);
      } catch (error) {
        console.log('Fail to get newest course', error.message);
      }
    }
    fetchData();
  }, []);

  return (
    <div>
      <div className="section3125 mt-30">
        <h4 className="item_title">Newest Courses</h4>
        <a href="#" className="see150">
          See all
        </a>
        <div className="la5lo1">
          <Carousel responsive={responsiveCourse}>
            {course.map((courseItem) => (
              <div key={courseItem.id} className="item">
                <div className="fcrse_1 mb-20">
                  <Link to={`courses/${courseItem.id}`} className="fcrse_img">
                    <img src={courseItem.thumbNailUrl} alt="" />
                    <div className="course-overlay">
                      <span className="play_btn1">
                        <i className="uil uil-play" />
                      </span>
                      <div className="crse_timer">{Math.round(courseItem.totalDuration / 3600)} hours</div>
                    </div>
                  </Link>
                  <div className="fcrse_content">
                    <div className="eps_dots more_dropdown">
                      <a href="#">
                        <i className="uil uil-ellipsis-v" />
                      </a>
                      <div className="dropdown-content">
                        <span>
                          <i className="uil uil-share-alt" />
                          Share
                        </span>
                        <span>
                          <i className="uil uil-heart" />
                          Save
                        </span>
                        <span>
                          <i className="uil uil-ban" />
                          Not Interested
                        </span>
                        <span>
                          <i className="uil uil-windsock" />
                          Report
                        </span>
                      </div>
                    </div>
                    <div className="vdtodt">
                      <span className="vdt14">{courseItem.viewCount} views</span>
                      <span className="vdt14">10 min ago</span>
                    </div>
                    <Link to={`courses/${courseItem.id}`} className="crse14s">
                      {courseItem.title}
                    </Link>
                    <a href="#" className="crse-cate">
                      Development | CSS
                    </a>
                    <div className="auth1lnkprce">
                      <p className="cr1fot">
                        By <Link to="profile/1">John Doe</Link>
                      </p>
                      <div className="prce142">${courseItem.price}</div>
                      <button className="shrt-cart-btn" title="cart">
                        <i className="uil uil-shopping-cart-alt" />
                      </button>
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

export default NewestCourse;
