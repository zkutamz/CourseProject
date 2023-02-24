import React, { useEffect, useState } from 'react'
import Pagination from '../../../components/Pagination/Pagination'
import moment from 'moment'
import queryString from 'query-string'
import SecondToHour from '../../../js/secondToHour'
import SearchReview from './searchReview'
import {
  CButton,
  CImage,
  CTable,
  CTableBody,
  CTableDataCell,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
} from '@coreui/react'
import { useParams } from 'react-router-dom/cjs/react-router-dom.min'
import courseApi from 'src/api/courseAPI'
import { DataGrid, GridToolbar } from '@mui/x-data-grid'
import { useDemoData } from '@mui/x-data-grid-generator'
import { Link } from 'react-router-dom'

const Courses = () => {
  const params = useParams()
  const [courses, setCourses] = useState([])
  const [filters, setFilters] = useState({ PageNumber: 1, PageSize: 1 }) //search
  const [pagination, setPagination] = useState({
    currentPage: 1,
    PageSize: 2,
    totalCount: 1,
  })

  useEffect(() => {
    const fetchListReview = async () => {
      const paramsString = queryString.stringify(filters)
      if (filters.keyword === '' || filters.keyword === undefined) {
        const courses = await courseApi.getAllCourses(paramsString)
        console.log('1')
        setCourses(courses.data.objects)
        setPagination(courses.data)
      } else {
        const courses = await courseApi.searchCourses(paramsString)
        console.log(courses)
        setCourses(courses.data.objects)
        setPagination(courses.data)
      }
    }
    fetchListReview()
  }, [filters])

  function handlePageChange(newPage) {
    console.log(newPage)
    setFilters({
      ...filters,
      PageNumber: newPage,
    })
  }
  function DisableCourses(e) {
    const fetchListReview = async () => {
      const disable = await courseApi.disableCourses(e.target.value)
      console.log('disable', disable)
    }
    fetchListReview()
  }
  function handleFiltersChange(newFilters) {
    setFilters({
      ...filters,
      PageNumber: 1,
      keyword: newFilters.searchTerm,
    })
  }

  return (
    <>
      <SearchReview onSubmit={handleFiltersChange} />
      <h1>Get All Course</h1>

      <CTable color="dark" striped>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col">Id</CTableHeaderCell>
            <CTableHeaderCell scope="col">Title</CTableHeaderCell>
            <CTableHeaderCell scope="col">Total Duration</CTableHeaderCell>
            <CTableHeaderCell scope="col">viewCount</CTableHeaderCell>
            <CTableHeaderCell scope="col">Images</CTableHeaderCell>
            <CTableHeaderCell scope="col">Activity</CTableHeaderCell>
            <CTableHeaderCell scope="col">View Comment</CTableHeaderCell>
            <CTableHeaderCell scope="col">Status</CTableHeaderCell>
          </CTableRow>
        </CTableHead>

        {courses?.map((item, index) => (
          <CTableBody key={item.id}>
            <CTableRow>
              <CTableHeaderCell scope="row">{item.id}</CTableHeaderCell>
              <CTableDataCell>{item.title}</CTableDataCell>
              <CTableDataCell>{SecondToHour(item.totalDuration)}</CTableDataCell>
              <CTableDataCell>{item.viewCount}</CTableDataCell>
              <CTableDataCell>
                <CImage src={item.thumbNailUrl} width={100} height={100} />
              </CTableDataCell>
              <CTableDataCell>
                <div className="small text-medium-emphasis">Last login</div>
                <strong>{moment(item.createdAt, moment.ISO_8601).fromNow()}</strong>
              </CTableDataCell>
              <CTableDataCell>
                <CButton
                  onClick={(e) => DisableCourses(e, 'value')}
                  value={item.id}
                  color="primary"
                  variant="outline"
                  shape="square"
                  size="sm"
                >
                  <Link to={{ pathname: '/managecourses/coursesComment', state: item.id }}>
                    View comment
                  </Link>
                </CButton>
              </CTableDataCell>
              <CTableDataCell>
                <CButton
                  onClick={(e) => DisableCourses(e, 'value')}
                  value={item.id}
                  color="primary"
                  variant="outline"
                  shape="square"
                  size="sm"
                >
                  Disable
                </CButton>
              </CTableDataCell>
            </CTableRow>
          </CTableBody>
        ))}
        <Pagination pagination={pagination} onPageChange={handlePageChange} />
      </CTable>
    </>
  )
}

export default Courses
