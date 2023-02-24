import React from 'react';
import PropTypes from 'prop-types';
import * as Yup from 'yup';
import { validateYupSchema, useFormik } from 'formik';
import courseApi from './../../../../api/courseAPI';

CoursePrice.propTypes = {

};

function CoursePrice(props) {

    const formik = useFormik({
        initialValues: {
            id: props.courseId,
            price: 0,
            originalPrice: 0,
            requiredLogIn: false,
            requireEnroll: false
        },
        validationSchema: Yup.object({
            id: Yup.number()
                .required('Required'),
            price: Yup.number().required('Required'),
            originalPrice: Yup.number().required('Required')
        }),
        onSubmit: async values => {
            if(formik.isValid){
                console.log('Valid OK');
                await courseApi.createCoursePrice(values).then(async res => {
                    // if(res.status == 200 && res.data.data == 'true'){
                    //     await props.isSuccess(true);
                    // }
                    if(res.status == 200){
                        await props.isSuccess(true);
                    }     
                });
            }
            else {
                await props.isSuccess(false);
            }
        },
    });

    function paidEvent() {
        var paidNav = document.getElementById('nav-paid');
        var freeNav = document.getElementById('nav-free');
        var btnFree = document.getElementById('btn_free');
        var btnPaid = document.getElementById('btn_paid');
        btnFree.classList.remove('active');
        btnPaid.classList.add('active');
        freeNav.classList.remove('active');
        paidNav.classList.add('active');
    }

    function freeEvent() {
        var paidNav = document.getElementById('nav-paid');
        var freeNav = document.getElementById('nav-free');
        var btnFree = document.getElementById('btn_free');
        var btnPaid = document.getElementById('btn_paid');
        btnFree.classList.add('active');
        btnPaid.classList.remove('active');
        freeNav.classList.add('active');
        paidNav.classList.remove('active');
    }

    return (
        <div className="step-tab-panel step-tab-amenities active" id="tab_step4">
            <div className="tab-from-content">
                <div className="title-icon">
                    <h3 className="title"><i className="uil uil-usd-square" />Price</h3>
                </div>
                <form className="course__form" onSubmit={formik.handleSubmit} id='price_form'>
                    <div className="price-block">
                    <div className="row">
                        <div className="col-md-12">
                        <div className="course-main-tabs">
                            <div className="nav nav-pills flex-column flex-sm-row nav-tabs" role="tablist">
                            <a className="flex-sm-fill text-sm-center nav-link active" data-toggle="tab" href="#nav-free" role="tab" aria-selected="true" id='btn_free' onClick={freeEvent}><i className="fas fa-tag mr-2" />Free</a>
                            <a className="flex-sm-fill text-sm-center nav-link" data-toggle="tab" href="#nav-paid" role="tab" aria-selected="false" id='btn_paid' onClick={paidEvent}><i className="fas fa-cart-arrow-down mr-2" />Paid</a>
                            </div>
                            <div className="tab-content">
                            <div className="tab-pane fade show active" id="nav-free" role="tabpanel">
                                <div className="price-require-dt">
                                <div className="cogs-toggle center_d">
                                    <label className="switch">
                                    <input {...formik.getFieldProps('requiredLogIn')} type="checkbox" id="require_login" defaultValue />
                                    <span />
                                    </label>
                                    <label htmlFor="require_login" className="lbl-quiz">Require Log In</label>
                                </div>
                                <div className="cogs-toggle center_d mt-3">
                                    <label className="switch">
                                    <input {...formik.getFieldProps('requireEnroll')} type="checkbox" id="require_enroll" defaultValue />
                                    <span />
                                    </label>
                                    <label htmlFor="require_enroll" className="lbl-quiz">Require Enroll</label>
                                </div>
                                <p>If the course is free, if student require to enroll your course, if not required enroll, if students required sign in to your website to take this course.</p>
                                </div>
                            </div>
                            <div className="tab-pane" id="nav-paid" role="tabpanel">
                                <div className="license_pricing mt-30">
                                <label className="label25">Regular Price*</label>
                                {formik.touched.originalPrice && formik.errors.originalPrice ? ( 
                                    <div className="help-block text-danger">{formik.errors.originalPrice}</div> 
                                ) : null}
                                <div className="row">
                                    <div className="col-lg-4 col-md-6 col-sm-6">
                                    <div className="loc_group">
                                        <div className="ui left icon input swdh19">
                                        <input {...formik.getFieldProps('originalPrice')} className="prompt srch_explore" type="text" placeholder="$0" />
                                        </div>
                                        <span className="slry-dt">USD</span>
                                    </div>
                                    </div>
                                </div>
                                </div>
                                <div className="license_pricing mt-30 mb-30">
                                <label className="label25">Discount Price*</label>
                                {formik.touched.price && formik.errors.price ? ( 
                                    <div className="help-block text-danger">{formik.errors.price}</div> 
                                ) : null}
                                <div className="row">
                                    <div className="col-lg-4 col-md-6 col-sm-6">
                                    <div className="loc_group">
                                        <div className="ui left icon input swdh19">
                                        <input {...formik.getFieldProps('price')} className="prompt srch_explore" type="text" placeholder="$0" />
                                        </div>
                                        <span className="slry-dt">USD</span>
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
                    <button data-direction="next" className="btn btn-default steps_btn" type='submit' hidden id='btn_submit_price' form='price_form'>Submit</button>
                </form>
            </div>
        </div>
    );
}

export default CoursePrice;