import React from 'react'
import Course from './Course';

const CoursesList = (props) => {
    return ( 
        
        
          <div class="tab-pane fade show active" id="pills-my-courses" role="tabpanel">
              <div class="table-responsive mt-30">
                  <table class="table ucp-table">
                  <thead class="thead-s">
                  <tr>
                  <th class="text-center" scope="col">Item No.</th>
                  <th>Title</th>
                  <th class="text-center" scope="col">Publish Date</th>
                  <th class="text-center" scope="col">Sales</th>
                  <th class="text-center" scope="col">Parts</th>
                  <th class="text-center" scope="col">Category</th>
                  <th class="text-center" scope="col">Status</th>
                  <th class="text-center" scope="col">Action</th>
                  </tr>
                  </thead>
                   <tbody>
                    {
                        props.courses.map((course)=>(
                            <Course 
                            key={course.id}
                            id={course.id}
                            title={course.title}
                            publishDate={course.publishDate}
                            categoryName={course.categoryName}
                            sales={course.sales}
                            parts={course.parts}
                            />
                        ))
                    }
                    </tbody>
                  </table>
              </div>
          </div>                                 
    );
}

export default CoursesList;