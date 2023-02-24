import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useLocation } from 'react-router-dom';
import articleAPI from '../../../api/articleAPI';

ArticleItem.propTypes = {};

function ArticleItem(props) {
  const [articleItem, setArticleItem] = useState([]);
  const [loading, setLoading] = useState(true);
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  useEffect(() => {
    const fetchListArticle = async () => {
      const params = {
        id: query.get('articleID'),
      };
      try {
        const article = await articleAPI.getArticleDetail(params);
        setArticleItem(article.data);
        setLoading(false);
      } catch (error) {
        console.log('Failed to fetch article detail: ', error.message);
      }
    };
    fetchListArticle();
  }, []);
  return (
    <div>
      <h1>{articleItem.title}</h1>
      <p>{articleItem.content}</p>
    </div>
  );
}

export default ArticleItem;
