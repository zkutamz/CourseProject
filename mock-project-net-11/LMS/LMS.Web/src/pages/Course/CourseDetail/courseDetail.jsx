import FavoriteIcon from '@mui/icons-material/Favorite';
import FavoriteBorderIcon from '@mui/icons-material/FavoriteBorder';
import FlagIcon from '@mui/icons-material/Flag';
import { IconButton } from '@mui/material';
import moment from 'moment';
import { useContext, useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import { useHistory, useParams, Link, Prompt } from 'react-router-dom';
import courseApi from '../../../api/courseAPI';
import favoriteApi from '../../../api/favoriteAPI';
import userAPI from '../../../api/userAPI';
import BasicTabs from '../../../components/BasicTabs';
import CourseSectionList from '../../../components/Course/CourseSectionList/CourseSectionList';
import MuiLoading from '../../../components/LoadingIcon/MuiLoading';
import MuiSnackBar from '../../../components/SnackBars/MuiSnackBar';
import AuthContext from '../../../store/auth-context';
import Review from './Review/index';

const CourseDetail = () => {
    const params = useParams();
    const [course, setCourse] = useState([]);
    const [user, setUser] = useState({});
    const [notFound, setNotFound] = useState(false);
    const [error, setError] = useState(false);
    const [noRedirectError, setNoRedirectError] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [isAddedToFavorite, setIsAddedToFavorite] = useState(false);
    const [isDeletedFromFavorite, setIsDeletedFromFavorite] = useState(false);
    const [isVote, setIsVote] = useState(false);
    const [isUpVote, setIsUpVote] = useState(null);
    const [isDownVote, setIsDownVote] = useState(null);
    const [upVote, setUpVote] = useState(0);
    const [downVote, setDownVote] = useState(0);
    const [isFavorite, setIsFavorite] = useState(false);
    const history = useHistory();
    const authContext = useContext(AuthContext);

    let content = <MuiLoading isLoading={isLoading} />;

    useEffect(() => {
        try {
            const fetchData = async () => {
                var response = await courseApi.get(params.courseId);

                const data = response.data;

                if (response.statusCode === 200) {
                    setIsLoading(false);
                    setCourse(data);
                    setUser(data.appUser);
                    setUpVote(data.appUser.upVote);
                    setDownVote(data.appUser.downVote);
                    setIsFavorite(data.isFavorite);
                    setIsUpVote(data.hasUpVote);
                    setIsDownVote(data.hasDownVote);
                }
            }

            fetchData();
        } catch (error) {
            if (error.message.includes('404')) setNotFound(true);
            else setError(true);
        }
    }, []);

    const handleClose = () => {
        history.goBack();
    };

    const addToFavoriteHandler = async (event) => {
        event.preventDefault();

        try {
            const response = await favoriteApi.addToFavoriteCoursesAsync(course.id);

            if (response.data.statusCode === 201) {
                setIsFavorite(true);
                setIsAddedToFavorite(true);
            }
        } catch (error) {
            if (error.response) {
                console.log(error.response)
            }
            else if (error.request) {
                console.log(error.request);
            }
            else {
                console.log(error);
            }
            setNoRedirectError(error);
        }
    }

    const deleteFromFavoriteHandler = async (event) => {
        event.preventDefault();

        try {
            const response = await favoriteApi.deleteACourseFromFavoritesAsync(course.id);

            if (response.status === 204) {
                setIsFavorite(false);
                setIsDeletedFromFavorite(true);
            }
        } catch (error) {
            if (error.response) {
                console.log(error.response)
            }
            else if (error.request) {
                console.log(error.request);
            }
            else {
                console.log(error);
            }
            setNoRedirectError(error);
        }
    }

    const voteAUserHandler = async (event, vote) => {
        event.preventDefault();

        try {
            const response = await userAPI.voteAUser({
                userId: user.id,
                isUpVote: vote
            });

            if (response.data.statusCode === 204) {
                setIsVote(true);

                if (vote) {
                    setUpVote(prev => ++prev);
                    setDownVote(prev => --prev);
                    setIsUpVote(true);
                    setIsDownVote(false);
                    return;
                }

                setUpVote(prev => --prev);
                setDownVote(prev => ++prev);
                setIsUpVote(false);
                setIsDownVote(true);
            }
        } catch (error) {
            setNoRedirectError(true);
        }
    }

    if (!isLoading && course) {
        content = (
            <>
                {
                    ReactDOM.createPortal(
                        <>
                            <MuiSnackBar
                                open={isAddedToFavorite}
                                message='Course added to your favorites!'
                                severity='success'
                                onClose={() => { setIsAddedToFavorite(false) }} />
                            <MuiSnackBar
                                open={isDeletedFromFavorite}
                                message='Course delete from your favorites!'
                                severity='success'
                                onClose={() => { setIsDeletedFromFavorite(false) }} />
                            <MuiSnackBar
                                open={isVote}
                                message='Thank you for voting!'
                                severity='success'
                                onClose={() => { setIsVote(false); }} />
                        </>,
                        document.getElementById('snack-bar')
                    )
                }
                <div className="_215b01">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="section3125">
                                    <div className="row justify-content-center">
                                        <div className="col-xl-4 col-lg-5 col-md-6">
                                            <div className="preview_video">
                                                <a
                                                    href="#"
                                                    className="fcrse_img"
                                                    data-toggle="modal"
                                                    data-target="#videoModal"
                                                >
                                                    <img
                                                        src={course.thumbNailUrl}
                                                        alt=""
                                                    />
                                                    <div className="course-overlay">
                                                        <div className="badge_seller">Bestseller</div>
                                                        <span className="play_btn1">
                                                            <i className="uil uil-play" />
                                                        </span>
                                                        <span className="_215b02">Preview this course</span>
                                                    </div>
                                                </a>
                                            </div>
                                            <div className="_215b10 pt-4">
                                                {
                                                    authContext.isLoggedIn &&
                                                    <form method='post' onSubmit={isFavorite ? deleteFromFavoriteHandler : addToFavoriteHandler}>
                                                        <IconButton className="_215b11 text-white" type="submit">
                                                            {isFavorite ? <FavoriteIcon className='pr-md-2' /> : <FavoriteBorderIcon className='pr-md-2' />}
                                                            Save
                                                        </IconButton>
                                                    </form>
                                                }
                                                {
                                                    !authContext.isLoggedIn &&
                                                    <Link to="/sign-in">
                                                        <Prompt message="Register to add this course to your favorites courses list. Proceed?" />
                                                        <IconButton className="_215b11 text-white" type="submit">
                                                            {course.isFavorite ? <FavoriteIcon className='pr-md-2' /> : <FavoriteBorderIcon className='pr-md-2' />}
                                                            Save
                                                        </IconButton>
                                                    </Link>
                                                }
                                                <IconButton className="_215b12 text-white">
                                                    <FlagIcon className='pr-md-2' />
                                                    Report abuse
                                                </IconButton>
                                            </div>
                                        </div>
                                        <div className="col-xl-8 col-lg-7 col-md-6">
                                            <div className="_215b03">
                                                <h2>{course.title}</h2>
                                                <span className="_215b04">{course.shortDescription}</span>
                                            </div>
                                            <div className="_215b05">
                                                <div className="crse_reviews mr-2">
                                                    <i className="uil uil-star" />
                                                    {course.rating}
                                                </div>
                                                ({course.totalRatings} ratings)
                                            </div>
                                            <div className="_215b05">{course.totalEnrolled} students enrolled</div>
                                            <div className="_215b06">
                                                <div className="_215b07">
                                                    <span>
                                                        <i className="uil uil-comment" />
                                                    </span>
                                                    <span>{course.language ? course.language : 'N/A'}</span>
                                                </div>
                                                <div className="_215b08">
                                                    <span>
                                                        <i className="uil uil-closed-captioning" />
                                                    </span>
                                                    {/* <span>
                            English, Dutch
                            <span className="caption_tooltip">
                              12 more
                              <span className="caption-content">
                                <span>French</span>
                                <span>Hindi</span>
                                <span>German [Auto-generated]</span>
                                <span>Indonesian [Auto-generated]</span>
                                <span>Italian [Auto-generated]</span>
                                <span>Japanese [Auto-generated]</span>
                                <span>Korean</span>
                                <span>Polish</span>
                                <span>Portuguese [Auto-generated]</span>
                                <span>Spanish [Auto-generated]</span>
                                <span>Traditional Chinese</span>
                                <span>Turkish [Auto-generated]</span>
                              </span>
                            </span>
                          </span> */}
                                                    <span>{course.language ? course.language : 'N/A'}</span>
                                                </div>
                                            </div>
                                            <div className="_215b05">Last updated {moment(course.updatedAt, moment.ISO_8601)._d.toDateString()}</div>
                                            <div className="mt-2 text-white">
                                                <h3>${course.price}</h3>
                                            </div>
                                            <ul className="_215b31">
                                                {
                                                    authContext.isLoggedIn && <>
                                                        <li>
                                                            <button className="btn_adcart">Add to Cart</button>
                                                        </li>
                                                        <li>
                                                            <button className="btn_buy">Buy Now</button>
                                                        </li>
                                                    </>
                                                }
                                                {
                                                    !authContext.isLoggedIn && <>
                                                        <li>
                                                            <Link to="/sign-in">
                                                                <Prompt message="Register to add this course to your cart. Proceed?" />
                                                                <button className="btn_adcart">Add to Cart</button>
                                                            </Link>
                                                        </li>
                                                        <li>
                                                            <Link to="/sign-in">
                                                                <Prompt message="Register to buy this course. Proceed?" />
                                                                <button className="btn_buy">Buy Now</button>
                                                            </Link>
                                                        </li>
                                                    </>
                                                }
                                            </ul>
                                            <div className="_215fgt1">30-Day Money-Back Guarantee</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="_215b15 _byt1458">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="user_dt5">
                                    <div className="user_dt_left">
                                        <div className="live_user_dt">
                                            <div className="user_img5">
                                                <Link to={`/profile/${user.id}`}>
                                                    <img src={user.profileImageUrl} alt="User's Profile Image" />
                                                </Link>
                                            </div>
                                            <div className="user_cntnt">
                                                <a href="#" className="_df7852">
                                                    {user.firstName} {user.lastName}
                                                </a>
                                                {
                                                    authContext.isLoggedIn &&
                                                    <form method='post' >
                                                        <button className="subscribe-btn">Subscribe</button>
                                                    </form>
                                                }
                                                {
                                                    !authContext.isLoggedIn &&
                                                    <Link to="/sign-in">
                                                        <Prompt message="Register to subscribe to this instructor. Proceed?" />
                                                        <form method='post' >
                                                            <button className="subscribe-btn">Subscribe</button>
                                                        </form>
                                                    </Link>
                                                }
                                            </div>
                                        </div>
                                    </div>
                                    <div className="user_dt_right">
                                        <ul>
                                            <li>
                                                <IconButton >
                                                    <i className="uil uil-eye" />
                                                    <span>{user.profileViewCount}</span>
                                                </IconButton>
                                            </li>
                                            <li>
                                                {
                                                    authContext.isLoggedIn &&
                                                    <form method='post' onSubmit={(event) => { voteAUserHandler(event, true) }}>
                                                        {
                                                            isUpVote === true ?
                                                                <IconButton type="submit" disabled={true}>
                                                                    <i className="uil uil-thumbs-up" />
                                                                    <span>{upVote}</span>
                                                                </IconButton>
                                                                :
                                                                <IconButton type="submit" >
                                                                    <i className="uil uil-thumbs-up" />
                                                                    <span>{upVote}</span>
                                                                </IconButton>
                                                        }
                                                    </form>
                                                }
                                                {
                                                    !authContext.isLoggedIn &&
                                                    <Link to="/sign-in">
                                                        <Prompt message={(location) => location.pathname === '/sign-in' ? "Register to vote this instructor. Proceed?" : true} />
                                                        <IconButton type="submit" >
                                                            <i className="uil uil-thumbs-up" />
                                                            <span>{upVote}</span>
                                                        </IconButton>
                                                    </Link>
                                                }
                                            </li>
                                            <li>
                                                {
                                                    authContext.isLoggedIn &&
                                                    <form method='post' onSubmit={(event) => { voteAUserHandler(event, false) }} >
                                                        {
                                                            isDownVote ?
                                                                <IconButton type="submit" disabled={true}>
                                                                    <i className="uil uil-thumbs-down" />
                                                                    <span>{downVote}</span>
                                                                </IconButton>
                                                                :
                                                                <IconButton type="submit">
                                                                    <i className="uil uil-thumbs-down" />
                                                                    <span>{downVote}</span>
                                                                </IconButton>
                                                        }
                                                    </form>
                                                }
                                                {
                                                    !authContext.isLoggedIn &&
                                                    <Link to="/sign-in">
                                                        <Prompt message="Register to vote this instructor. Proceed?" />
                                                        <IconButton type="submit" >
                                                            <i className="uil uil-thumbs-down" />
                                                            <span>{upVote}</span>
                                                        </IconButton>
                                                    </Link>
                                                }
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div className="course_tabs">
                                    <nav>
                                        <BasicTabs
                                            labelOne='About'
                                            itemOne={
                                                <div className="_htg451">
                                                    <div className="_htg452">
                                                        <h3 className="mb-2">Requirements</h3>
                                                        {course.requirement}
                                                    </div>
                                                    <div className="_htg452 mt-35">
                                                        <h3>Description</h3>
                                                        <p>{course.description}</p>
                                                    </div>
                                                    <div className="_htg452 mt-35">
                                                        <h3>Who this course is for :</h3>
                                                        <ul className="_abc124">
                                                            <li>
                                                                <span className="_5f7g11">
                                                                    This course is for anyone who wants to learn about web development,
                                                                    regardless of previous experience
                                                                </span>
                                                            </li>
                                                            <li>
                                                                <span className="_5f7g11">
                                                                    It's perfect for complete beginners with zero experience
                                                                </span>
                                                            </li>
                                                            <li>
                                                                <span className="_5f7g11">
                                                                    It's also great for anyone who does have some experience in a few of
                                                                    the technologies(like HTML and CSS) but notFound all
                                                                </span>
                                                            </li>
                                                            <li>
                                                                <span className="_5f7g11">
                                                                    If you want to take ONE COURSE to learn everything you need to know
                                                                    about web development, take this course
                                                                </span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                    <div className="_htgdrt mt-35">
                                                        <h3>What you'll learn</h3>
                                                        <div className="_scd123">
                                                            <p>{course.whatLearn}</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            }
                                            labelTwo='Course Content'
                                            itemTwo={<CourseSectionList courseId={params.courseId} courseDuration={course.totalDuration} />}
                                            labelThree='Reviews'
                                            itemThree={<Review />}
                                        />
                                    </nav>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </>
        );
    }

    return (
        <>
            {
                notFound && !error &&
                ReactDOM.createPortal(
                    <MuiSnackBar
                        open={notFound}
                        message={`The course with the id of ${params.courseId} doesn't exist. Redirecting to previous page when closed.`}
                        severity='info'
                        onClose={handleClose}
                    />,
                    document.getElementById('snack-bar')
                )
            }
            {
                !notFound && error &&
                ReactDOM.createPortal(
                    <MuiSnackBar
                        open={error}
                        message={`Something went wrong, please try again later. Redirecting to previous page when closed.`}
                        severity='error'
                        onClose={handleClose}
                    />,
                    document.getElementById('snack-bar')
                )
            }
            {
                !notFound && noRedirectError &&
                ReactDOM.createPortal(
                    <MuiSnackBar
                        open={noRedirectError}
                        message={`Something went wrong, please try again later.`}
                        severity='error'
                        onClose={() => { setNoRedirectError(false) }}
                    />,
                    document.getElementById('snack-bar')
                )
            }
            {!notFound && !error && content}
        </>
    );
};

export default CourseDetail;