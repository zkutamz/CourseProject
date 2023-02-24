import React, { useEffect, useState } from 'react'

import moment from 'moment'
import queryString from 'query-string'
import SecondToHour from '../../../js/secondToHour'
import {
  CFormInput,
  CImage,
  CInputGroup,
  CInputGroupText,
  CTable,
  CTableBody,
  CTableDataCell,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
} from '@coreui/react'
import { useParams } from 'react-router-dom/cjs/react-router-dom.min'
import courseApi from 'src/api/courseAPI'
import Pagination from '../../../components/Pagination/Pagination'
import CIcon from '@coreui/icons-react'
import { cibLogstash } from '@coreui/icons'
const Courses = () => {
  const params = useParams()

  const [purchasedStudent, setPurchasedStudent] = useState([])
  const [filters, setFilters] = useState({ PageNumber: 1, PageSize: 1 }) //search
  const [studentId, setStudentId] = useState(0) //search
  const [pagination, setPagination] = useState({
    currentPage: 1,
    PageSize: 1,
    totalCount: 1,
  })
  useEffect(() => {
    const fetchListReview = async () => {
      const paramsString = queryString.stringify(filters)

      const PurchasedOfStudent = await courseApi.getAllPurchasedOfStudent(studentId, paramsString)
      console.log('test', PurchasedOfStudent)
      setPagination(PurchasedOfStudent.data)
      setPurchasedStudent(PurchasedOfStudent.data.objects)
    }
    fetchListReview()
  }, [filters, studentId])
  function handlePageChange(newPage) {
    console.log(newPage)
    setFilters({
      ...filters,
      PageNumber: newPage,
    })
  }
  function handleChange(e) {
    const studentId = e.target.value
    setStudentId(studentId)
    console.log(studentId)
  }
  return (
    <>
      <CInputGroup size="sm" className="mb-3">
        <CInputGroupText id="inputGroup-sizing-sm">Student Id</CInputGroupText>
        <CFormInput
          type="number"
          // value={this.state.value}
          onChange={handleChange}
          aria-label="Sizing example input"
          aria-describedby="inputGroup-sizing-sm"
          placeholder="please enter student Id to show"
        />
      </CInputGroup>

      <h1>Get All Purchase Course Of Student</h1>
      <CTable color="dark" striped>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col">Id</CTableHeaderCell>
            <CTableHeaderCell scope="col">Completed Percent</CTableHeaderCell>
            <CTableHeaderCell scope="col">Certification Date</CTableHeaderCell>
            <CTableHeaderCell scope="col">score</CTableHeaderCell>
            <CTableHeaderCell scope="col">Images</CTableHeaderCell>
            <CTableHeaderCell scope="col">Status</CTableHeaderCell>
          </CTableRow>
        </CTableHead>

        {purchasedStudent?.map((item, index) =>
          item.enrollCourses.map((i, index) => (
            <CTableBody key={i.id}>
              <CTableRow>
                <CTableHeaderCell scope="row">{i.id}</CTableHeaderCell>
                <CTableDataCell>{i.completedPercent}</CTableDataCell>
                <CTableDataCell>{i.certificationDate}</CTableDataCell>
                <CTableDataCell>{i.score}</CTableDataCell>
                <CTableDataCell>
                  <CImage src={i.certificationURL} width={100} height={100} />
                </CTableDataCell>
                <CTableDataCell>{i.isDelete.toString()}</CTableDataCell>
              </CTableRow>
            </CTableBody>
          )),
        )}
      </CTable>
    </>
  )
}

export default Courses
