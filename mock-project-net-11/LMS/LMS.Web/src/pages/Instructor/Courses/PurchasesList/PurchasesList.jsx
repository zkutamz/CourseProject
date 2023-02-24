import React from 'react'
import moment from "moment";
import Purchase from './Purchase';



const PurchasesList = (props) => {
    return (

        <div class="tab-pane fade show active" id="pills-my-purchases" role="tabpanel">
                                <div class="table-responsive mt-30">
                                    <table class="table ucp-table">
                                    <thead class="thead-s">
                                    <tr>
                                    <th class="text-center" scope="col">Item No.</th>
                                    <th class="cell-ta" scope="col">Title</th>
                                    <th class="cell-ta" scope="col">Vendor</th>
                                    <th class="cell-ta" scope="col">Category</th>
                                    <th class="text-center" scope="col">Delivery Type</th>
                                    <th class="text-center" scope="col">Price</th>
                                    <th class="text-center" scope="col">Purchase Date</th>
                                    <th class="text-center" scope="col">Actions</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                        {
                                            props.coursesPurchase.map((course)=>(
                                            <Purchase 
                                            id = {course.enrollCourses.id}
                                            studentId={course.enrollCourses.studentId}
                                            price={course.price}
                                            ></Purchase>
                                            
                                            ))
                                        }
                                    

                                    </tbody>
                                    </table>
                                </div>
                            </div>
    )
}

export default PurchasesList;