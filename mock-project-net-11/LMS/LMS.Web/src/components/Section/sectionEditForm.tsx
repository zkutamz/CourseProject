import { useFormik } from 'formik';
import * as Yup from 'yup';
import React, { useState } from 'react'
import sectionApi from '../../api/sectionAPI';
import SectionEdit from '../../model/Section/sectionEdit';
import Section from '../../model/Section/section';

const SectionEditForm: React.FC<{ section: Section }> = (props) => {
    const [sectionId, setSectionId] = useState<number>(0);

    const formik = useFormik({
        initialValues: {
            id: props.section.id,
            name: props.section.name,
            courseId: props.section.courseId,
            position: props.section.position,
            isPublic: props.section.isPublic,
            totalTime: props.section.totalTime,
        },
        validationSchema: Yup.object({
            name: Yup.string()
                .required('Section name is required'),
            courseId: Yup.number()
                .required(),
            position: Yup.number()
                .required()
        }),
        onSubmit: async (values: SectionEdit) => {
            try {
                const section = {
                    name: values.name,
                    courseId: values.courseId,
                    position: values.position,
                    id: values.id,
                    isPublic: values.isPublic,
                    totalTime: values.totalTime
                };

                var response = await sectionApi.editSectionAsync(section);
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
        <div id="edit-section" className="collapse">
            <div className="new-section smt-25">
                <form method="post" onSubmit={formik.handleSubmit}>
                    <div className="form_group">
                        <div className="ui search focus mt-30 lbel25">
                            <label>Section Name*</label>
                            <div className="ui left icon input swdh19">
                                <input
                                    className="prompt srch_explore"
                                    type="text"
                                    placeholder={props.section.name}
                                    maxLength={60}
                                    id="name"
                                    defaultValue="Introduction"
                                    {...formik.getFieldProps('name')}
                                />
                            </div>
                            {formik.touched.name && formik.errors.name ? (
                                <div className='text-danger'>{formik.errors.name}</div>
                            ) : null}
                        </div>
                    </div>
                    <div className="share-submit-btns pl-0">
                        <button type='submit' className="main-btn color btn-hover"><i className="fas fa-save mr-2" />Update
                            Section</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default SectionEditForm;