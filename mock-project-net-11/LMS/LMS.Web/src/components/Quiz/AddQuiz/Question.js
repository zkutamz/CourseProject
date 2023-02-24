import React from 'react';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Tab from '@mui/material/Tab';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import SingleQuiz from './SingleQuiz';
import { useState } from 'react';
import axiosClient from '../../../api/axiosClient';

function Question(props) {
  const data = props.data;

  const [value, setValue] = React.useState('1');

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <div>
      <TabContext value={value}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList onChange={handleChange} aria-label="lab API tabs example">
            <Tab label="Single choice" value="1" />
            <Tab label="Multiple choice" value="2" />
            <Tab label="Text" value="3" />
          </TabList>
        </Box>
        <TabPanel value="1">
          <SingleQuiz data={data} />
        </TabPanel>
        <TabPanel value="2">Item Two</TabPanel>
        <TabPanel value="3">Item Three</TabPanel>
      </TabContext>
    </div>
  );
}

export default Question;
