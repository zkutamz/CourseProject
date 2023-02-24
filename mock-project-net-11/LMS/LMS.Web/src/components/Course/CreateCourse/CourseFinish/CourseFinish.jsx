import React, { useEffect, useRef } from 'react';

CourseFinish.propTypes = {

};

export default function CourseFinish(props) {

    return (
        <>
            <div className="step-tab-panel step-tab-location active" id="tab_step5">
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
        </>
    );
}
