import { Accordion, AccordionDetails, AccordionSummary } from '@mui/material';
import React, { useEffect, useState } from 'react';
import courseApi from '../../../api/courseAPI';
import MuiLoading from '../../LoadingIcon/MuiLoading';
import MuiSnackBar from '../../SnackBars/MuiSnackBar';
import SectionAccordion from './SectionAccordion';
import SecondToHour from '../../../js/secondToHour';

const CourseSectionList = (props) => {
    const [sections, setSections] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(false)
    const [isExpanded, setIsExpanded] = useState(null)
    let content = <MuiLoading isLoading={isLoading} />;
    let totalItems = 0;

    useEffect(() => {
        try {
            const fetchData = async () => {
                const response = await courseApi.getCourseSections(props.courseId);
                const data = response.data;

                if (data) {
                    setSections(data);
                    setIsLoading(false);
                }
            }

            fetchData();
        } catch (error) {
            setError(true);
        }
    }, []);

    const expandAllHandler = () => { isExpanded ? setIsExpanded(null) : setIsExpanded(true) };

    if (!isLoading) {
        for (const section of sections) {
            totalItems += section.totalItems;
        }
        content = (
            <div className="crse_content">
                <h3>Course content</h3>
                <div className="_112456">
                    <ul className="accordion-expand-holder">
                        {/* <li>
                            <span
                                className="accordion-expand-all _d1452"
                                onClick={expandAllHandler}>
                                {isExpanded ? 'Collapse all' : 'Expand all'}
                            </span>
                        </li> */}
                        <li>
                            <span className="_fgr123"> {totalItems} items</span>
                        </li>
                        <li>
                            <span className="_fgr123">{SecondToHour(props.courseDuration)}</span>
                        </li>
                    </ul>
                </div>
                <div id="accordion" className="ui-accordion ui-widget ui-helper-reset">
                    <SectionAccordion sections={sections} expanded={isExpanded} />
                </div>
                {/* <a className="btn1458" href="#">
                    20 More Sections
                </a> */}
            </div>
        );
    }

    return (
        <>
            {isLoading && error && <MuiSnackBar severity='error' onClose={() => { }} message='Something went wrong while loading course sections. Please try again later!' open={error} />}
            {!isLoading && !error && content}
        </>
    );
};

export default CourseSectionList;
