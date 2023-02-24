import React from 'react'
import moment from "moment";
import UpcomingCourse from './UpcomingCourse';

const UpcomingCoursesList = (props) => {
    return (

        <div class="tab-pane fade show active" id="pills-upcoming-courses" role="tabpanel">
                                <div class="table-responsive mt-30">
                                    <table class="table ucp-table">
                                    <thead class="thead-s">
                                    <tr>
                                    <th class="text-center" scope="col">Item No.</th>
                                    <th class="cell-ta">Title</th>
                                    <th class="text-center" scope="col">Thumbnail</th>
                                    <th class="text-center">Category</th>
                                    <th class="text-center">Price</th>
                                    <th class="text-center">Date</th>
                                    <th class="text-center" scope="col">Status</th>
                                    <th class="text-center" scope="col">Actions</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                        {/* {
                                            props.UpcomingCoursesList.map((course)=>(
                                                <UpcomingCourse
                                                id = {course.id}
                                                title={course.title}
                                                ></UpcomingCourse>
                                            ))
                                        } */}
                                    
                                    
                                    </tbody>
                                    </table>
                                </div>
                            </div>
    )
}

export default UpcomingCoursesList;