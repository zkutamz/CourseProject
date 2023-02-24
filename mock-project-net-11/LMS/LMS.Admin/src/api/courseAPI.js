import axiosClient from './axiosClient'

class CourseAPI {
  get = async (params) => {
    const url = `/Courses/${params}`
    return await axiosClient.get(url)
  }

  getCourseSections = async (params) => {
    const url = `/Courses/${params}/sections`
    return await axiosClient.get(url)
  }

  getNewestCourses = async () => {
    const url = `/Courses/get-newest-course`
    return await axiosClient.get(url)
  }
  async getFeaturedCourse() {
    const url = '/Courses/get-feature-course'
    return await axiosClient.get(url)
  }
  async getAverageRateOfCourse(id) {
    const url = '/Reviews/course/' + id
    return await axiosClient.get(url)
  }

  addToFavoriteCourses = async (params) => {
    const url = `/Courses/favorite-course/${params}`
    return await axiosClient.post(url)
  }

  getAllPurchasedOfSystem(paging) {
    const url = `Courses/PurchasedOfSystem?${paging}`
    return axiosClient.get(url, { paging })
  }
  getAllPurchasedOfStudent(params, paging) {
    const url = `Courses/PurchasedStudent?studentId=${params}&${paging}`
    return axiosClient.get(url, { params, paging })
  }
  getAllCourses(paging) {
    const url = `Courses/get-all?${paging}`
    return axiosClient.get(url, { paging })
  }
  disableCourses(params) {
    const url = `CourseManagement/DisableActiveCourseByIdAsync?courseid=${params}`
    const token =
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjMiLCJlbWFpbCI6Imluc3RydWN0b3JAbWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6IkluIFN0cnVjdG9yIiwianRpIjoiMWZkNGIxM2QtOTUyZi00MTY2LWE2ODctZWFmMTVkODE4ZDBhIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiSW5zdHJ1Y3RvciIsImV4cCI6MTcwMDA1MTI0OSwiaXNzIjoiaHR0cHM6Ly93ZWJhcGkuTE1TREIuY29tLnZuIiwiYXVkIjoiaHR0cHM6Ly93ZWJhcGkuTE1TREIuY29tLnZuIn0.lJWIDRwar1lhvjBxu_4Qi0OfsDmNzn-ltuSQT3DWEEQ'
    return axiosClient.get(url, { headers: { Authorization: `Bearer ${token}` } })
  }
  searchCourses(paging) {
    const url = `CourseManagement/SearchCourse?${paging}`
    const token =
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjMiLCJlbWFpbCI6Imluc3RydWN0b3JAbWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6IkluIFN0cnVjdG9yIiwianRpIjoiMWZkNGIxM2QtOTUyZi00MTY2LWE2ODctZWFmMTVkODE4ZDBhIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiSW5zdHJ1Y3RvciIsImV4cCI6MTcwMDA1MTI0OSwiaXNzIjoiaHR0cHM6Ly93ZWJhcGkuTE1TREIuY29tLnZuIiwiYXVkIjoiaHR0cHM6Ly93ZWJhcGkuTE1TREIuY29tLnZuIn0.lJWIDRwar1lhvjBxu_4Qi0OfsDmNzn-ltuSQT3DWEEQ'
    return axiosClient.get(url, { headers: { Authorization: `Bearer ${token}` } })
  }
  coursesComment(params, paging) {
    const url = `CourseManagement/GetTotalCommentOnCourse?courseId=${params}&${paging}`
    const token =
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjMiLCJlbWFpbCI6Imluc3RydWN0b3JAbWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6IkluIFN0cnVjdG9yIiwianRpIjoiMWZkNGIxM2QtOTUyZi00MTY2LWE2ODctZWFmMTVkODE4ZDBhIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiSW5zdHJ1Y3RvciIsImV4cCI6MTcwMDA1MTI0OSwiaXNzIjoiaHR0cHM6Ly93ZWJhcGkuTE1TREIuY29tLnZuIiwiYXVkIjoiaHR0cHM6Ly93ZWJhcGkuTE1TREIuY29tLnZuIn0.lJWIDRwar1lhvjBxu_4Qi0OfsDmNzn-ltuSQT3DWEEQ'
    return axiosClient.get(url, { headers: { Authorization: `Bearer ${token}` } })
  }
}

const courseApi = new CourseAPI()

export default courseApi
