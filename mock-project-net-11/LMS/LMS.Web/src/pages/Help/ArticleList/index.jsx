import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { Link, useLocation } from 'react-router-dom';
import { useEffect } from 'react';
import articleAPI from '../../../api/articleAPI';
import Spinner from '../../../components/LoadingIcon/SpinnerIcon';
ArticleList.propTypes = {};

function ArticleList(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  const [articleList, setArticleList] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const fetchListArticle = async () => {
      const params = {
        HelpTopicId: query.get('topicID'),
      };
      try {
        const articleList = await articleAPI.getAllArticle(params);
        console.log(articleList.data);
        setArticleList(articleList.data);
        setLoading(false);
      } catch (error) {
        console.log('Failed to fetch list article: ', error.message);
      }
    };
    fetchListArticle();
  }, []);
  const listItems = articleList.map((article) => (
    <Link key={article.id} to={'/help/article-item?articleID=' + article.id} className="col-md-4">
      <div className="value_props51">{article.title}</div>
    </Link>
  ));
  return (
    <>
      {loading ? (
        <div style={{ textAlign: 'center' }}>
          <Spinner />
        </div>
      ) : (
        <div className="section3126 mt-20">
          <div className="row">{listItems}</div>
        </div>
      )}
    </>
  );
}

export default ArticleList;
