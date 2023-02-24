import React from 'react';
import Spinner from '../../components/LoadingIcon/SpinnerIcon';
import { useState, useEffect } from 'react';
import { GetHelpInstructorAPI, GetHelpStudentAPI } from '../../api/helpAPI';
import Search from './Search';
import Tabs from './Tabs';
import Instructor from './Instructor';
import Student from './Student';
import { Route, Switch } from 'react-router-dom';
import ArticleList from './ArticleList';
import ArticleItem from './ArticleItem';

function Help(props) {
  const [studentData, setStudentData] = useState([]);
  const [instructorData, setInstructorData] = useState([]);
  const [loading, setLoading] = useState([true]);

  //   const token = localStorage.getItem('token').replace(/['"]+/g, '');
  //   const config = {
  //     headers: {
  //       Authorization: 'Bearer ' + token,
  //     },
  //   };
  useEffect(() => {
    GetHelpInstructorAPI().then((res) => {
      setLoading(false);
      setInstructorData(res.data);
    });
  }, []);
  useEffect(() => {
    GetHelpStudentAPI().then((res) => {
      setLoading(false);
      setStudentData(res.data);
    });
  }, []);

  return (
    <div>
      {loading ? (
        <div style={{ textAlign: 'center' }}>
          <Spinner></Spinner>
        </div>
      ) : (
        <div
        //className="_bg4586"
        >
          <Search />
          <Tabs />
          <div className="_215b17">
            <div className="container-fluid">
              <div className="row">
                <div className="col-lg-12">
                  <div className="course_tab_content">
                    <div className="tab-content" id="nav-tabContent">
                      <Switch>
                        <Route path="/help" exact>
                          <Instructor data={instructorData} />
                        </Route>
                        <Route path="/help/student" exact>
                          <Student data={studentData} />
                        </Route>
                        <Route path="/help/article-list">
                          <ArticleList />
                        </Route>
                        <Route path="/help/article-item">
                          <ArticleItem />
                        </Route>
                      </Switch>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default Help;
