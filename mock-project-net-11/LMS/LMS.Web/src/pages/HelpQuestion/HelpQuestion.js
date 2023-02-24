import React from 'react';
import { GetFaQAPI } from '../../api/helpAPI';
import { useState, useEffect } from 'react';
import Spinner from '../../components/LoadingIcon/SpinnerIcon';
import { useParams } from 'react-router-dom';
import './style.css';

function HelpQuestion(props) {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState([true]);
  const { id } = useParams();

  useEffect(() => {
    GetFaQAPI(id).then((res) => {
      setLoading(false);
      setData(res.data);
    });
  }, []);

  return (
    <div>
      {loading ? (
        <div style={{ textAlign: 'center' }}>
          <Spinner></Spinner>
        </div>
      ) : (
        <div className="FAQ">
          <h1>{data.question}</h1>
          <h3 style={{ textDecoration: 'underline' }}>Answer</h3>
          <div className="anwser">{data.answer}</div>
        </div>
      )}
    </div>
  );
}

export default HelpQuestion;
