import React, { useState, useEffect } from 'react';

function Basic({ onAddLessonBasic, myObject }) {
  const [title, setTitle] = useState(myObject.title);
  const [description, setDescription] = useState(myObject.content);
  const [titleIsValid, setTitleIsvalid] = useState(false);
  const [descriptionIsvalid, setDescriptionIsvalid] = useState(false);
  const [complete, setComplete] = useState(false);
  const titleCheckHandler = (e) => {
    if (e.target.value !== title) {
      console.log(e.target.value);
      setTitle(e.target.value);
      setTitleIsvalid(!titleIsValid);
    }
  };
console.log(myObject);
  const descriptionCheckHandler = (e) => {
    if (e.target.value !== description) {
      setDescription(e.target.value);
      setDescriptionIsvalid(!descriptionIsvalid);
      console.log(e.target.value);
    }
  };
  useEffect(() => {
    if(title !=="" && description !== ""){
      onAddLessonBasic({
        title,
        content: description,
      });
    }
  }, [descriptionIsvalid]);
  useEffect(() => {
    onAddLessonBasic({
      title,
      content: description,
    });
  }, [titleIsValid]);
  return (
    <div className="tab-pane fade show active" id="nav-basic" role="tabpanel">
      <div className="new-section mt-30">
        <div className="form_group">
          <label className="label25">Lecture Title*</label>
          <input
            className="form_input_1"
            type="text"
            placeholder={title ? myObject.title: "title here"}
            onChange={titleCheckHandler}
          />
        </div>
      </div>
      <div className="ui search focus lbel25 mt-30">
        <label>Description*</label>
        <div className="ui form swdh30">
          <div className="field">
            <textarea
              rows={3}
              name="description"
              placeholder={description ? myObject.content: "description here"}
              defaultValue={''}
              onChange={descriptionCheckHandler}
            />
          </div>
        </div>
      </div>
      {/* <div className="preview-dt">
        <span className="title-875">Free Preview</span>
        <label className="switch">
          <input type="checkbox" name="preview_op" defaultValue />
          <span />
        </label>
      </div> */}
    </div>
  );
}
export default Basic;
