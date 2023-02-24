import React from 'react';
import { useState } from 'react';
import { withRouter } from 'react-router-dom';
import { useHistory } from 'react-router-dom';

function Search(props) {
  const [data, setData] = useState('');
  const history = useHistory();

  const find = (e) => {
    if (e.keyCode === 13) {
      history.push('/help-search/' + data);
    }
  };
  return (
    <div className="_215v12">
      <div className="container-fluid">
        <div className="row">
          <div className="col-lg-12">
            <div className="section3125">
              <div className="row justify-content-md-center">
                <div className="col-md-6">
                  <div className="help_stitle">
                    <h2>How may we help you?</h2>
                    <div className="explore_search">
                      <div className="ui search focus">
                        <div className="ui left icon input swdh11">
                          <input
                            className="prompt srch_explore"
                            type="text"
                            placeholder="Search for solutions"
                            onChange={(e) => setData(e.target.value)}
                            onKeyDown={(e) => find(e)}
                          />
                          <i className="uil uil-search-alt icon icon2" />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default withRouter(Search);
