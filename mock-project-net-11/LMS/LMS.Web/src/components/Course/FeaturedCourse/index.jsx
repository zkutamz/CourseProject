import { useEffect, useState } from "react";
import React from 'react';
import courseApi from "../../../api/courseAPI";
import Carousel from "react-multi-carousel";
import responsiveCourse from "../../../js/responsiveCarouselCourse";
import moment from "moment";
import { Link } from "react-router-dom";

FeaturedCourse.propTypes = {};
function FeaturedCourse(props) {
    const [course, setCourse] = useState([]);
    const [appUser, setAppUser] = useState([]);
    const [category, setCategory] = useState([]);

    useEffect(() => {
        fetchData();
    }, []);

    async function fetchData() {
        try {
            let response = await courseApi.getFeaturedCourse();
            const data = response.data;
            setCourse(data);
            setAppUser(data.appUserDTOs);
            setCategory(data.categoryDTOs)
        }
        catch (error) {
            console.log("Something wrong: " + error);
        }
    }

    return (
        <>
            <div className="section3125 mt-50">
                <h4 className="item_title">Featured Courses</h4>
                <a href="#" className="see150">See all</a>
                <div className="la5lo1">
                    <Carousel responsive={responsiveCourse}>
                        {course?.map((courseItem) => (
                            <div className="item" key={courseItem.id}>
                                <div className="fcrse_1 mb-20">
                                    <Link to={`courses/${courseItem.id}`} className="fcrse_img">
                                        <img src={courseItem.thumbNailUrl} alt="" />
                                        <div className="course-overlay">
                                            <div className="badge_seller">Bestseller</div>
                                            <div className="crse_reviews">
                                                <i className="uil uil-star" />{courseItem.averageRate}
                                            </div>
                                            <span className="play_btn1"><i className="uil uil-play" /></span>
                                            <div className="crse_timer">
                                                {Math.round(courseItem.totalDuration / 3600)} hours
                                            </div>
                                        </div>
                                    </Link>
                                    <div className="fcrse_content">
                                        <div className="eps_dots more_dropdown">
                                            <a href="#"><i className="uil uil-ellipsis-v" /></a>
                                            <div className="dropdown-content">
                                                <span><i className="uil uil-share-alt" />Share</span>
                                                <span><i className="uil uil-heart" />Save</span>
                                                <span><i className="uil uil-ban" />Not Interested</span>
                                                <span><i className="uil uil-windsock" />Report</span>
                                            </div>
                                        </div>
                                        <div className="vdtodt">
                                            <span className="vdt14">{courseItem.viewCount} views</span>
                                            <span className="vdt14">{moment(courseItem.createdAt, moment.ISO_8601).fromNow()}</span>
                                        </div>
                                        <Link to={`courses/${courseItem.id}`} className="crse14s">{courseItem.title}</Link>
                                        <Link to={`courses/${courseItem.id}`} className="crse-cate">{category?.map((cate) => { <p>{cate.name} | </p> })}</Link>
                                        <div className="auth1lnkprce">
                                            <p className="cr1fot">By <a href="#">{appUser?.userName}</a></p>
                                            <div className="prce142">${courseItem.price}</div>
                                            <button className="shrt-cart-btn" title="cart"><i className="uil uil-shopping-cart-alt" /></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </Carousel>
                </div>
            </div>
        </>
    )
}

export default FeaturedCourse;