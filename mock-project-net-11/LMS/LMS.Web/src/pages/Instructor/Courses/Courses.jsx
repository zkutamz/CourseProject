import React,{ useEffect, useState } from 'react' 
import CoursesList from './CoursesList/CoursesList';
import courseManagementAPI from '../../../api/courseManagementAPI';
import PurchasesList from './PurchasesList/PurchasesList';
import UpcomingCoursesList from './UpcomingCoursesList/UpcomingCoursesList'
import DiscountList from './Discount/DiscountList'
import { Nav, NavLink,TabPane,TabContainer,TabContent } from 'react-bootstrap';
import Promotion  from './Promotions/Promotion'


const Courses = () => {
    const [courses, setCourses] = useState([]);
    const [coursePurchases,setCoursePurchases] = useState([]);
    const [coursePedings,setcoursePedings] = useState([]);
    const [discount, setDiscount] = useState([]);

  useEffect(async () => {
    var response = await courseManagementAPI.getAllActiveCourseOfInstructor();
    const data = response.data;
    setCourses(data);
    console.log(data);
    response = await courseManagementAPI.getAllPurchaseCourseOfInstructor();
    setCoursePurchases(response.data.objects);
    console.log(response.data.objects[0].enrollCourses[0].id);
    response = await courseManagementAPI.getAllPendingCourseOfInstructor();
    setcoursePedings(response.data);

    response = await courseManagementAPI.getAllDiscountCourseOfInstructor();
    setDiscount(response.data);

  }, []);
    return (
        <div className="sa4d25">
            <div className="container-fluid">
                <div className="row">
                    <div className="col-lg-12">
                        <h2 className="st_title"><i className="uil uil-book-alt" />Courses</h2>
                    </div>
                    <div className="col-md-12">
                        <div className="card_dash1">
                            <div className="card_dash_left1">
                                <i className="uil uil-book-alt" />
                                <h1>Jump Into Course Creation</h1>
                            </div>
                            <div className="card_dash_right1">
                                <button className="create_btn_dash" onclick="window.location.href = 'create_new_course.html';">Create Your
                                    Course</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div className='row'>
                <div className="col-md-12">
                    <div className="my_courses_tabs">
                        <TabContainer defaultActiveKey='pills-my-courses-tab'>
                        <Nav variant='pills' className="nav nav-pills my_crse_nav">
                                <Nav.Item >
                                    <Nav.Link eventKey='pills-my-courses-tab'><a className="nav-link"  id="pills-my-courses-tab" data-toggle="pill" href="#pills-my-courses" role="tab" aria-controls="pills-my-courses" aria-selected="true"><i className="uil uil-book-alt" />My Courses</a></Nav.Link>
                                </Nav.Item>

                                <Nav.Item>
                                    <Nav.Link eventKey='pills-my-purchases-tab'><a className="nav-link" id="pills-my-purchases-tab" data-toggle="pill" href="#pills-my-purchases" role="tab" aria-controls="pills-my-purchases" aria-selected="false"><i className="uil uil-download-alt" />My Purchases</a></Nav.Link>
                                </Nav.Item>

                                <Nav.Item>
                                    <Nav.Link eventKey='pills-upcoming-courses-tab'> <a className="nav-link" id="pills-upcoming-courses-tab" data-toggle="pill" href="#pills-upcoming-courses" role="tab" aria-controls="pills-upcoming-courses" aria-selected="false"><i className="uil uil-upload-alt" />Upcoming Courses</a></Nav.Link>
                                </Nav.Item>

                                    <Nav.Item>
                                    <Nav.Link eventKey='pills-discount-tab'><a className="nav-link" id="pills-discount-tab" data-toggle="pill" href="#pills-discount" role="tab" aria-controls="pills-discount" aria-selected="false"><i className="uil uil-tag-alt" />Discounts</a></Nav.Link>
                                </Nav.Item>  

                                    <Nav.Item>
                                    <NavLink eventKey='pills-promotions-tab'><a className="nav-link" id="pills-promotions-tab" data-toggle="pill" href="#pills-promotions" role="tab" aria-controls="pills-promotions" aria-selected="false"><i className="uil uil-megaphone" />Promotions</a></NavLink>
                                </Nav.Item>
                        </Nav>
                        <div class="tab-content" id="pills-tabContent">
                        <TabContent >
                            <TabPane eventKey='pills-my-courses-tab'>
                                <CoursesList courses={courses}></CoursesList>
                            </TabPane>
                            <TabPane eventKey='pills-my-purchases-tab'>
                               
                                <PurchasesList coursesPurchase={coursePurchases}></PurchasesList>
                            </TabPane>
                            <TabPane eventKey='pills-upcoming-courses-tab'>
                                <UpcomingCoursesList ></UpcomingCoursesList>
                            </TabPane>
                            <TabPane eventKey='pills-discount-tab'>
                                <DiscountList DiscountList={discount}></DiscountList>
                            </TabPane>
                            <TabPane eventKey='pills-promotions-tab'>
                                <Promotion></Promotion>
                            </TabPane>
                        </TabContent>
                        </div>
                        </TabContainer>
                    
                    </div>
                </div>
            </div>
        </div>
        </div>
    )
}

export default Courses;