import React from 'react'
import moment from "moment";

const Course = (props) => {
    return (
        <tr>
                                                    <td className="text-center">{props.id}</td>
                                                    <td>{props.title}</td>
                                                    <td className="text-center">{moment(props.publishDate,moment.ISO_8601).fromNow()}</td>
                                                    <td className="text-center">{props.sales}</td>
                                                    <td className="text-center">{props.parts}</td>
                                                    <td className="text-center"><a href="#">{props.categoryName}</a></td>
                                                    <td className="text-center"><b className="course_active">Active</b></td>
                                                    <td className="text-center">
                                                        <a href="#" title="Edit" className="gray-s"><i className="uil uil-edit-alt" /></a>
                                                        <a href="#" title="Delete" className="gray-s"><i className="uil uil-trash-alt" /></a>
                                                    </td>
                                                </tr>
    )
}

export default Course;