import React from 'react';
import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { GetHelpSearchAPI } from '../../api/helpAPI';
import Spinner from '../../components/LoadingIcon/SpinnerIcon';
import { Link } from 'react-router-dom';

function HelpSearch(props) {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState([true]);
  const { keyword } = useParams();

  useEffect(() => {
    GetHelpSearchAPI(keyword).then((res) => {
      setLoading(false);
      setData(res.data.objects);
    });
  }, []);

  return (
    <div>
      {loading ? (
        <div style={{ textAlign: 'center' }}>
          <Spinner></Spinner>
        </div>
      ) : (
        <div>
          <h1>Search results found for "{keyword}"</h1>
          {data.length > 0 ? (
            <ul className="list-group list-group-flush">
              <h2>There are {data.length} article(s) found</h2>
              {data?.map((article, i) => (
                <div key={i}>
                  <li className="list-group-item">
                    <b>{article.title}</b>
                    <div>
                      <Link to={'/help/article-item?articleID=' + article.id}>
                        <b>read article</b>
                      </Link>
                    </div>
                  </li>
                </div>
              ))}
            </ul>
          ) : (
            <h3>No article found</h3>
          )}
        </div>
      )}
    </div>
  );
}

export default HelpSearch;
