import React, { useEffect, useRef } from 'react';
import PropTypes from 'prop-types';
import CourseBasicInfor from '../../../components/Course/CreateCourse/CourseBasicInfor/CourseBasicInfor';
import CourseMedia from '../../../components/Course/CreateCourse/CourseMedia/CourseMedia';
import CoursePrice from '../../../components/Course/CreateCourse/CoursePrice/CoursePrice';
import { Route, Switch } from 'react-router-dom';
import { useState, useContext } from 'react';
import CourseFinish from './../../../components/Course/CreateCourse/CourseFinish/CourseFinish';
import courseApi from './../../../api/courseAPI';
import Curriculum from './../../../components/Course/CreateCourse/CourseCurriculum/Curriculum';
import AuthContext from '../../../../store/auth-context';

CreateCourse.propTypes = {

};

export default function CreateCourse(props) {
    let [step,setStep] = useState(1);
    let [content,setContent] = useState(<CourseBasicInfor />);
    let [createCourseId, setCreateCourseId] = useState(0);
    let context = useContext(AuthContext);
    /// fix here

    useEffect(() => {
        if(localStorage.getItem('createCourseId')){
            setCreateCourseId(localStorage.getItem('createCourseId'));
        }
        renderSwitch(step);
        activeTabStep();
    },[step])

    function renderSwitch(param) {
        switch (param) {
            case 1:
                setContent(<CourseBasicInfor isSuccess={ isCreateBasicSuccess } />);
                break;
            case 2:
                setContent(<Curriculum courseId={createCourseId} />);
                break;
            case 3:
                setContent(<CourseMedia isSuccess={ isCreateMediaSuccess } courseId={createCourseId} />);
                break;
            case 4:
                setContent(<CoursePrice isSuccess={ isCreatePriceSuccess } courseId={createCourseId} />);
                break;
            case 5:
                setContent(<CourseFinish />);
                break;
            default:
                setContent(<CourseBasicInfor isSuccess={ isCreateBasicSuccess } />);
        }
    }

    function activeTabStep() {
        let tab1 = document.getElementById('tab_step1');
        let tab2 = document.getElementById('tab_step2');
        let tab3 = document.getElementById('tab_step3');
        let tab4 = document.getElementById('tab_step4');
        let tab5 = document.getElementById('tab_step5');
        var arr = [tab1,tab2,tab3,tab4,tab5];
        switch (step) {
            case 1:
                arr.map((item, index) => (
                    index > 0 ? item.classList.remove('active') : item.classList.add('active')
                ))
                break;
            case 2:
                arr.map((item, index) => (
                    index > 1 ? item.classList.remove('active') : item.classList.add('active')
                ))
                break;
            case 3:
                arr.map((item, index) => (
                    index > 2 ? item.classList.remove('active') : item.classList.add('active')
                ))
                break;
            case 4:
                arr.map((item, index) => (
                    index > 3 ? item.classList.remove('active') : item.classList.add('active')
                ))
                break;    
            case 5:
                arr.map((item, index) => (
                    index > 4 ? item.classList.remove('active') : item.classList.add('active')
                ))
                break;   
            default:
                break;
        }
    }

    function goToTabStep(param) {
        if(param >= 1 && param <= 5) {
            setStep(param)
        }
    }

    async function nextEvent() {
        if(step < 5){
            switch (step) {
                case 1:
                    document.getElementById('btn_submit_basic_infor').click();
                    break;
                case 2:
                    setStep(step+=1);
                    break;
                case 3:
                    document.getElementById('btn_submit_media').click();
                    break;
                case 4:
                    document.getElementById('btn_submit_price').click();
                    break;
                default:
                    break;
            }
        }
    }

    function prevEvent() {
        if(step > 1){
            setStep(step-=1);
        }
    }

    function isCreateBasicSuccess(childData) {
        if(childData){
            setStep(step+=1);
        }
    }

    function isCreateMediaSuccess(childData) {
        if(childData){
            setStep(step+=1);
        }
    } 

    function isCreatePriceSuccess(childData) {
        if(childData){
            setStep(step+=1);
        }
    }

    async function submitEvent() {
        await courseApi.createCourseFinish(createCourseId).then(async res => {
            if(res.status == 200) {
                alert('Wizard Completed');
                setCreateCourseId(0);
                localStorage.removeItem('createCourseId');
            }
        })
    }

    return (
        <>
            <div className="wrapper">
                <div className="sa4d25">
                    <div className="container">
                        <div className="row">
                        <div className="col-lg-12">
                            <h2 className="st_title"><i className="uil uil-analysis" /> Create New Course</h2>
                        </div>
                        </div>
                        <div className="row">
                        <div className="col-12">
                            <div className="course_tabs_1">
                            <div id="add-course-tab" className="step-app">
                                <ul className="step-steps">
                                <li id="tab_step1">
                                    <a onClick={() => goToTabStep(1)}>
                                    <span className="number" />
                                    <span className="step-name">Basic</span>
                                    </a>
                                </li>
                                <li id="tab_step2">
                                    <a onClick={() => goToTabStep(2)}>
                                    <span className="number" />
                                    <span className="step-name">Curriculum</span>
                                    </a>
                                </li>
                                <li id="tab_step3">
                                    <a onClick={() => goToTabStep(3)}>
                                    <span className="number" />
                                    <span className="step-name">Media</span>
                                    </a>
                                </li>
                                <li id="tab_step4">
                                    <a onClick={() => goToTabStep(4)}>
                                    <span className="number" />
                                    <span className="step-name">Price</span>
                                    </a>
                                </li>
                                <li id="tab_step5">
                                    <a onClick={() => goToTabStep(5)}>
                                    <span className="number" />
                                    <span className="step-name">Publish</span>
                                    </a>
                                </li>
                                </ul>
                                <div className="step-content">
                                    {
                                       content
                                    }
                                    <div className="step-tab-panel step-tab-location" id="tab_step5">
                                        <div className="tab-from-content">
                                        <div className="title-icon">
                                            <h3 className="title"><i className="uil uil-upload" />Submit</h3>
                                        </div>
                                        </div>
                                        <div className="publish-block">
                                        <i className="far fa-edit" />
                                        <p>Your course is in a draft state. Students cannot view, purchase or enroll in this course. For students that are already enrolled, this course will not appear on their student Dashboard.</p>
                                        </div>
                                    </div>
                                </div>
                                <div className="step-footer step-tab-pager">
                                {
                                    step > 1 && <button data-direction="prev" className="btn btn-default steps_btn" onClick={prevEvent} >Previous</button>
                                }
                                {
                                    step < 5 && <button data-direction="next" className="btn btn-default steps_btn" onClick={nextEvent} type='button' id='btn_next'>Next</button>
                                }
                                {
                                    step == 5 && <button data-direction="finish" className="btn btn-default steps_btn" onClick={submitEvent}>Submit for Review</button>
                                }
                                </div>
                            </div>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}
