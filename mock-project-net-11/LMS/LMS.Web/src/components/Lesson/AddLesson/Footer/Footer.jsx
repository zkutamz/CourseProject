import React from 'react';

import PropTypes from 'prop-types';

Footer.propTypes = {};



function Footer({hanldeClickButtonAddLesson,myObject}) {
    const handleAddLesson=()=>{
        if(myObject.title !=="" && myObject.content!=="")
        {
            hanldeClickButtonAddLesson(true);
        }
        console.log(myObject);
    }
    const handleCloseLesson=()=>{
        console.log("Close");
    }
  return (
    <div className="modal-footer">
      <button className="main-btn cancel" data-dismiss="modal" >
        Close
      </button>
      <button className="main-btn" onClick={handleAddLesson}>
        Add Lecture
      </button>
    </div>
  );
}

export default Footer;
