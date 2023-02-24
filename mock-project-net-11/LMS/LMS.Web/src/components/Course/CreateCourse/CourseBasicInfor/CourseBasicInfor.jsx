import PropTypes from 'prop-types';
import CategoryList from '../../../Category/CategoryList';
import { useState, useContext, useEffect } from 'react';
import * as Yup from 'yup';
import { validateYupSchema, useFormik } from 'formik';
import AuthContext from '../../../../store/auth-context';
import courseApi from './../../../../api/courseAPI';
import { CreateResult } from './../../../../model/Course/CreateResult';

CourseBasicInfor.propTypes = {

};

function CourseBasicInfor(props) {
    let toggle = false;
    let [category, setCategory] = useState({id: 0, name: 'Select'});
    let [courseId, setCourseId] = useState(0);
    let createResult = new CreateResult();
    let context = useContext(AuthContext);

    useEffect(() => {
        if(localStorage.getItem('createCourseId')){
            setCourseId(localStorage.getItem('createCourseId'));
        }
    })

    const formik = useFormik({
        initialValues: {
            title: '',
            shortDescription: '',
            description: '',
            price: 0,
            originalPrice: 0,
            announcement: '',
            requirement: '',
            whatLearn: '',
            feature: false,
            totalDuration: 0,
            level: 0,
            audioLanguage: '',
            closeCaption: '',
            instructorId: context.userId,
            categoryId: 0
        },
        validationSchema: Yup.object({
        title: Yup.string()
            .max(100, 'Must be 100 characters or less')
            .required('Required'),
        shortDescription: Yup.string()
            .max(220, 'Must be 220 characters or less')
            .required('Required'),
        description: Yup.string().required('Required'),
        whatLearn: Yup.string().required('Required'),
        requirement: Yup.string().required('Required'),
        level: Yup.number().required('Required'),
        audioLanguage: Yup.string().required('Required'),
        closeCaption: Yup.string().required('Required'),
        categoryId: Yup.number().required('Required')
        }),
        onSubmit: async values => {
            if(formik.isValid){
                console.log('Valid OK');
                if(courseId){
                    formik.setFieldValue('id', category.id);
                }
                await courseApi.createBasicInforCourse(values).then(async res => {
                    setCourseId(await res.data.data);
                    localStorage.setItem('createCourseId',res.data.data);
                    if(res.status == 200){
                        await props.isSuccess(true);
                    }   
                });
            }
            else {
                await props.isSuccess(false);
            }
            //alert(JSON.stringify(values, null, 2));
        },
    });
    
    function categoryClicked() {
        toggle = !toggle;
        if(toggle){
            document.getElementById('cate_menu').style.display = 'block';
        } 
        else {
            document.getElementById('cate_menu').style.display = 'none';
        }
    }

    const handleCallback = (childData) => {
        setCategory(childData);
        formik.setFieldValue('categoryId',childData.id);
    }

    return (
        <div className="step-tab-panel step-tab-info active" id="tab_step1">
            <div className="tab-from-content">
                <div className="title-icon">
                    <h3 className="title"><i className="uil uil-info-circle" />Basic Information</h3>
                </div>
                <form className="course__form" onSubmit={formik.handleSubmit} id='basic_infor_form'>
                    <div className="general_info10">
                    <div className="row">
                        <div className="col-lg-12 col-md-12">
                        <div className="ui search focus mt-30 lbel25">
                            <label>Course Title*</label>
                            {formik.touched.title && formik.errors.title ? ( 
                                <div className="help-block text-danger">{formik.errors.title}</div> 
                            ) : null}
                            <div className="ui left icon input swdh19">
                            <input {...formik.getFieldProps('title')} className="prompt srch_explore" type="text" placeholder="Course title here" name="title" data-purpose="edit-course-title" maxLength={60} id="title" />
                            <div className="badge_num">60</div>
                            </div>
                            <div className="help-block">(Please make this a maximum of 100 characters and unique.)</div>
                        </div>
                        </div>
                        <div className="col-lg-12 col-md-12">
                        <div className="ui search focus lbel25 mt-30">
                            <label>Short Description*</label>
                            {formik.touched.shortDescription && formik.errors.shortDescription ? ( 
                                <div className="help-block text-danger">{formik.errors.shortDescription}</div> 
                            ) : null}
                            <div className="ui form swdh30">
                            <div className="field">
                                <textarea {...formik.getFieldProps('shortDescription')} rows={3} name="shortDescription" id='shortDescription' placeholder="Item description here..." defaultValue={""} />
                            </div>
                            </div>
                            <div className="help-block">220 words</div>
                        </div>
                        </div>
                        <div className="col-lg-12 col-md-12">
                        <div className="course_des_textarea mt-30 lbel25">
                            <label>Course Description*</label>
                            {formik.touched.description && formik.errors.description ? ( 
                                <div className="help-block text-danger">{formik.errors.description}</div> 
                            ) : null}
                            <div className="course_des_bg">
                            <ul className="course_des_ttle">
                                <li><a href="#"><i className="uil uil-bold" /></a></li>
                                <li><a href="#"><i className="uil uil-italic" /></a></li>
                                <li><a href="#"><i className="uil uil-list-ul" /></a></li>
                                <li><a href="#"><i className="uil uil-left-to-right-text-direction" /></a></li>
                                <li><a href="#"><i className="uil uil-right-to-left-text-direction" /></a></li>
                                <li><a href="#"><i className="uil uil-list-ui-alt" /></a></li>
                                <li><a href="#"><i className="uil uil-link" /></a></li>
                                <li><a href="#"><i className="uil uil-text-size" /></a></li>
                                <li><a href="#"><i className="uil uil-text" /></a></li>
                            </ul>
                            <div className="textarea_dt">
                                <div className="ui form swdh339">
                                <div className="field">
                                    <textarea {...formik.getFieldProps('description')} rows={5} name="description" id="description" placeholder="Insert your course description" defaultValue={""} />
                                </div>
                                </div>
                            </div>
                            </div>
                        </div>
                        </div>
                        <div className="col-lg-6 col-md-12">
                        <div className="ui search focus lbel25 mt-30">
                            <label>What will students learn in your course?*</label>
                            {formik.touched.whatLearn && formik.errors.whatLearn ? ( 
                                <div className="help-block text-danger">{formik.errors.whatLearn}</div> 
                            ) : null}
                            <div className="ui form swdh30">
                            <div className="field">
                                <textarea {...formik.getFieldProps('whatLearn')} rows={3} name="whatLearn" id placeholder defaultValue={""} />
                            </div>
                            </div>
                            <div className="help-block">Student will gain this skills, knowledge after completing this course. (One per line).</div>
                        </div>
                        </div>
                        <div className="col-lg-6 col-md-12">
                        <div className="ui search focus lbel25 mt-30">
                            <label>Requirements*</label>
                            {formik.touched.requirement && formik.errors.requirement ? ( 
                                <div className="help-block text-danger">{formik.errors.requirement}</div> 
                            ) : null}
                            <div className="ui form swdh30">
                            <div className="field">
                                <textarea {...formik.getFieldProps('requirement')} rows={3} name="requirement" id placeholder defaultValue={""} />
                            </div>
                            </div>
                            <div className="help-block">What knowledge, technology, tools required by users to start this course. (One per line).</div>
                        </div>
                        </div>
                        <div className="col-lg-6 col-md-12">
                        <div className="mt-30 lbel25">
                            <label>Course Level*</label>
                            {formik.touched.level && formik.errors.level ? ( 
                                <div className="help-block text-danger">{formik.errors.level}</div> 
                            ) : null}
                        </div>
                        <select {...formik.getFieldProps('level')} className="ui hj145 dropdown cntry152 prompt srch_explore">
                            <option value>Select Level</option>
                            <option value={1}>Beginner</option>
                            <option value={2}>Intermediate</option>
                            <option value={3}>Expert</option>
                        </select>
                        </div>
                        <div className="col-lg-6 col-md-12">
                        <div className="mt-30 lbel25">
                            <label>Audio Language*</label>
                            {formik.touched.audioLanguage && formik.errors.audioLanguage ? ( 
                                <div className="help-block text-danger">{formik.errors.audioLanguage}</div> 
                            ) : null}
                        </div>
                        <select {...formik.getFieldProps('audioLanguage')} className="ui hj145 dropdown cntry152 prompt srch_explore">
                            <option value>Select Audio</option>
                            <option value={'English'}>English</option>
                            <option value={'Español'}>Español</option>
                            <option value={'Português'}>Português</option>
                            <option value={'日本語'}>日本語</option>
                            <option value={'Deutsch'}>Deutsch</option>
                            <option value={'Français'}>Français</option>
                            <option value={'Italiano'}>Italiano</option>
                        </select>
                        </div>
                        <div className="col-lg-6 col-md-6">
                        <div className="mt-30 lbel25">
                            <label>Close Caption*</label>
                            {formik.touched.closeCaption && formik.errors.closeCaption ? ( 
                                <div className="help-block text-danger">{formik.errors.closeCaption}</div> 
                            ) : null}
                        </div>
                        <select {...formik.getFieldProps('closeCaption')} className="ui hj145 dropdown cntry152 prompt srch_explore">
                            <option value>Select Caption</option>
                            <option value={'English'}>English</option>
                            <option value={'Español'}>Español</option>
                            <option value={'Português'}>Português</option>
                            <option value={'日本語'}>日本語</option>
                            <option value={'Deutsch'}>Deutsch</option>
                            <option value={'Français'}>Français</option>
                            <option value={'Italiano'}>Italiano</option>
                        </select>
                        </div>
                        <div className="col-lg-6 col-md-6">
                        <div className="mt-30 lbel25">
                            <label>Course Category*</label>
                            {formik.touched.categoryId && formik.errors.categoryId ? ( 
                                <div className="help-block text-danger">{formik.errors.categoryId}</div> 
                            ) : null}
                        </div>
                        <div className="ui selection dropdown cntry152 prompt srch_explore optgroup" onClick={ categoryClicked } >
                            <div className="default text">{category.name}</div>
                            <i className="dropdown icon" />
                            <div className="menu cate_menu" id='cate_menu'>
                            <div className="ui horizontal divider opt_title">Category</div>
                            <CategoryList parentCallback={ handleCallback } />
                            </div>
                        </div>
                        </div>
                    </div>
                    </div>
                    <button data-direction="next" className="btn btn-default steps_btn" type='submit' hidden id='btn_submit_basic_infor' form='basic_infor_form'>Submit</button>
                </form>
            </div>
        </div>
    );
}

export default CourseBasicInfor;