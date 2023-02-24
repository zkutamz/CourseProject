import React, { useContext, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import Clock from '../DetailCourse/Clock';
import { FormControlLabel, Radio, RadioGroup } from '@mui/material';
import AuthContext from '../../../store/auth-context';
import studyCourseAPI from '../../../api/studyCourseAPI';
Quiz.propTypes = {
  lessonStudy: PropTypes.object,
};
Quiz.defaultProps = {
  lessonStudy: {},
};
function Quiz({ lessonStudy, handleSubmitQuiz }) {
  const [anwers, setAnwsers] = useState([]);
  const authContext = useContext(AuthContext);
  let userID = authContext.userId;
  //console.log(lessonStudy);
  var answerValues = [];
  const handleClickAnwser = (data) => {
    for (let i = 0; i < answerValues.length; i++) {
      if (answerValues[i].quizQuestionId == data.quizQuestionId) {
        answerValues.splice(i, 1);
      }
    }
    answerValues.push(data);
  };
  const listQuestion = lessonStudy.quizQuestions.map((question, index) => (
    <div key={index} className="ques_item">
      <div className="ques_title">
        <span>Ques {index + 1} :-</span>
        {question.title}
      </div>
      <div className="ui form">
        <div className="grouped fields">
          <RadioGroup
            onChange={(e) =>
              handleClickAnwser({ content: e.target.value, quizQuestionId: question.id })
            }
          >
            <div className="field fltr-radio">
              <div className="ui">
                <FormControlLabel value="A" control={<Radio />} label={question.optionA} />
              </div>
            </div>
            <div className="field">
              <div className="ui">
                <FormControlLabel
                  value="B"
                  control={<Radio className="hidden" />}
                  label={question.optionB}
                />
              </div>
            </div>
            <div className="field">
              <div className="ui">
                <FormControlLabel
                  value="C"
                  control={<Radio className="hidden" />}
                  label={question.optionC}
                />
              </div>
            </div>
            <div className="field fltr-radio">
              <div className="ui">
                <FormControlLabel
                  value="D"
                  control={<Radio className="hidden" />}
                  label={question.optionD}
                />
              </div>
            </div>
          </RadioGroup>
        </div>
      </div>
    </div>
  ));

  useEffect(() => {
    setInterval(() => {});
  });
  async function handleSubmitTest() {
    let userAnswers = {
      appUserId: userID,
      quizId: lessonStudy.id,
      answers: answerValues,
    };
    //console.log(userAnswers);
    handleSubmitQuiz(userAnswers);
    const submitQuiz = async () => {
      try {
        const result = await studyCourseAPI.postSubmitQuiz(userAnswers);
        console.log(result.data.data);
      } catch (error) {
        console.log('Failed to complete quiz for user: ', error.response);
      }
    };
    submitQuiz();
  }
  //console.log(lessonStudy);
  return (
    <div className="faq1256">
      <div className="container">
        <div className="row">
          <div className="col-lg-4 col-md-6">
            <div className="certi_form rght1528">
              <div className="test_timer_bg">
                <ul className="test_timer_left">
                  <li>
                    <div className="timer_time">
                      <h4>{lessonStudy.quizQuestions.length}</h4>
                      <p>Questions</p>
                    </div>
                  </li>
                  <li>
                    <Clock key={lessonStudy.totalTime} totalTime={lessonStudy.totalTime} />
                  </li>
                </ul>
              </div>
            </div>
          </div>
          <div className="col-lg-7 col-md-6">
            <div className="certi_form">
              <div className="all_ques_lest">{listQuestion}</div>
              <button className="test_submit_btn" onClick={handleSubmitTest}>
                Submit Test
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Quiz;
