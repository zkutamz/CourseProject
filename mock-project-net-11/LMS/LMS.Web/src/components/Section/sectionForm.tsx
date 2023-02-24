import { useFormik } from 'formik';
import * as Yup from 'yup';
import React, { useState } from 'react'
import sectionApi from '../../api/sectionAPI';

type Values = {
    name: string,
    courseId: number,
    position: number,
}

const SectionForm: React.FC<{ courseId: number, position: number }> = (props) => {
    const [sectionId, setSectionId] = useState<number>(0);

    const formik = useFormik({
        initialValues: {
            name: '',
            courseId: props.courseId,
            position: 0
        },
        validationSchema: Yup.object({
            name: Yup.string()
                .required('Section name is required'),
            courseId: Yup.number()
                .required(),
            position: Yup.number()
                .required()
        }),
        onSubmit: async (values: Values) => {
            try {
                const section = {
                    name: values.name,
                    courseId: props.courseId,
                    position: 1
                }

                console.log(props.courseId);

                var response = await sectionApi.createSectionAsync(section);

                if (response.data.statusCode === 201) {
                    setSectionId(response.data.data.id);
                }
            } catch (error: any) {
                if (error.response) {
                    console.log(error.response);
                } else if (error.request) {
                    console.log(error.request);
                } else console.log(error);
            }
        },
    });

    return (
        <div className="modal-content">
            <div className="modal-header">
                <h5 className="modal-title" id="lectureModalLabel">New Section</h5>
                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
            </div>
            <div className="modal-body">
                <div className="new-section-block">
                    <div className="row">
                        <div className="col-md-12">
                            <div className="new-section">
                                <form method="post" onSubmit={formik.handleSubmit} id="sectionForm">
                                    <div className="form_group">
                                        <label className="label25">Section Name*</label>
                                        <input
                                            className="form_input_1"
                                            type="text"
                                            id="name"
                                            placeholder="Section title here"
                                            {...formik.getFieldProps('name')} />
                                        {formik.touched.name && formik.errors.name ? (
                                            <div className='text-danger'>{formik.errors.name}</div>
                                        ) : null}
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="modal-footer">
                <button type="button" className="main-btn cancel" data-dismiss="modal">Close</button>
                <button type="submit" form="sectionForm" className="main-btn">Add Section</button>
            </div>
        </div>
    )
}

export default SectionForm;