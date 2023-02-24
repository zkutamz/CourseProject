import React from 'react';
import Button from '@mui/material/Button';
import { withStyles } from '@material-ui/core/styles';
import { green } from '@material-ui/core/colors';
import FormGroup from '@material-ui/core/FormGroup';

import CheckBoxOutlineBlankIcon from '@material-ui/icons/CheckBoxOutlineBlank';
import CheckBoxIcon from '@material-ui/icons/CheckBox';
import Favorite from '@material-ui/icons/Favorite';
import FavoriteBorder from '@material-ui/icons/FavoriteBorder';
import TextField from '@mui/material/TextField';

function AddOption(props) {
  const [state, setState] = React.useState({
    checkedA: true,
    checkedB: true,
    checkedC: true,
    checkedD: true,
  });
  const handleChange = (event) => {
    setState({ ...state, [event.target.name]: event.target.checked });
  };
  return (
    <div>
      <Button variant="contained">Add option</Button>
      <br></br>
      <br></br>
      <TextField
        fullWidth
        required
        id="filled-required"
        label="Answer"
        defaultValue="Anwser input"
        variant="filled"
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
      <br></br>
      <TextField
        fullWidth
        required
        id="filled-required"
        label="Answer"
        defaultValue="Anwser input"
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
      <br></br>
      <TextField
        fullWidth
        required
        id="filled-required"
        label="Answer"
        defaultValue="Anwser input"
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
      <br></br>
      <TextField
        fullWidth
        required
        id="filled-required"
        label="Answer"
        defaultValue="Anwser input"
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
  );
}

export default AddOption;
