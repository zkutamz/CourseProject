import React from 'react';
import TextField from '@material-ui/core/TextField';
import { useState, useEffect } from 'react';

function Basic(props) {
  const [value, setValue] = useState([]);
  const handleChange = (evt) => {
    const value1 = evt.target.value;
    setValue({
      ...value,
      [evt.target.name]: value1,
    });
  };
  return (
    <div>
      {' '}
      <div>
        <TextField
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
          fullWidth
          required
          id="outlined-required"
          label="Time(minute)"
          //defaultValue="m"
          variant="outlined"
          type="number"
          InputLabelProps={{
            shrink: true,
          }}
          InputProps={{ inputProps: { min: 1 } }}
          onChange={handleChange}
        />
      </div>
      <br></br>
      <div>
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
      </div>
    </div>
  );
}

export default Basic();
