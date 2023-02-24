import React, { useEffect, useRef, useState } from 'react';
import PropTypes from 'prop-types';

Clock.propTypes = {};
Clock.defaultProps = {};
function Clock({ totalTime }) {
  // console.log(totalTime);
  const Ref = useRef(null);
  const [timer, setTimer] = useState('00:00');
  const [update, setUpdate] = useState(true);
  const [totalCurent, setTotalCurent] = useState(totalTime);
  const getTimeRemaining = (total) => {
    const minutes = Math.floor(total / 60);
    const seconds = Math.floor((total % 60) % 60);
    return {
      total,
      minutes,
      seconds,
    };
  };
  const startTimer = (e) => {
    let { total, minutes, seconds } = getTimeRemaining(totalCurent);
    if (total >= 0) {
      setTimer(
        (minutes > 9 ? minutes : '0' + minutes) + ':' + (seconds > 9 ? seconds : '0' + seconds)
      );
    }
  };
  const clearTimer = (e) => {
    if (Ref.current) clearInterval(Ref.current);
    const id = setInterval(() => {
      // console.log(totalCurent);
      if (totalCurent > 0) {
        setTotalCurent(totalCurent - 1);
        setUpdate(!update);
        startTimer(totalCurent);
      }
    }, 1000);
    Ref.current = id;
  };
  useEffect(() => {
    clearTimer();
  }, [update]);
  return (
    <div className="timer_time">
      <h4 id="timer">{timer}</h4>
      <p>Minutes</p>
    </div>
  );
}

export default Clock;
