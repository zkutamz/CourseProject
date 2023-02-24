import React from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@mui/material/Button';
import ImageUpload from './ImageUpload';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import { useState } from 'react';
import axiosClient from '../../../api/axiosClient';

function SingleQuiz(props) {
  const data = props.data;
  console.log(data);
  const [quizQuestion, setQuizQuestion] = useState([]);
  const dataPassed = (dataPassed) => {
    setQuizQuestion({ imgUrl: dataPassed.data });
  };
  console.log(quizQuestion);
  const [state, setState] = React.useState({
    checkedA: false,
    checkedB: false,
    checkedC: false,
    checkedD: false,
  });
  const handleChange = (event) => {
    setState({
      checkedA: false,
      checkedB: false,
      checkedC: false,
      checkedD: false,
      [event.target.name]: event.target.checked,
    });
  };

  const [value, setValue] = useState([]);
  const handleChangeText = (evt) => {
    const value1 = evt.target.value;
    setValue({
      ...value,
      [evt.target.name]: value1,
      quizQuestiontype: 1,
    });
  };

  const handleNext = () => {
    let request = value;
    request.imgUrl = quizQuestion.imgUrl;
    request.audioURL = 'string';
    request.videoURL = 'string';
    request.explanationImageURL = 'url';
    request.isPublic = true;
    request.quizId = data.id;
    if (state.checkedA === true) {
      request.answer = request.optionA;
    }
    if (state.checkedB === true) {
      request.answer = request.optionB;
    }
    if (state.checkedC === true) {
      request.answer = request.optionC;
    }
    if (state.checkedD === true) {
      request.answer = request.optionD;
    }

    // parseInt('request.totalTime');
    // console.log(request);
    axiosClient.post('/QuizQuestions', request);
    // .then((res) => {
    //   setQuiz(res.data);
    // });
    // setQuiz({ ...quiz, id: '11' });
    console.log(request);
  };

  return (
    <div>
      <Button variant="contained" fullWidth onClick={() => handleNext(quizQuestion)}>
        Add new question
      </Button>
      <br></br>
      <br></br>
      <TextField
        name="title"
        value={value.title}
        onChange={handleChangeText}
        fullWidth
        required
        id="outlined-required"
        label="Question Title"
        //defaultValue="Content"
        variant="outlined"
      />
      <br></br>
      <br></br>
      <TextField
        name="explanation"
        value={value.explanation}
        fullWidth
        onChange={handleChangeText}
        required
        id="outlined-required"
        label="Explain answer"
        //defaultValue="Content"
        variant="outlined"
      />
      <br></br>
      <br></br>
      {/* <input
        accept="image/*"
        //className={classes.input}
        style={{ display: 'none' }}
        id="raised-button-file"
        multiple
        type="file"
      />
      <label htmlFor="raised-button-file">
        <Button variant="contained" component="span">
          Upload Image
        </Button>
      </label> */}
      <h5>Add image</h5>
      <ImageUpload dataPassed={dataPassed}></ImageUpload>
      <br></br>
      <br></br>
      <div>
        <Button variant="contained">Add option</Button>
        <br></br>

        <h5>Option 1</h5>
        <TextField
          fullWidth
          required
          onChange={handleChangeText}
          name="optionA"
          id="filled-required"
          label="Answer"
          //defaultValue="Anwser input"
          variant="filled"
          value={value.optionA}
        />
        <br></br>
        <FormControlLabel
          control={
            <Checkbox
              checked={state.checkedA}
              onChange={handleChange}
              name="checkedA"
              color="primary"
            />
          }
          label="Correct answer"
        />
        <br></br>

        <h5>Option 2</h5>
        <TextField
          fullWidth
          required
          value={value.optionB}
          onChange={handleChangeText}
          name="optionB"
          id="filled-required"
          label="Answer"
          // defaultValue="Anwser input"
          variant="filled"
        />
        <br></br>
        <FormControlLabel
          control={
            <Checkbox
              checked={state.checkedB}
              onChange={handleChange}
              name="checkedB"
              color="primary"
            />
          }
          label="Correct answer"
        />
        <br></br>

        <h5>Option 3</h5>
        <TextField
          fullWidth
          onChange={handleChangeText}
          required
          value={value.optionC}
          name="optionC"
          id="filled-required"
          label="Answer"
          //defaultValue="Anwser input"
          variant="filled"
        />
        <br></br>
        <FormControlLabel
          control={
            <Checkbox
              checked={state.checkedC}
              onChange={handleChange}
              name="checkedC"
              color="primary"
            />
          }
          label="Correct answer"
        />
        <br></br>

        <h5>Option 4</h5>
        <TextField
          fullWidth
          onChange={handleChangeText}
          required
          value={value.optionD}
          name="optionD"
          id="filled-required"
          label="Answer"
          //defaultValue="Anwser input"
          variant="filled"
        />
        <br></br>
        <FormControlLabel
          control={
            <Checkbox
              checked={state.checkedD}
              onChange={handleChange}
              name="checkedD"
              color="primary"
            />
          }
          label="Correct answer"
        />
      </div>
    </div>
  );
}

export default SingleQuiz;
