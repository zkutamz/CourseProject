import { useFormik } from 'formik';
import React, { useState } from 'react';
import * as Yup from 'yup';
import assignmentAPI from '../../api/assignmentAPI';
import fileAPI from '../../api/fileAPI';
import ReactDOM from 'react-dom';
import MuiSnackBar from '../SnackBars/MuiSnackBar';

type Values = {
    title: string,
    description: string,
    duration: number,
    totalNumber: number,
    minimumPassNumber: number,
    uploadAttachmentLimit: number,
    maximumAttachmentSizeLimit: number,
}

export const Assignment: React.FC<{
    sectionID: number
}> = (props) => {
    const [files, setFiles] = useState<{
        uploadedFileName: string,
        savedFileName: string
    }[]>([]);
    const [fileUrls, setFileUrls] = useState<string[]>([]);
    const [isUploaded, setIsUploaded] = useState<boolean>(false);
    const [isDeleted, setIsDeleted] = useState<boolean>(false);
    const [isError, setIsError] = useState<boolean>(false);

    const formik = useFormik({
        initialValues: {
            title: '',
            description: '',
            duration: 0,
            totalNumber: 0,
            minimumPassNumber: 0,
            uploadAttachmentLimit: 0,
            maximumAttachmentSizeLimit: 0,
        },
        validationSchema: Yup.object({
            title: Yup.string()
                .required('Required'),
            description: Yup.string()
                .required('Required'),
            duration: Yup.number()
                .required()
                .integer(),
            totalNumber: Yup.number()
                .positive()
                .required('Required'),
            minimumPassNumber: Yup.number()
                .positive()
                .required('Required'),
            uploadAttachmentLimit: Yup.number()
                .positive()
                .required('Required'),
            maximumAttachmentSizeLimit: Yup.number()
                .positive(),
        }),
        onSubmit: async (values: Values) => {
            try {
                const assignment = {
                    title: values.title,
                    content: values.description,
                    totalTime: values.duration,
                    totalNumber: values.totalNumber,
                    minimumPassNumber: values.minimumPassNumber,
                    uploadAttachmentLimit: values.uploadAttachmentLimit,
                    assignmentUrls: fileUrls,
                    maximumAttachmentSizeLimit: values.maximumAttachmentSizeLimit,
                    sectionId: 2
                }

                var response = await assignmentAPI.createAssignmentAsync(assignment);
            } catch (error: any) {
                if (error.response) {
                    console.log(error.response);
                } else if (error.request) {
                    console.log(error.request);
                } else console.log(error);

                setIsError(true);
            }
        },
    });

    const attachmentUploadHandler = async (e: any) => {
        try {
            const newFiles: any[] = e.target.files;

            var response = await fileAPI.uploadFilesToAzureAsync(newFiles);

            if (response.data.statusCode === 201) {
                setFileUrls(response.data.data);

                for (let i = 0; i < newFiles.length && i < response.data.data.length; i++) {
                    setFiles(prev => [...prev, {
                        uploadedFileName: newFiles[i].name,
                        savedFileName: response.data.data[i].replace(/^\/storage-upload\//g, '')
                    }]);
                }

                setIsUploaded(true);
            }
        } catch (error: any) {
            if (error.response) {
                console.log(error.response);
            } else if (error.request) {
                console.log(error.request);
            } else console.log(error);

            setIsError(true);
        }
    };

    const deleteFileHandler = async (fileName: string): Promise<void> => {
        try {
            var response = await fileAPI.deleteFileFromAzureAsync(fileName);

            if (response.data.statusCode === 204) {
                setIsDeleted(true);
                setFiles(prev => prev.filter(f => f.savedFileName != fileName));
            }
        } catch (error: any) {
            if (error.response) {
                console.log(error.response);
            } else if (error.request) {
                console.log(error.request);
            } else console.log(error);

            setIsError(true);
        }
    };

    let content = (
        <div className="modal-dialog modal-lg">
            {
                ReactDOM.createPortal(
                    <>
                        <MuiSnackBar open={isUploaded} message="File uploaded successfully!"
                            severity='success'
                            onClose={() => { setIsUploaded(false) }} />
                        <MuiSnackBar open={isDeleted} message="File deleted successfully!"
                            severity='success'
                            onClose={() => { setIsDeleted(false) }} />
                        <MuiSnackBar open={isError} message="Something went wrong. Please try again!"
                            severity='error'
                            onClose={() => { setIsError(false) }} />

                    </>,
                    document.getElementById('snack-bar')!
                )
            }
            <div className="modal-content">
                <div className="modal-header">
                    <h5 className="modal-title" id="lectureModalLabel">
                        Add Assignment
                    </h5>
                    <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div className="modal-body">
                    <div className="new-section-block main-form">
                        <div className="row">
                            <div className="col-md-12">
                                <div className="new-section">
                                    <form onSubmit={formik.handleSubmit} id="assignmentForm">
                                        <div className="form_group">
                                            <label className="label25">Assignment Title*</label>
                                            <input
                                                className="form_input_1"
                                                type="text"
                                                id="title"
                                                placeholder="Assignment title here"
                                                {...formik.getFieldProps('title')}
                                            />
                                            {formik.touched.title && formik.errors.title ? (
                                                <div className='text-danger'>{formik.errors.title}</div>
                                            ) : null}
                                        </div>
                                        <div className="form_group mt-30">
                                            <label className="label25">Description*</label>
                                            <div className="text-editor">
                                                <textarea id="description"
                                                    className='w-100'
                                                    {...formik.getFieldProps('description')}></textarea>
                                            </div>
                                            {formik.touched.description && formik.errors.description ? (
                                                <div className='text-danger'>{formik.errors.description}</div>
                                            ) : null}
                                        </div>
                                        <div className="form_group mt-30">
                                            <div className="row g-4">
                                                <div className="col-lg-4 mt-30">
                                                    <label className="label25">Time Duration*</label>
                                                    <div className="row no-gutters">
                                                        <div className="col-12">
                                                            <input
                                                                id="duration"
                                                                className="form_input_1" type="number" defaultValue={0}
                                                                {...formik.getFieldProps('duration')} />
                                                        </div>
                                                    </div>
                                                    {formik.touched.duration && formik.errors.duration ? (
                                                        <div className='text-danger'>{formik.errors.duration}</div>
                                                    ) : null}
                                                    <span className="alt-text">
                                                        Assignment time duration, set 0 for no limit.
                                                    </span>
                                                </div>
                                                <div className="col-lg-4 mt-30">
                                                    <label className="label25">Total Number*</label>
                                                    <input
                                                        id="totalNumber"
                                                        className="form_input_1"
                                                        type="number"
                                                        defaultValue={10}
                                                        {...formik.getFieldProps('totalNumber')} />
                                                    {formik.touched.totalNumber && formik.errors.totalNumber ? (
                                                        <span className='text-danger'>{formik.errors.totalNumber}</span>
                                                    ) : null}
                                                    <span className="alt-text">Maximum points a student can score</span>


                                                </div>
                                                <div className="col-lg-4 mt-30">
                                                    <label className="label25">Minimum Pass Number*</label>
                                                    <input
                                                        id='minimumPassNumber'
                                                        className="form_input_1" type="number" defaultValue={5}
                                                        {...formik.getFieldProps('minimumPassNumber')} />
                                                    {formik.touched.minimumPassNumber && formik.errors.minimumPassNumber ? (
                                                        <span className='text-danger'>{formik.errors.minimumPassNumber}</span>
                                                    ) : null}
                                                    <span className="alt-text">
                                                        Minimum points required for the student to pass this assignment.
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="assgn152 mt-30 pt-30">
                                            <div className="row g-6">
                                                <div className="col-lg-6 mt-30">
                                                    <label className="label25">Upload attachment limit*</label>
                                                    <input
                                                        id='uploadAttachmentLimit'
                                                        className="form_input_1" type="text" defaultValue={1}
                                                        {...formik.getFieldProps('uploadAttachmentLimit')}
                                                    />
                                                    {formik.touched.uploadAttachmentLimit && formik.errors.uploadAttachmentLimit ? (
                                                        <span className='text-danger'>{formik.errors.uploadAttachmentLimit}</span>
                                                    ) : null}
                                                    <span className="alt-text">Maximum attachment size limit</span>
                                                </div>
                                                <div className="col-lg-6 mt-30">
                                                    <label className="label25">Maximum attachment size limit</label>
                                                    <input
                                                        id='maximumAttachmentSizeLimit'
                                                        className="form_input_1" type="text" defaultValue={10}
                                                        {...formik.getFieldProps('maximumAttachmentSizeLimit')} />
                                                    {formik.touched.maximumAttachmentSizeLimit && formik.errors.maximumAttachmentSizeLimit ? (
                                                        <span className='text-danger'>{formik.errors.maximumAttachmentSizeLimit}</span>
                                                    ) : null}
                                                    <span className="alt-text">Define maximum attachment size in MB</span>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                    <div className="upload-file-dt mt-30">
                                        <div className="upload-btn">
                                            <form>
                                                <input
                                                    id="file"
                                                    className="uploadBtn-main-input"
                                                    type="file"
                                                    onChange={attachmentUploadHandler}
                                                    multiple
                                                />
                                                <label htmlFor="file" title="Zip">
                                                    <i className="far fa-plus-square mr-2" />
                                                    Attachment
                                                </label>
                                            </form>
                                        </div>
                                        <span className="uploadBtn-main-file">
                                            Supports: jpg, jpeg, png, pdf or .zip
                                        </span>
                                        <div className="add-attachments-dt">
                                            {
                                                files.map(f => (
                                                    <div className="attachment-items">
                                                        <div className="attachment_id">Uploaded File Name: {f.uploadedFileName}</div>
                                                        <button className="cancel-btn" type="button" onClick={async () => { deleteFileHandler(f.savedFileName) }}>
                                                            <i className="fas fa-trash-alt" />
                                                        </button>
                                                    </div>
                                                ))
                                            }
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="modal-footer">
                    <button type="button" className="main-btn cancel" data-dismiss="modal">
                        Close
                    </button>
                    <button type="submit" form='assignmentForm' className="main-btn">
                        Add Assignment
                    </button>
                </div>
            </div>
        </div>
    );
    return content;
};
