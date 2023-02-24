import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom/cjs/react-router-dom.min';
import MuiLoading from '../LoadingIcon/MuiLoading';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';
import responsive from '../../js/responsiveCarousel';
import coursesDetailAPI from '../../api/coursesDetailAPI';

function ReviewsInHome() {
  const params = useParams();
  const [isLoading, setIsLoading] = useState(true);
  const [reviews, setReview] = useState([]);
  let content = <MuiLoading isLoading={isLoading} />;
  useEffect(() => {
    const fetchListReview = async () => {
      const review = await coursesDetailAPI.getReviewStudentHaveToday();
      setReview(review);
      setIsLoading(false);
    };
    fetchListReview();
  }, []);
  console.log(reviews);
  if (!isLoading) {
    content = (
      <div className="col-xl-12 col-lg-12">
        <div className="section3125 mt-30">
          <h4 className="item_title">What Our Student Have Today</h4>
          <div className="la5lo1">
            <Carousel className="owl-carousel Student_says owl-theme" responsive={responsive}>
              {/* <div className="owl-carousel Student_says owl-theme"> */}
              {reviews.data?.map((review) => (
                <div className="item" key={review.id}>
                  <div className="fcrse_4 mb-20">
                    <div className="say_content">
                      <p>"{review.content}"</p>
                    </div>
                    <div className="st_group">
                      <div className="stud_img">
                        <img src="images/left-imgs/img-4.jpg" alt="" />
                      </div>
                      <h4>
                        {review.enrollCourse.appUser.firstName}{' '}
                        {review.enrollCourse.appUser.lastName}
                      </h4>
                    </div>
                  </div>
                </div>
              ))}

              {/* </div> */}
            </Carousel>
            {/* <div className="owl-carousel Student_says owl-theme">
              <div className="item">
                <div className="fcrse_4 mb-20">
                  <div className="say_content">
                    <p>
                      "Donec ac ex eu arcu euismod feugiat. In venenatis bibendum nisi, in placerat
                      eros ultricies vitae. Praesent pellentesque blandit scelerisque. Suspendisse
                      potenti."
                    </p>
                  </div>
                  <div className="st_group">
                    <div className="stud_img">
                      <img src="images/left-imgs/img-4.jpg" alt="" />
                    </div>
                    <h4>Jassica William</h4>
                  </div>
                </div>
              </div>
              <div className="item">
                <div className="fcrse_4 mb-20">
                  <div className="say_content">
                    <p>
                      "Cras id enim lectus. Fusce at arcu tincidunt, iaculis libero quis, vulputate
                      mauris. Morbi facilisis vitae ligula id aliquam. Nunc consectetur malesuada
                      bibendum."
                    </p>
                  </div>
                  <div className="st_group">
                    <div className="stud_img">
                      <img src="images/left-imgs/img-1.jpg" alt="" />
                    </div>
                    <h4>Rock Smith</h4>
                  </div>
                </div>
              </div>
              <div className="item">
                <div className="fcrse_4 mb-20">
                  <div className="say_content">
                    <p>
                      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Class aptent taciti
                      sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos eros
                      ac, sagittis orci."
                    </p>
                  </div>
                  <div className="st_group">
                    <div className="stud_img">
                      <img src="images/left-imgs/img-7.jpg" alt="" />
                    </div>
                    <h4>Luoci Marchant</h4>
                  </div>
                </div>
              </div>
              <div className="item">
                <div className="fcrse_4 mb-20">
                  <div className="say_content">
                    <p>
                      "Nulla bibendum lectus pharetra, tempus eros ac, sagittis orci. Suspendisse
                      posuere dolor neque, at finibus mauris lobortis in. Pellentesque vitae laoreet
                      tortor."
                    </p>
                  </div>
                  <div className="st_group">
                    <div className="stud_img">
                      <img src="images/left-imgs/img-6.jpg" alt="" />
                    </div>
                    <h4>Poonam Sharma</h4>
                  </div>
                </div>
              </div>
              <div className="item">
                <div className="fcrse_4 mb-20">
                  <div className="say_content">
                    <p>
                      "Curabitur placerat justo ac mauris condimentum ultricies. In magna tellus,
                      eleifend et volutpat id, sagittis vitae est. Pellentesque vitae laoreet
                      tortor."
                    </p>
                  </div>
                  <div className="st_group">
                    <div className="stud_img">
                      <img src="images/left-imgs/img-3.jpg" alt="" />
                    </div>
                    <h4>Davinder Singh</h4>
                  </div>
                </div>
              </div>
            </div> */}
          </div>
        </div>
      </div>
    );
  }

  return <>{content}</>;
}
export default ReviewsInHome;
