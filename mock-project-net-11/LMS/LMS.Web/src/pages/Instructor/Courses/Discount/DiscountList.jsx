import React from 'react'
import moment from "moment";

const Discount = (props) => {
    return (

<div class="tab-pane fade show active" id="pills-discount" role="tabpanel">
<div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
<div class="panel panel-default">
<div class="panel-heading" role="tab" id="headingOne">
<div class="panel-title adcrse1250">
<a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
New Discount
</a>
</div>
</div>
<div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
<div class="panel-body adcrse_body">
<div class="row">
<div class="col-lg-8">
<div class="discount_form">
<div class="row">
<div class="col-lg-6 col-md-6">
<div class="mt-20 lbel25">
<label>Course*</label>
</div>
<select class="ui hj145 dropdown cntry152 prompt srch_explore">
<option value="">Select Course</option>
<option value="1">Course Title Here</option>
<option value="2">Course Title Here</option>
<option value="3">Course Title Here</option>
<option value="4">Course Title Here</option>
<option value="5">Course Title Here</option>
<option value="6">Course Title Here</option>
<option value="7">Course Title Here</option>
</select>
</div>
<div class="col-lg-6 col-md-6">
<div class="ui search focus mt-20 lbel25">
<label>Discount Amount</label>
<div class="ui left icon input swdh19">
<input class="prompt srch_explore" type="number" name="off" value="" required="" min="1" max="99" placeholder="Percent (eg. 20 for 20%)"/>
</div>
</div>
</div>
<div class="col-lg-6 col-md-6">
<div class="ui search focus mt-20 lbel25">
<label>Start Date</label>
<div class="ui left icon input swdh19">
<input class="prompt srch_explore datepicker-here" type="text" data-language="en" placeholder="dd/mm/yyyy"/>
</div>
</div>
</div>
<div class="col-lg-6 col-md-6">
<div class="ui search focus mt-20 lbel25">
<label>End Date</label>
<div class="ui left icon input swdh19">
<input class="prompt srch_explore datepicker-here" type="text" data-language="en" placeholder="dd/mm/yyyy"/>
</div>
</div>
</div>
<div class="col-lg-6 col-md-6">
<button class="discount_btn" type="submit">Save Changes</button>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div class="table-responsive mt-30">
<table class="table ucp-table">
<thead class="thead-s">
<tr>
<th class="text-center" scope="col">Item No.</th>
<th class="cell-ta">Course</th>
<th class="text-center" scope="col">Start Date</th>
<th class="text-center" scope="col">End Date</th>
<th class="text-center" scope="col">Discount</th>
<th class="text-center" scope="col">Status</th>
<th class="text-center" scope="col">Actions</th>
</tr>
</thead>
<tbody>

</tbody>
</table>
</div>
</div>
                                                
                                                    )
                                                }
                                                
                                                export default Discount;