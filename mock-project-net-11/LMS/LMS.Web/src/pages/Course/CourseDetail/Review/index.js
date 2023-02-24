import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom/cjs/react-router-dom.min';
import coursesDetailAPI from '../../../../api/coursesDetailAPI';
import ReactStars from 'react-stars';
import moment from 'moment';
import MuiLoading from '../../../../components/LoadingIcon/MuiLoading';
import SearchReview from './searchReview';
import queryString from 'query-string';
import Pagination from '../../../../components/Pagination/Pagination';

function Review() {
  const params = useParams();
  const [reviews, setReview] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [currentDate, setCurrentDate] = useState('');
  const [ratingAverage, setRatingAverage] = useState();
  const [ratingLevel, setRatingLevel] = useState([]);
  const [filters, setFilters] = useState({ PageNumber: 1, PageSize: 1 }); //search
  const [pagination, setPagination] = useState({
    currentPage: 1,
    PageSize: 2,
    totalCount: 1,
  });

  let content = <MuiLoading isLoading={isLoading} />;
  useEffect(() => {
    const fetchListReview = async () => {
      const paramsString = queryString.stringify(filters);

      if (filters.search === '' || filters.search === undefined) {
        const commentList = await coursesDetailAPI.getAllReviewByCoursesId(
          params.courseId,
          paramsString
        );

        setReview(commentList.data);
        console.log('reviews11', commentList);
        setPagination(commentList.data);
      } else {
        const requestUrl = await coursesDetailAPI.searchReviewByContent(paramsString);
        setReview(requestUrl.data.data);
        console.log('search', requestUrl);
        setPagination(requestUrl.data.data);
      }
      setIsLoading(false);
    };
    fetchListReview();
  }, [filters]);

  useEffect(() => {
    const fetchListReviewAverage = async () => {
      const reviewAve = await coursesDetailAPI.getRatingAverage(1);
      setRatingAverage(reviewAve.data);
      setIsLoading(false);
    };
    fetchListReviewAverage();
  }, []);

  useEffect(() => {
    const fetchListReviewLevel = async () => {
      const reviewLevel = await coursesDetailAPI.getRatingLevel(1);
      setRatingLevel(reviewLevel);
      setIsLoading(false);
    };
    fetchListReviewLevel();
  }, []);

  useEffect(() => {
    var date = new Date().getDate(); //Current Date
    var month = new Date().getMonth() + 1; //Current Month
    var year = new Date().getFullYear(); //Current Year
    var hours = new Date().getHours(); //Current Hours
    var min = new Date().getMinutes(); //Current Minutes
    var sec = new Date().getSeconds(); //Current Seconds

    setCurrentDate(date + '-' + month + '-' + year + ' ' + hours + ':' + min);
  });

  function handlePageChange(newPage) {
    console.log(newPage);
    setFilters({
      ...filters,
      PageNumber: newPage,
    });
  }
  //get Difference In Hours
  const getDifferenceInHours = (date1, date2) => {
    const diffInMs = Math.abs(date2 - date1);
    return diffInMs / (1000 * 60 * 60 * 24);
  };

  //get total Rating
  var ratingValue = 0;
  let getTotalRating = ratingLevel.data?.map((d) => {
    ratingValue = ratingValue + d;
  });
  //get % rating

  const handlePercentRating = (value) => {
    return ((value * 100) / ratingValue).toFixed(1);
  };

  function handleFiltersChange(newFilters) {
    console.log(filters);
    setFilters({
      ...filters,
      PageNumber: 1,
      search: newFilters.searchTerm,
    });
  }

  if (!isLoading) {
    content = (
      <div className="_215b17">
        <div className="container-fluid">
          <div className="row">
            <div className="col-lg-12">
              <div className="course_tab_content">
                <div className="tab-content" id="nav-tabContent">
                  <div className="tab-pane fade show active" id="nav-reviews" role="tabpanel">
                    <div className="student_reviews">
                      <div className="row">
                        <div className="col-lg-5">
                          <div className="reviews_left">
                            <h3>Student Feedback</h3>
                            <div className="total_rating">
                              <div className="_rate001">{ratingAverage}</div>
                              <ReactStars
                                count={5}
                                value={ratingAverage}
                                size={24}
                                edit={false}
                                color2={'#f2b01e'}
                              />
                              <div className="_rate002">Course Rating</div>
                            </div>
                            <div className="_rate003">
                              {ratingLevel.data?.map((rating, idx) => (
                                <div className="_rate004" key={idx}>
                                  <div className="progress progress1">
                                    <div
                                      className="progress-bar"
                                      style={{ flex: handlePercentRating(rating) / 100 }}
                                      role="progressbar"
                                      aria-valuemin={0}
                                      aria-valuemax={100}
                                    />
                                  </div>
                                  <ReactStars
                                    count={5}
                                    value={idx + 1}
                                    size={24}
                                    edit={false}
                                    color2={'#f2b01e'}
                                  />
                                  <div className="_rate002">
                                    {handlePercentRating(rating)}% - {rating}
                                  </div>
                                </div>
                              ))}
                            </div>
                          </div>
                        </div>
                        <div className="col-lg-7">
                          <div className="review_right">
                            <div className="review_right_heading">
                              <h3>Reviews</h3>
                              <SearchReview onSubmit={handleFiltersChange} />
                            </div>
                          </div>
                          <div className="review_all120">
                            {reviews.objects?.map((review) => (
                              <div className="review_item" key={review.id}>
                                <div className="review_usr_dt">
                                  <img src="/images/left-imgs/img-1.jpg" alt="" />
                                  <div className="rv1458">
                                    <h4 className="tutor_name1">
                                      {review.enrollCourse.appUser.firstName} &nbsp;
                                      {review.enrollCourse.appUser.lastName}
                                    </h4>

                                    <span className="time_145">
                                      {' '}
                                      {moment
                                        .duration(
                                          -(
                                            getDifferenceInHours(
                                              new Date(
                                                moment(review.updatedAt).format('YYYY-MM-DD HH:mm')
                                              ),
                                              new Date()
                                            ) * 24
                                          ),
                                          'hours'
                                        )
                                        .humanize(true)}
                                    </span>
                                  </div>
                                </div>
                                <div className="rating-box mt-20">
                                  {/* {reviews.data?.map((item) => (
                                  <span className="rating-star full-star" key={review.id} />
                                ))} */}

                                  <ReactStars
                                    count={5}
                                    value={review.rating}
                                    size={24}
                                    edit={false}
                                    color2={'#ffd700'}
                                  />
                                  {/* <span className="rating-star full-star" />
                                <span className="rating-star full-star" />
                                <span className="rating-star full-star" />
                                <span className="rating-star full-star" />
                                <span className="rating-star half-star" /> */}
                                </div>
                                <p className="rvds10">{review.content}</p>
                                <div className="rpt100">
                                  <span>Was this review helpful?</span>
                                  <div className="radio--group-inline-container">
                                    <div className="radio-item">
                                      <input id="radio-1" name="radio" type="radio" />
                                      <label htmlFor="radio-1" className="radio-label">
                                        Yes
                                      </label>
                                    </div>
                                    <div className="radio-item">
                                      <input id="radio-2" name="radio" type="radio" />
                                      <label htmlFor="radio-2" className="radio-label">
                                        No
                                      </label>
                                    </div>
                                  </div>
                                  <a href="#" className="report145">
                                    Report
                                  </a>
                                </div>
                              </div>
                            ))}
                          </div>
                          <Pagination pagination={pagination} onPageChange={handlePageChange} />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }

  return <>{content}</>;
}
export default Review;
