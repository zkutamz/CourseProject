import React from 'react'
import moment from "moment";

const UpcomingCourse = (props) => {
    return (
<tr>
                                    <td class="text-center">{props.id}</td>
                                    <td class="cell-ta">{props.title}</td>
                                    <td class="text-center"><a href="#">View</a></td>
                                    <td class="text-center"><a href="#">Web Development</a></td>
                                    <td class="text-center">$15</td>
                                    <td class="text-center">9 April 2020</td>
                                    <td class="text-center"><b class="course_active">Pending</b></td>
                                    <td class="text-center">
                                    <a href="#" title="Edit" class="gray-s"><i class="uil uil-edit-alt"></i></a>
                                    <a href="#" title="Delete" class="gray-s"><i class="uil uil-trash-alt"></i></a>
                                    </td>
                                    </tr>

    )
}

export default UpcomingCourse;