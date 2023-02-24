import React from 'react';
import PropTypes from 'prop-types';
import * as Yup from 'yup';
import { validateYupSchema, useFormik } from 'formik';
import { useState } from 'react';
import courseApi from './../../../../api/courseAPI';
import file from './../../../../api/fileAPI';
import fileApi from './../../../../api/fileAPI';

CourseMedia.propTypes = {

};

function CourseMedia(props) {
    let [selectedFile, setSelectedFile] = useState();
    let [isFilePicked, setIsFilePicked] = useState(false);
    let [introFileUrl, setIntroFileUrl] = useState('');
    let [introThumbnailUrl, setIntroThumbnailUrl] = useState('');

    const formik = useFormik({
        initialValues: {
            id: props.courseId,
            introOverviewFile: '',
            introOverviewUrl: '',
            thumbNail: ''
        },
        validationSchema: Yup.object({
            id: Yup.number()
                .required('Required'),
            thumbNail: Yup.string().required('Required')
        }),
        onSubmit: async values => {
            if(formik.isValid){
                console.log('Valid OK');
                await courseApi.createCourseMedia(values).then(async res => {
                    // if(res.status == 200 && res.data.data == 'true'){
                    //     await props.isSuccess(true);
                    // }
                    if(res.status == 200){
                        await props.isSuccess(true);
                    }     
                });
            }
            else {
                console.log('values invalid');
                await props.isSuccess(false);
            }
        },
    });

    async function changeVideoHandler(event) {
        // call api up file o day
        // setSelectedFile(event.target.files[0]);
        // setIsFilePicked(true);
        console.log(event.target.files[0]);
        fileApi.uploadFile(event.target.files[0]).then(async res => {
            setIntroFileUrl(await res.data.data);
        });
    }

    async function changeThumbnailHandler(event) {
        // call api up file o day
        console.log(event.target.files[0]);
        fileApi.uploadFile(event.target.files[0]).then(async res => {
            setIntroThumbnailUrl(await res.data.data);
        });
        
    }

    async function submit() {
        await formik.setFieldValue('introOverviewFile',introFileUrl);
        await formik.setFieldValue('thumbNail',introThumbnailUrl);
        formik.submitForm().then(async res => {
            console.log('submit');
        });
    }

    return (
        <div className="step-tab-panel step-tab-location active" id="tab_step3">
            <div className="tab-from-content">
                <div className="title-icon">
                    <h3 className="title"><i className="uil uil-image" />Media</h3>
                    {/* {
                        console.log(introFileUrl,':',introThumbnailUrl)
                    } */}
                </div>
                <div className="lecture-video-dt mb-30">
                    <span className="video-info">Intro Course overview provider type. (.mp4, YouTube, Vimeo etc.)</span>
                    <div className="video-category">
                    <label><input type="radio" name="colorRadio" defaultValue="mp4" defaultChecked /><span>HTML5(mp4)</span></label>
                    <label><input type="radio" name="colorRadio" defaultValue="url" /><span>External URL</span></label>
                    <label><input type="radio" name="colorRadio" defaultValue="youtube" /><span>YouTube</span></label>
                    <label><input type="radio" name="colorRadio" defaultValue="vimeo" /><span>Vimeo</span></label>
                    <label><input type="radio" name="colorRadio" defaultValue="embedded" /><span>embedded</span></label>
                    <div className="mp4 intro-box" style={{display: 'block'}}>
                        <div className="row">
                        <div className="col-lg-5 col-md-12">
                            <div className="upload-file-dt mt-30">
                            <div className="upload-btn">
                                <input className="uploadBtn-main-input" type="file" id="IntroFile__input--source" onChange={changeVideoHandler} />
                                <label htmlFor="IntroFile__input--source" title="Zip">Upload Video</label>
                            </div>
                            <span className="uploadBtn-main-file">File Format: .mp4</span>
                            <span className="uploaded-id" />
                            </div>
                        </div>
                        </div>
                    </div>
                    <div className="url intro-box">
                        <div className="new-section">
                        <div className="ui search focus mt-30 lbel25">
                            <label>External URL*</label>
                            <div className="ui left icon input swdh19">
                            <input className="prompt srch_explore" type="text" placeholder="External Video URL" name id defaultValue />
                            </div>
                        </div>
                        </div>
                    </div>
                    <div className="youtube intro-box">
                        <div className="new-section">
                        <div className="ui search focus mt-30 lbel25">
                            <label>Youtube URL*</label>
                            <div className="ui left icon input swdh19">
                            <input className="prompt srch_explore" type="text" placeholder="Youtube Video URL" name id defaultValue />
                            </div>
                        </div>
                        </div>
                    </div>
                    <div className="vimeo intro-box">
                        <div className="new-section">
                        <div className="ui search focus mt-30 lbel25">
                            <label>Vimeo URL*</label>
                            <div className="ui left icon input swdh19">
                            <input className="prompt srch_explore" type="text" placeholder="Vimeo Video URL" name id defaultValue />
                            </div>
                        </div>
                        </div>
                    </div>
                    <div className="embedded intro-box">
                        <div className="new-section">
                        <div className="ui search focus mt-30 lbel25">
                            <label>Embedded Code*</label>
                            <div className="ui form swdh30">
                            <div className="field">
                                <textarea rows={3} name id placeholder="Place your embedded code here" defaultValue={""} />
                            </div>
                            </div>
                        </div>
                        </div>
                    </div>
                    </div>
                </div>
                <div className="thumbnail-into">
                    <div className="row">
                    <div className="col-lg-5 col-md-6">
                        <label className="label25 text-left">Course thumbnail*</label>
                        {formik.touched.thumbNail && formik.errors.thumbNail ? ( 
                                <div className="help-block text-danger">{formik.errors.thumbNail}</div> 
                        ) : null}
                        <div className="thumb-item">
                        <img src="images/thumbnail-demo.jpg" alt="" />
                        <div className="thumb-dt">
                            <div className="upload-btn">
                            <input className="uploadBtn-main-input" type="file" id="ThumbFile__input--source" onChange={changeThumbnailHandler} />
                            <label htmlFor="ThumbFile__input--source" title="Zip">Choose Thumbnail</label>
                            </div>
                            <span className="uploadBtn-main-file">Size: 590x300 pixels. Supports: jpg,jpeg, or png</span>
                        </div>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
            <button data-direction="next" className="btn btn-default steps_btn" type='submit' hidden id='btn_submit_media' onClick={submit} >Submit</button>
        </div>
    );
}

export default CourseMedia;