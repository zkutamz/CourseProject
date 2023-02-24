
import React from 'react'
import moment from "moment";


const Purchase = (props) => {
    return (

     
                                        
                                                 <tr>
                                                <td class="text-center">{props.id}</td>
                                                <td class="cell-ta">Course Title Here</td>
                                                <td class="cell-ta"><a href="#">{props.studentId}</a></td>
                                                <td class="cell-ta"><a href="#">Category Here</a></td>
                                                <td class="text-center"><b class="course_active">Download</b></td>
                                                <td class="text-center">${props.price}</td>
                                                <td class="text-center">25 March 2020</td>
                                                <td class="text-center">
                                                <a href="#" title="Download" clsass="gray-s"><i class="uil uil-download-alt"></i></a>
                                                <a href="#" title="Delete" class="gray-s"><i class="uil uil-trash-alt"></i></a>
                                                <a href="#" title="Print" class="gray-s"><i class="uil uil-print"></i></a>
                                                </td>
                                            </tr>
                                            
    )
}

export default Purchase;