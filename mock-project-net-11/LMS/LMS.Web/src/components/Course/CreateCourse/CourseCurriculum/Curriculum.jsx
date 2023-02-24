import React, { useEffect, useRef } from 'react';
import SectionForm from '../../../Section/sectionForm';
import { useState } from 'react';
import SectionEditForm from './../../../Section/sectionEditForm';
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';
import { Assignment } from '../../../Assignment/Assignment';
import AddQuiz from '../../../Quiz/AddQuiz/AddQuiz';
import AddLesson from './../../../Lesson/AddLesson/AddLesson';

Curriculum.propTypes = {

};

export default function Curriculum(props) {
    let [toggleSectionNew, setToggleNewSectionNew] = useState(false);
    let [togglSectionEdit, setToggleSectionEdit] = useState(false);
    let [addContent, setAddContent] = useState();

    function toggleNewSection() {
        setToggleNewSectionNew(!toggleSectionNew);
    }

    function toggleEditSection() {
        setToggleSectionEdit(!togglSectionEdit);
    }

    function addHandle(param) {
        switch (param) {
            case 1:
                setAddContent(<AddLesson />);
                break;
            case 2:
                setAddContent(<AddQuiz />);
                break;
            case 3:
                setAddContent(<Assignment />);
                break;
            default:
                break;
        }
    }

    return (
        <>
        {/* <Popup trigger={<button> Trigger</button>} position="right center" className='popup-content popup-arrow'>
            <Assignment />
        </Popup> */}
            <div className="step-tab-panel step-tab-gallery active" id="tab_step2">
                <div className="tab-from-content">
                    <div className="title-icon">
                        <h3 className="title"><i className="uil uil-notebooks" />Curriculum</h3>
                    </div>
                    <div className="curriculum-section">
                        <div className="row">
                        <div className="col-md-12">
                            <div className="curriculum-add-item">
                            <h4 className="section-title mt-0"><i className="fas fa-th-list mr-2" />Curriculum</h4>
                            <button className="main-btn color btn-hover ml-left add-section-title" data-toggle="modal" data-target="#add_section_model" onClick={toggleNewSection}>New Section</button>
                            {
                                toggleSectionNew && <SectionForm courseId={props.courseId} />
                            }
                            
                            </div>
                            <div className="added-section-item mb-30">
                            <div className="section-header">
                                <h4><i className="fas fa-bars mr-2" />Introduction</h4>
                                <div className="section-edit-options">
                                <button className="btn-152" type="button" data-toggle="collapse" data-target="#edit-section"><i className="fas fa-edit" onClick={toggleEditSection} /></button>
                                <button className="btn-152" type="button"><i className="fas fa-trash-alt" /></button>
                                </div>
                            </div>
                            <div id="edit-section" className="collapse">
                                {
                                    togglSectionEdit && <SectionEditForm />
                                }
                            </div>
                            <div className="section-group-list sortable">
                                <div className="section-list-item">
                                <div className="section-item-title">
                                    <i className="fas fa-file-alt mr-2" />
                                    <span className="section-item-title-text">lecture Title</span>
                                </div>
                                <button type="button" className="section-item-tools"><i className="fas fa-edit" /></button>
                                <button type="button" className="section-item-tools"><i className="fas fa-trash-alt" /></button>
                                <button type="button" className="section-item-tools ml-auto"><i className="fas fa-bars" /></button>
                                </div>
                                <div className="section-list-item">
                                <div className="section-item-title">
                                    <i className="fas fa-stream mr-2" />
                                    <span className="section-item-title-text">Quiz Title</span>
                                </div>
                                <button type="button" className="section-item-tools"><i className="fas fa-edit" /></button>
                                <button type="button" className="section-item-tools"><i className="fas fa-trash-alt" /></button>
                                <button type="button" className="section-item-tools ml-auto"><i className="fas fa-bars" /></button>
                                </div>
                                <div className="section-list-item">
                                <div className="section-item-title">
                                    <i className="fas fa-clipboard-list mr-2" />
                                    <span className="section-item-title-text">Assignment Title</span>
                                </div>
                                <button type="button" className="section-item-tools"><i className="fas fa-edit" /></button>
                                <button type="button" className="section-item-tools"><i className="fas fa-trash-alt" /></button>
                                <button type="button" className="section-item-tools ml-auto"><i className="fas fa-bars" /></button>
                                </div>
                            </div>
                            <div className="section-add-item-wrap p-3">
                                <button className="add_lecture" data-toggle="modal" data-target="#add_lecture_model" onClick={() => addHandle(1)}><i className="far fa-plus-square mr-2"  />Lecture</button>
                                <button className="add_quiz" data-toggle="modal" data-target="#add_quiz_model"  onClick={() => addHandle(2)}><i className="far fa-plus-square mr-2"/>Quiz</button>
                                <button className="add_assignment" data-toggle="modal" data-target="#add_assignment_model" onClick={() => addHandle(3)}><i className="far fa-plus-square mr-2" />Assignment</button>
                            </div>
                            </div>
                        </div>
                        </div>
                    </div>
                    {
                        addContent
                    }
                </div>
            </div>
        </>
    );
}
