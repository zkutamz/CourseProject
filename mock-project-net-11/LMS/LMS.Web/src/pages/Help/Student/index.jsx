import React from 'react';
import { Link } from 'react-router-dom';

function Student(props) {
  const { faQs, helpTopics } = props.data;
  return (
    <div className="tab-pane fade" id="nav-student" role="tabpanel">
      <div className="tpc152">
        <div className="crse_content">
          <h3>Select a topic to search for help</h3>
        </div>
        <div className="section3126 mt-20">
          <div className="row">
            {helpTopics?.map((topic, i) => (
              <div key={i} className="col-md-4">
                <Link to={'/help-topic/' + topic.id} className="value_props50">
                  <div className="value_icon">
                    <i className={topic.iconURL} />
                  </div>
                  <div className="value_content">
                    <h4>{topic.title}</h4>
                    <p>{topic.description}</p>
                  </div>
                </Link>
              </div>
            ))}
          </div>
        </div>
      </div>
      <div className="tpc152">
        <div className="crse_content">
          <h3>Frequently Asked Questions</h3>
        </div>
        <div className="section3126 mt-20">
          <div className="row">
            {faQs?.map((record, i) => (
              <div key={i} className="col-md-4">
                <Link className="value_props51" to={'/faq/' + record.id}>
                  {record.question}
                </Link>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Student;
