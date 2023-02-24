import axiosClient from './axiosClient';

const profileAPI = {
  getAllComment(params) {
    const url = `/Discussions/${params.authorId}/paging`;
    return axiosClient.get(url, { params });
  },
  createComment(data) {
    const url = '/Discussions';
    return axiosClient.post(url, data);
  },
  async getInstructorCourse(){
    const url = '/CourseManagement/GetAllActiveCourseOfInstructor'
    return await axiosClient.get(url);
  },
  getUserInformation(params) {
    const url = `/Admin/user/${params}`;
    return axiosClient.get(url,{params});
  },
  getTotalSubcriber(url){
    return axiosClient.get(url);
  },
  getTotalSubcriberOfInstructor(params){
    const url= `/Instructor/${params}/GetTotalSubscriptionOfAnInstructor`
    return axiosClient.get(url);
  },
  getTotalCourseOfInstructor(params){
    const url= `/Instructor/${params}/GetTotalCourseOfAnInstructor`
    return axiosClient.get(url);
  },
  getTotalEnrollStudentOfInstructor(params){
    const url= `/Instructor/${params}/GetTotalEnrollStudentsOfAnInstructor`
    return axiosClient.get(url);
  },
  getTotalReviewOfInstructor(params){
    const url= `/Instructor/${params}/GetTotalCourseReviewOfAnInstructor`
    return axiosClient.get(url);
  },
  getInstructorInfo(params){
    const url=`/Users/${params}`;
    return axiosClient.get(url, { params });
  },
  // Dicussion
  likeOrdislikeDicussion(data){
    const url='/Discussions/react';
    return axiosClient.post(url,  data );
  },
  getPopularInstructorProfile(){
    const url =`/Instructor/popular-instructors`;
    return axiosClient.get(url);
  }

};
export default profileAPI;
