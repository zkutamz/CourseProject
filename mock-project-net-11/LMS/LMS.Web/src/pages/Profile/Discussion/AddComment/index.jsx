import React, { useState } from 'react';
import PropTypes from 'prop-types';
AddComment.propTypes = {
  onSubmit: PropTypes.func,
};
AddComment.defaultProps = {
  onSubmit: null,
};
function AddComment({ onSubmit }) {
  const [inputField, setInputField] = useState({
    comment: '',
  });

  const inputsHandler = (e) => {
    setInputField({ [e.target.name]: e.target.value });
  };

  const submitButton = () => {
    const data = {
      content: inputField.comment,
      parentId: '',
    };
    onSubmit(data);
    setInputField('');
  };
  return (
    <div className="cmmnt_1526">
      <div className="cmnt_group">
        <div className="img160">
          <img src="/images/hd_dp.jpg" alt="" />
        </div>
        <input
          className="_cmnt001"
          type="text"
          name="comment"
          onChange={inputsHandler}
          placeholder="Add a public comment"
          value={inputField.comment || ''}
        />
      </div>
      <button onClick={submitButton} className="cmnt-btn" type="submit">
        Comment
      </button>
    </div>
  );
}

export default AddComment;
