import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import SecondToHour from '../../../js/secondToHour';

const SectionAccordion = props => {
    return (
        <>
            {
                props.sections.map(section =>
                    <Accordion key={section.id} >
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            id={section.id}
                        >
                            <div className='d-flex justify-content-between w-100'>
                                <div className="section-header-left">
                                    <span className="section-title-wrapper">
                                        <i className="uil uil-presentation-play crse_icon" />
                                        <span className="section-title-text">{section.name}</span>
                                    </span>
                                </div>
                                <div className="section-header-right">
                                    <span className="num-items-in-section pr-xl-5 pr-md-3 pr-2">{section.totalItems} Items</span>
                                    <span className="section-header-length pr-xl-5 pr-md-3 pr-2">{SecondToHour(section.totalTime)}</span>
                                </div>
                            </div>
                        </AccordionSummary>
                        <AccordionDetails>
                            {
                                section.lessons.map(lesson => (
                                    <div key={lesson.id} className="d-flex justify-content-between align-items-center border-bottom py-2">
                                        <div>
                                            <p className='title'><i className="uil uil-file icon_142" /> {lesson.title}</p>
                                        </div>
                                        <div >
                                            <span className="content-summary">{SecondToHour(lesson.totalTime)}</span>
                                        </div>
                                    </div>
                                ))}
                            {
                                section.assignments.map(assignment => (
                                    <div key={assignment.id} className="d-flex justify-content-between align-items-center border-bottom py-2">
                                        <div>
                                            <p className="title"><i className="uil uil-file-download-alt icon_142 pr-1" />{assignment.title}</p>
                                        </div>
                                        <div>
                                            <span className="content-summary">{SecondToHour(assignment.totalTime)}</span>
                                        </div>
                                    </div>
                                ))
                            }
                            {
                                section.quizSections.map(quizSection => (
                                    <div key={quizSection.quiz.id} className="d-flex justify-content-between align-items-center border-bottom py-2">
                                        <div>
                                            <p className="title"><i className="uil uil-question-circle icon_142 pr-1" />{quizSection.quiz.title}</p>
                                        </div>
                                        <div>
                                            <span className="content-summary">{SecondToHour(quizSection.quiz.totalTime)}</span>
                                        </div>
                                    </div>
                                ))
                            }

                        </AccordionDetails>
                    </Accordion>
                )
            }
        </>
    )
}

export default SectionAccordion;