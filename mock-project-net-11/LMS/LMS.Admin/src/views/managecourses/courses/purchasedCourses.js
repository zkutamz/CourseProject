import React, { useEffect, useState } from 'react'
import Pagination from '../../../components/Pagination/Pagination'
import moment from 'moment'
import queryString from 'query-string'
import SecondToHour from '../../../js/secondToHour'
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

const PurchasedCourses = (props) => {
  const params = useParams()
  const [purchased, setPurchased] = useState([])

  const [filters, setFilters] = useState({ PageNumber: 1, PageSize: 1 }) //search
  const [pagination, setPagination] = useState({
    currentPage: 1,
    PageSize: 2,
    totalCount: 1,
  })

  console.log('param:', props.location.state)
  useEffect(() => {
    const fetchListReview = async () => {
      const paramsString = queryString.stringify(filters)

      const PurchasedOfSystem = await courseApi.getAllPurchasedOfSystem(paramsString)
      console.log('PurchasedOfSystem', PurchasedOfSystem)
      setPurchased(PurchasedOfSystem.data.objects)
      setPagination(PurchasedOfSystem.data)
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
  return (
    <>
      <h1>Get All Purchase Course</h1>
      <CTable color="dark" striped>
        <CTableHead>
          <CTableRow>
            <CTableHeaderCell scope="col">Id</CTableHeaderCell>
            <CTableHeaderCell scope="col">Title</CTableHeaderCell>
            <CTableHeaderCell scope="col">Total Duration</CTableHeaderCell>
            <CTableHeaderCell scope="col">viewCount</CTableHeaderCell>
            <CTableHeaderCell scope="col">Images</CTableHeaderCell>
            <CTableHeaderCell scope="col">Activity</CTableHeaderCell>
            <CTableHeaderCell scope="col">Status</CTableHeaderCell>
          </CTableRow>
        </CTableHead>

        {purchased?.map((item, index) => (
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
                <CButton color="primary" variant="outline" shape="square" size="sm">
                  Show
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

export default PurchasedCourses
