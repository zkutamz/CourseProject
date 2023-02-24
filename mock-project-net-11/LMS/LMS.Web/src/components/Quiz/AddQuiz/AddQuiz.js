import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import Question from './Question';
import Setting from './Setting';
import Box from '@mui/material/Box';
import { useState, useEffect } from 'react';
import axiosClient from '../../../api/axiosClient';

const useStyles = makeStyles((theme) => ({
  root: {
    width: '100%',
  },
  backButton: {
    marginRight: theme.spacing(1),
  },
  instructions: {
    marginTop: theme.spacing(1),
    marginBottom: theme.spacing(1),
  },
}));
function getSteps() {
  return ['Basic', 'Add Question'];
}
function getStepContent(stepIndex, dataPassed, quiz) {
  switch (stepIndex) {
    case 0:
      return <Basic dataPassed={dataPassed} />;
    case 1:
      return <Question data={quiz} />;
    case 2:
      return <Setting />;
    default:
      return 'Unknown stepIndex';
  }
}
function Basic({ dataPassed }) {
  const [value, setValue] = useState([]);
  const handleChange = (evt) => {
    const value1 = evt.target.value;
    setValue({
      ...value,
      [evt.target.name]: value1,
    });
    dataPassed(value);
  };
  return (
    <div>
      {' '}
      <div className="col-md-10 offset-md-1">
        <div>
          <TextField
            name="title"
            fullWidth
            required
            id="outlined-required"
            label="Title"
            //defaultValue="Title"
            variant="outlined"
            value={value.title}
            onChange={handleChange}
          />
        </div>
        <br></br>
        <div>
          <TextField
            name="content"
            fullWidth
            //required
            id="outlined-required"
            label="Description"
            //defaultValue="Content"
            variant="outlined"
            onChange={handleChange}
            value={value.content}
          />
        </div>
        <br></br>
        <div>
          <TextField
            name="totalTime"
            fullWidth
            required
            id="outlined-required"
            label="Time(minute)"
            //defaultValue="m"
            variant="outlined"
            type="number"
            value={value.totalTime}
            InputLabelProps={{
              shrink: true,
            }}
            InputProps={{ inputProps: { min: 1 } }}
            onChange={handleChange}
          />
        </div>
        <br></br>
        {/* <div>
        <TextField
          fullWidth
          required
          id="outlined-required"
          label="Passing percent(%)"
          //defaultValue="%"
          variant="outlined"
          type="number"
          InputLabelProps={{
            shrink: true,
          }}
          onChange={handleChange}
          InputProps={{ inputProps: { min: 1, max: 100 } }}
        />
      </div> */}
      </div>
    </div>
  );
}

function AddQuiz(props) {
  const classes = useStyles();
  const [activeStep, setActiveStep] = React.useState(0);
  const [quiz, setQuiz] = useState([]);
  const steps = getSteps();

  const dataPassed = (dataPassed) => {
    setQuiz(dataPassed);
  };

  const handleNext = () => {
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
    console.log(quiz);
    let request = quiz;
    request.imgUrl = 'url';
    request.isPublic = true;
    request.isExposedQuestion = true;
    request.sectionId = 11;
    parseInt('request.totalTime');
    console.log(request);
    axiosClient.post('/Quizzes/sectionQuiz/', request).then((res) => {
      setQuiz(res.data);
    });
    setQuiz({ ...quiz, id: 39 });
  };

  const handleBack = (quiz) => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleReset = () => {
    setActiveStep(0);
  };

  return (
    <div>
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <Box sx={{ width: '100%', typography: 'body1' }}>
            <div className={classes.root}>
              <Stepper activeStep={activeStep} alternativeLabel>
                {steps.map((label) => (
                  <Step key={label}>
                    <StepLabel>{label}</StepLabel>
                  </Step>
                ))}
              </Stepper>
              <div>
                {activeStep === steps.length ? (
                  <div>
                    <Typography className={classes.instructions}>All steps completed</Typography>
                    <Button onClick={handleReset}>Reset</Button>
                  </div>
                ) : (
                  <div>
                    <Typography className={classes.instructions}>
                      {getStepContent(activeStep, dataPassed, quiz)}
                    </Typography>
                    <div>
                      <Button
                        disabled={activeStep === 0}
                        onClick={handleBack}
                        className={classes.backButton}
                      >
                        Back
                      </Button>
                      <Button variant="contained" color="primary" onClick={() => handleNext(quiz)}>
                        {activeStep === steps.length - 1 ? 'Finish' : 'Next'}
                      </Button>
                    </div>
                  </div>
                )}
              </div>
            </div>
          </Box>
        </div>
      </div>
    </div>
  );
}

export default AddQuiz;
