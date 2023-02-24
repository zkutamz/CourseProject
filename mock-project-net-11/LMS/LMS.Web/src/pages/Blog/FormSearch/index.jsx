import React from 'react';
import PropTypes from 'prop-types';

FormSearch.propTypes = {};

function FormSearch(props) {
  return (
    <div className="col-lg-3 col-md-5">
      <div className="fcrse_3 mt-50">
        <ul className="blogleft12">
          <li>
            <div className="explore_search blg152">
              <div className="ui search focus">
                <div className="ui left icon input swdh11 swdh15">
                  <input className="prompt srch_explore" type="text" placeholder="Search" />
                  <i className="uil uil-search-alt icon icon2" />
                </div>
              </div>
            </div>
          </li>
          <li>
            <a
              href="#collapse1"
              className="category-topics cate-right collapsed"
              data-toggle="collapse"
              role="button"
              aria-expanded="true"
              aria-controls="collapse1"
            >
              Labels
            </a>
            <div className="collapse" id="collapse1" style={{}}>
              <ul className="category-card">
                <li>
                  <a href="#" className="category-item1 active">
                    All
                  </a>
                  <a href="#" className="category-item1">
                    Students
                  </a>
                  <a href="#" className="category-item1">
                    Instructors
                  </a>
                  <a href="#" className="category-item1">
                    Ideas &amp; Opinions
                  </a>
                  <a href="#" className="category-item1">
                    Edututs+ News
                  </a>
                  <a href="#" className="category-item1">
                    Social Innovation
                  </a>
                </li>
              </ul>
            </div>
            <a
              href="#collapse2"
              className="category-topics cate-right collapsed"
              data-toggle="collapse"
              role="button"
              aria-expanded="false"
              aria-controls="collapse2"
            >
              Archive
            </a>
            <div className="collapse" id="collapse2" style={{}}>
              <ul className="category-card">
                <li>
                  <a href="#" className="category-item1">
                    January 2020
                  </a>
                  <a href="#" className="category-item1">
                    February 2020
                  </a>
                  <a href="#" className="category-item1">
                    March 2020
                  </a>
                  <a href="#" className="category-item1">
                    April 2020
                  </a>
                </li>
              </ul>
            </div>
          </li>
          <li>
            <div className="socl148">
              <button
                className="twiter158"
                data-href="#"
                onclick="sharingPopup(this);"
                id="twitter-share"
              >
                <i className="uil uil-twitter ic45" />
                Follow
              </button>
              <button
                className="facebook158"
                data-href="#"
                onclick="sharingPopup(this);"
                id="facebook-share"
              >
                <i className="uil uil-facebook ic45" />
                Follow
              </button>
            </div>
          </li>
          <li>
            <div className="help_link">
              <p>Learn More</p>
              <a href="#">Cursus Help Center</a>
            </div>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default FormSearch;
