import PropTypes from 'prop-types';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';
ListQuestions.propTypes = {
    questions: PropTypes.array.isRequired,
    quizzId: PropTypes.number.isRequired,
    getSubmitState: PropTypes.func.isRequired,
    getAnswerValue: PropTypes.func.isRequired,
    userId: PropTypes.number.isRequired
};
export default function ListQuestions(props) {
    const { questions ,getSubmitState,getAnswerValue,quizzId,userId} = props;
    var answerValues = [];
    var index = 1;

    function handleSelectChange(questionId, e) {
        var answer = {
            content: e.target.value,
            quizQuestionId: questionId
        }
        for (let i = 0; i < answerValues.length; i++) {
            if (answerValues[i].quizQuestionId == questionId) {
                answerValues.splice(i, 1)
            }
        }
        answerValues.push(answer)
    }
    async function handleSubmitTest() {
        let userAnswers= {
            appUserId: userId,
            quizId: quizzId,
            answers: answerValues
        }
        getSubmitState(true);
        getAnswerValue(userAnswers)
    }

    return (
        <>
            <div className="certi_form">
                <div className="all_ques_lest">
                    {
                        questions.map(question => (
                            <div className="ques_item" key={question.id}>
                                <FormControl>
                                    <FormLabel className="ques_title" id="demo-radio-buttons-group-label"><b>Ques {index++} :-</b>{question.title}</FormLabel>
                                    <RadioGroup
                                        aria-labelledby="demo-radio-buttons-group-label"
                                        name="radio-buttons-group"
                                        onChange={(e) => handleSelectChange(question.id, e)}
                                    >
                                        <FormControlLabel value="A" control={<Radio />} label={question.optionA} />
                                        <FormControlLabel value="B" control={<Radio />} label={question.optionB} />
                                        <FormControlLabel value="C" control={<Radio />} label={question.optionC} />
                                        <FormControlLabel value="D" control={<Radio />} label={question.optionD} />
                                    </RadioGroup>
                                </FormControl>
                            </div>
                        ))
                    }
                </div>
                <button onClick={handleSubmitTest} className="test_submit_btn">Submit Test</button>
            </div>
        </>

    )
}
