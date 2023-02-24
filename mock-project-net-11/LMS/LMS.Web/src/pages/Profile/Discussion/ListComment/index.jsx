import React from 'react';
import PropTypes from 'prop-types';
import './styles.css';
import moment from 'moment';
import { useEffect, useState } from 'react';
ListComment.propTypes = {
  commentList: PropTypes.array,
  handleLikeClick: PropTypes.func,
  handleDisLikeClick: PropTypes.func,
  handleDeleteClick: PropTypes.func,
  handleReplyComment: PropTypes.func,
};
ListComment.defaultProps = {
  commentList: null,
  handleLikeClick: () => {},
  handleDisLikeClick: () => {},
  handleDeleteClick: () => {},
  handleReplyComment: () => {},
};
function ListComment({
  commentList,
  handleLikeClick,
  handleDisLikeClick,
  handleDeleteClick,
  handleReplyComment,
}) {
  const [dataLike, setDataLike] = useState({});
  const [dataDisLike, setDataDisLike] = useState({});
  const [reply, setReply] = useState(false);
  const [inputField, setInputField] = useState({
    content: '',
  });
  const inputsHandler = (e) => {
    setInputField({ [e.target.name]: e.target.value });
  };
  console.log(commentList);
  //
  const handleLikeButton = (id) => {
    let data = {
      discussionId: id,
      type: true,
    };
    handleLikeClick(data);
    data = {};
  };
  const handleDisLikeButton = (id) => {
    let data = {
      discussionId: id,
      type: false,
    };
    handleDisLikeClick(data);
    data = {};
  };
  const handleDeleteButton = (id) => {
    handleDeleteClick(id);
  };
  const handleReplyButton = (id) => {
    setReply(!reply);
  };
  const handleSubmitButton = (idComment) => {
    const data = {
      content: inputField.content,
      parentId: idComment,
    };
    handleReplyComment(data);
    setInputField('');
  };
  const listItems = commentList.map((comment) => (
    <div className="review_all120" key={comment.id}>
      <div className="review_item">
        <div className="review_usr_dt">
          <img src="/images/left-imgs/img-1.jpg" alt="" />
          <div className="rv1458">
            <h4 className="tutor_name1">{comment.user.firstName + comment.user.lastName}</h4>
            <span className="time_145">{moment(comment.updatedAt, moment.ISO_8601).fromNow()}</span>
          </div>
          <div className="eps_dots more_dropdown">
            <a href="#">
              <i className="uil uil-ellipsis-v" />
            </a>
            <div className="dropdown-content">
              <span>
                <i className="uil uil-comment-alt-edit" />
                Edit
              </span>
              <span onClick={() => handleDeleteButton(comment.id)}>
                <i className="uil uil-trash-alt" />
                Delete
              </span>
            </div>
          </div>
        </div>
        <p className="rvds10">{comment.content}</p>
        <div className="rpt101">
          <button onClick={() => handleLikeButton(comment.id)} className="report155 btnAction">
            <i className="uil uil-thumbs-up" /> {comment.likeCount}
          </button>
          <button onClick={() => handleDisLikeButton(comment.id)} className="report155 btnAction">
            <i className="uil uil-thumbs-down" /> {comment.disLikeCount}
          </button>
          <button onClick={() => handleReplyButton()} className="report155 ml-3 btnAction">
            Reply
          </button>
          {reply == false ? (
            <></>
          ) : (
            <div className="cmnt_group blockReply">
              <button
                onClick={() => handleSubmitButton(comment.id)}
                className="cmnt-btn btnReply"
                type="submit"
              >
                Comment
              </button>
              <input
                className="_cmnt001"
                type="text"
                name="content"
                onChange={inputsHandler}
                placeholder="Add a public comment"
                value={inputField.content || ''}
              />
            </div>
          )}
        </div>
      </div>
      {comment.childDiscussions.map((childComment) => (
        <div key={childComment.id} className="review_reply">
          <div className="review_item">
            <div className="review_usr_dt">
              <img src="/images/left-imgs/img-3.jpg" alt="" />
              <div className="rv1458">
                <h4 className="tutor_name1">
                  {childComment.user.firstName + childComment.user.lastName}
                </h4>
                <span className="time_145">
                  {moment(childComment.updatedAt, moment.ISO_8601).fromNow()}
                </span>
              </div>
              <div className="eps_dots more_dropdown">
                <a href="#">
                  <i className="uil uil-ellipsis-v" />
                </a>
                <div className="dropdown-content">
                  <span onClick={() => handleDeleteButton(childComment.id)}>
                    <i className="uil uil-trash-alt" />
                    Delete
                  </span>
                </div>
              </div>
            </div>
            <p className="rvds10">{childComment.content}</p>
            <div className="rpt101">
              <button
                onClick={() => handleLikeButton(childComment.id)}
                className="report155 btnAction"
              >
                <i className="uil uil-thumbs-up" /> {childComment.likeCount}
              </button>
              <button
                onClick={() => handleDisLikeButton(childComment.id)}
                className="report155 btnAction"
              >
                <i className="uil uil-thumbs-down" /> {childComment.disLikeCount}
              </button>
            </div>
          </div>
        </div>
      ))}
    </div>
  ));
  return <>{listItems}</>;
}

export default ListComment;
