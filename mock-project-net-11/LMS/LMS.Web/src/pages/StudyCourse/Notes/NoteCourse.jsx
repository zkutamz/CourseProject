import { useEffect, useState } from 'react';
import { CKEditor } from '@ckeditor/ckeditor5-react';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import SaveIcon from '@mui/icons-material/Save';
import notesAPI from '../../../api/noteAPI';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import NativeSelect from '@mui/material/NativeSelect';
import ReactHtmlParser from 'react-html-parser';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import IconButton from '@mui/material/IconButton';
import Divider from '@mui/material/Divider';
import Grid from '@mui/material/Grid';
import './style.css';
import PropTypes from 'prop-types';
NoteCourse.propTypes = {
  courseId: PropTypes.number.isRequired,
  lessonId: PropTypes.number.isRequired,
  userId: PropTypes.number.isRequired
};

function NoteCourse(props) {
  const { courseId, lessonId, userId } = props;
  const [notes, setNotes] = useState([]);
  const [isSubmit, setIsSubmit] = useState(false);
  const [isDelete, setIsDelete] = useState(false);
  

  const [requestParams, setRequestParams] = useState({
      PageNumber: 0,
      PageSize: 0,
      courseId:courseId,
      lessonId:lessonId,
      filterByAllLesson: false,
      sortByOldest: false
  });
  if(lessonId!=requestParams.lessonId || courseId!=requestParams.courseId){
    setRequestParams({
      ...requestParams,
      lessonId: lessonId,
      courseId: courseId
    })
  }
  const [inputData, setInputData] = useState('');
  const [editorData, setEditorData] = useState('');
  const [currentEnrollCourse,setCurrentEnrollCourse]= useState(0);
  async function getNotes(params) {
    await notesAPI.getNotes(params)
      .then(response => {
        setNotes(response.data.objects);
      })
      .catch(error => console.log(error))
  }
  function handleInputChange(e, editor) {
    const data = editor.getData();
    setInputData(data);
  }

  function sortByOldestSelect(e) {
    var status = e.target.value;
    setRequestParams({ ...requestParams, sortByOldest: status })
  }

  function filterByAllLesson(e) {
    const status = e.target.value;
    setRequestParams({ ...requestParams, filterByAllLesson: status })
  }

  async function createNote() {
    const noteData = {
      content: inputData,
      enrollCourseId: currentEnrollCourse,
      lessonId: lessonId
    }
    await notesAPI.createNote(noteData).catch(error => console.log(error))
    setIsSubmit(!isSubmit);
  }

  async function deleteNote(params) {
    await notesAPI.deleteNote(params).catch(error => console.log(error))
    setIsDelete(!isDelete)
  }
  function handleCancel() {
    setEditorData(' ');
  }
  useEffect(async()=>{
    let createData={
      courseId: courseId,
      userId: userId
    }
    await notesAPI.getEnrollCourseId(createData)
    .then(response=>{
        setCurrentEnrollCourse(response.data);
    })
    .catch(error=>console.log(error))
    
  },[])
  useEffect(async () => {
    await getNotes(requestParams);
  }, [requestParams, isSubmit, isDelete])
  return (
    <>
      <div>
        <CKEditor
          editor={ClassicEditor}
          onChange={handleInputChange}
          data={editorData}
        />
          <Button style={{float:'right', marginTop:'5px'}} onClick={createNote} color="secondary" variant="outlined" endIcon={<SaveIcon />}>
            Save
          </Button>
          {/* <Button onClick={handleCancel} color="secondary" variant="contained" endIcon={<SaveIcon />}>
              Clear
            </Button> */}
        </div>
      <Grid container spacing={2}>
        <Grid item sx={12} md={6}>
          <Box sx={{ maxWidth: "40%" }}>
            <FormControl fullWidth>
              <InputLabel variant="standard" htmlFor="uncontrolled-native">
                Filter By All Lesson
              </InputLabel>
              <NativeSelect
                onChange={filterByAllLesson}
                defaultValue={"false"}
                inputProps={{
                  name: 'age',
                  id: 'uncontrolled-native',
                }}
              >
                <option value="true">True</option>
                <option value="false">False</option>
              </NativeSelect>
            </FormControl>
          </Box>
        </Grid>
        <Grid item sx={12} md={6}>
          <Box className="" sx={{ maxWidth: "40%" }}>
            <FormControl fullWidth>
              <InputLabel variant="standard" htmlFor="uncontrolled-native">
                Sort By Oldest
              </InputLabel>
              <NativeSelect
                onChange={sortByOldestSelect}
                defaultValue="false"
                inputProps={{
                  name: 'age',
                  id: 'uncontrolled-native',
                }}
              >
                <option value="true">True</option>
                <option value="false">False</option>
              </NativeSelect>
            </FormControl>
          </Box>
        </Grid>
      </Grid>
      <br />
      <List >
        {
          notes ? notes.map(note => (
            <ListItem key={note.id}>
              <ListItemText>{ReactHtmlParser(note.content)}</ListItemText>
              <hr />
              <IconButton onClick={() => deleteNote(note.id)} edge="end" aria-label="delete">
                <DeleteIcon />
              </IconButton>
              <Divider />

            </ListItem>
          )) : <></>
        }


      </List>
    </>

  )
}

export default NoteCourse;
