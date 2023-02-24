import React, { useState, useEffect, useContext } from 'react';
import PropTypes from 'prop-types';
import './styles.css';
import AddComment from './AddComment';
import ListComment from './ListComment';
import profileAPI from '../../../api/profileAPI';
import Spinner from '../../../components/LoadingIcon/SpinnerIcon';
import AuthContext from '../../../store/auth-context';
Discussion.propTypes = {};

function Discussion({ isLoggedIn }) {
  const [commentList, setCommentList] = useState([]);
  const [update, setUpdate] = useState(true);
  const [loading, setLoading] = useState(true);
  const authContext = useContext(AuthContext);
  //console.log(authContext.userId);
  let userID = authContext.userId;
  useEffect(() => {
    const fetchListComment = async () => {
      const params = {
        authorId: userID,
        PageNumber: 1,
        PageSize: 5,
      };
      try {
        const commentList = await profileAPI.getAllComment(params);
        setCommentList(commentList.data.value);
        setLoading(false);
      } catch (error) {
        console.log('Failed to fetch list comments: ', error.message);
      }
    };
    fetchListComment();
  }, [update]);
  function AddCommentBlock() {
    const status = isLoggedIn;
    if (status) {
      return <AddComment onSubmit={handleAddCommentClick} />;
    }
    return <></>;
  }
  const handleAddCommentClick = (data) => {
    const addComment = async () => {
      try {
        console.log(data);
        await profileAPI.createComment(data);
        setUpdate(!update);
      } catch (error) {
        console.log('Failed to add comment: ', error.message);
      }
    };
    addComment();
  };
  const handleReplyComment = (data) => {
    console.log(data);
    const replyComment = async () => {
      try {
        await profileAPI.createComment(data);
        setUpdate(!update);
      } catch (error) {
        console.log('Failed to add comment: ', error.message);
      }
    };
    replyComment();
  };
  const handleLikeClick = (params) => {
    console.log(params);
    const likeOrdislikeComment = async () => {
      try {
        console.log('Like');
        await profileAPI.likeOrdislikeDicussion(params);
        setUpdate(!update);
      } catch (error) {
        console.log('Failed to like comment: ', error.message);
      }
    };
    likeOrdislikeComment();
  };
  const handleDisLikeClick = (params) => {
    const likeOrdislikeComment = async () => {
      console.log(params);
      try {
        await profileAPI.likeOrdislikeDicussion(params);
        setUpdate(!update);
      } catch (error) {
        console.log('Failed to dislike comment: ', error.message);
      }
    };
    likeOrdislikeComment();
  };
  const handleDeleteClick = (idCommnet) => {
    console.log(idCommnet);
  };
  return (
    <div className="tab-pane fade" id="nav-reviews" role="tabpanel">
      <div className="student_reviews">
        <div className="row">
          <div className="col-lg-12">
            <div className="review_right">
              <div className="review_right_heading">
                <h3>Discussions</h3>
              </div>
            </div>
            <AddCommentBlock />
            {loading ? (
              <div style={{ textAlign: 'center' }}>
                <Spinner />
              </div>
            ) : (
              <ListComment
                handleLikeClick={handleLikeClick}
                handleDisLikeClick={handleDisLikeClick}
                handleDeleteClick={handleDeleteClick}
                handleReplyComment={handleReplyComment}
                commentList={commentList}
              />
            )}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Discussion;
