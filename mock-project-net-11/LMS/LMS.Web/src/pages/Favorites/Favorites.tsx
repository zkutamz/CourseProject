import { Button, Typography } from '@mui/material';
import moment from 'moment';
import React, { useEffect, useState } from 'react'
import ReactDOM from 'react-dom';
import { Link, useHistory } from 'react-router-dom';
import favoriteAPI from '../../api/favoriteAPI';
import MuiLoading from '../../components/LoadingIcon/MuiLoading';
import MuiSnackBar from '../../components/SnackBars/MuiSnackBar';
import SecondToHour from '../../js/secondToHour';
import FavoriteCourse from '../../model/FavoriteCourse/favoriteCourse';
import DeleteIcon from '@mui/icons-material/Delete';

const Favorites = () => {
    const [favorites, setFavorites] = useState<FavoriteCourse[]>([])
    const [isLoading, setIsLoading] = useState(true);
    const [deleteStatus, setDeleteStatus] = useState(false);
    const [deleteStatuses, setDeleteStatuses] = useState(false);
    const [error, setError] = useState(false);
    const history = useHistory();

    let content = <MuiLoading isLoading={isLoading} />;

    useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await favoriteAPI.getFavoritesAsync();

                if (response.status === 200) {
                    setFavorites(response.data.objects);
                    setIsLoading(false);
                }
            } catch (error: any) {
                setError(true);
                if (error.response) {
                    console.log(error.response);
                } else if (error.request) {
                    console.log(error.request);
                } else {
                    console.log(error);
                }
            }
        }

        fetchData();
    }, []);

    const removeHandler = async (courseId: number): Promise<any> => {
        try {
            setIsLoading(true);

            await favoriteAPI.deleteACourseFromFavoritesAsync(courseId);

            setFavorites(prev => prev.filter(f => f.course.id !== courseId));
            setIsLoading(false);
            setDeleteStatus(true);
        } catch (error: any) {
            setError(true);
            if (error.response) {
                console.log(error.response);
            } else if (error.request) {
                console.log(error.request);
            } else {
                console.log(error);
            }
        }
    };

    const removeAllHandler = async (): Promise<any> => {
        try {
            setIsLoading(true);

            await favoriteAPI.deleteCoursesFromFavoritesAsync();

            setFavorites([]);
            setIsLoading(false);
            setDeleteStatuses(true);
        } catch (error: any) {
            setError(true);
            if (error.response) {
                console.log(error.response);
            } else if (error.request) {
                console.log(error.request);
            } else {
                console.log(error);
            }
        }
    };

    if (!favorites && !error && !isLoading) {

    }

    if (!isLoading && error) {
        content = (
            <>
                {
                    ReactDOM.createPortal(
                        <>
                            <MuiSnackBar
                                open={error}
                                message={`Something went wrong, please try again later. Redirecting to previous page when closed.`}
                                severity='error'
                                onClose={() => { history.goBack() }}
                            />
                        </>
                        ,
                        document.getElementById('snack-bar')!
                    )
                }
            </>
        );
    }

    if (!isLoading && !error) {
        content = (
            <div className="sa4d25">
                {
                    ReactDOM.createPortal(
                        <>
                            <MuiSnackBar
                                open={deleteStatus}
                                message="Course removed from your favorites!"
                                severity='success'
                                onClose={() => { setDeleteStatus(false) }}
                            />
                            <MuiSnackBar
                                open={deleteStatuses}
                                message="All courses removed from your favorites!"
                                severity='success'
                                onClose={() => { setDeleteStatuses(false) }}
                            />
                        </>
                        ,
                        document.getElementById('snack-bar')!
                    )
                }
                <div className="container-fluid">
                    {
                        favorites.length > 0 && (
                            <div className="row">
                                <div className="col-lg-3 col-md-4 ">
                                    <div className="section3125 hstry142">
                                        <div className="grp_titles pt-0">
                                            <div className="ht_title">Saved Courses</div>
                                            <a href="#" onClick={removeAllHandler} className="ht_clr">Remove All</a>
                                        </div>
                                        <div className="tb_145">
                                            <div className="wtch125 text-center">
                                                <span className="vdt14">{favorites.length} Courses</span>
                                            </div>
                                            <Button
                                                variant='contained'
                                                color="error"
                                                className="rmv-btn w-100"
                                                startIcon={<DeleteIcon />}
                                                onClick={removeAllHandler}
                                            >
                                                Remove Favorites
                                            </Button>
                                        </div>
                                    </div>
                                </div>
                                <div className="col-md-9">
                                    <div className="_14d25 mb-20">
                                        <div className="row">
                                            <div className="col-md-12">
                                                <h4 className="mhs_title">Saved Courses</h4>
                                                {
                                                    favorites.map(f => (
                                                        <div key={f.id} className="fcrse_1 mb-30">
                                                            <a href="course_detail_view.html" className="hf_img">
                                                                <img src="images/courses/img-1.jpg" alt="" />
                                                                <div className="course-overlay">
                                                                    {f.course.isBestSeller ? <div className="badge_seller">Bestseller</div> : ''}
                                                                    <div className="crse_reviews">
                                                                        <i className="uil uil-star" />{f.course.averageRate}
                                                                    </div>
                                                                    <span className="play_btn1"><i className="uil uil-play" /></span>
                                                                    <div className="crse_timer">
                                                                        {SecondToHour(f.course.totalDuration)}
                                                                    </div>
                                                                </div>
                                                            </a>
                                                            <div className="hs_content">
                                                                <div className="eps_dots eps_dots10 more_dropdown">
                                                                    <a href="#"><i className="uil uil-ellipsis-v" /></a>
                                                                    <div className="dropdown-content">
                                                                        <span onClick={async () => await removeHandler(f.course.id)}><i className="uil uil-times" />Remove</span>
                                                                    </div>
                                                                </div>
                                                                <div className="vdtodt">
                                                                    <span className="vdt14">{f.course.viewCount} views</span>
                                                                    <span className="vdt14">{moment(f.course.updatedAt, moment.ISO_8601).fromNow()}</span>
                                                                </div>
                                                                <Link to={`courses/${f.course.id}`} className="crse14s title900">
                                                                    {f.course.title}
                                                                </Link>
                                                                <a href="#" className="crse-cate">{f.course.category.name}</a>
                                                                <div className="auth1lnkprce">
                                                                    <p className="cr1fot">By <Link to={`/profile/${f.course.appUser.id}`}>{f.course.appUser.fullName}</Link></p>
                                                                    <div className="prce142">${f.course.price}</div>
                                                                    <button className="shrt-cart-btn" title="cart"><i className="uil uil-shopping-cart-alt" /></button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    ))
                                                }
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )
                    }

                    {
                        favorites.length === 0 && (
                            <div className="mx-auto mt-50 text-center" style={{ height: '58.2vh' }}>
                                <Typography
                                    variant="h4"
                                    gutterBottom
                                >
                                    There is no favorite course yet
                                </Typography>
                                <Button
                                    variant="contained"
                                    color="info"
                                    href="/explore">
                                    Add one to yours now
                                </ Button>
                            </div>
                        )
                    }
                </div>
            </div >
        );
    }


    return content;
}

export default Favorites;