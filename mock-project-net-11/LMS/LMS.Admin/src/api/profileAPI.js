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
  getInstructorCourse(url){
    return axiosClient.get(url);
  },
  getUserInformation(params) {
    const url = `https://lmsnet11be.azurewebsites.net/api/Admin/user/${params}`;
    return axiosClient.get(url,{params});
  },
  getTotalSubcriber(url){
    return axiosClient.get(url);
  },
  getTotalSubcriberOfInstructor(params){
    const url= '/GetTotalSubscriptionOfAnInstructor'
    return axiosClient.get(url, { params });
  },
  getTotalCourseOfInstructor(params){
    const url= '/GetTotalSubscriptionOfAnInstructor'
    return axiosClient.get(url);
  },
  getTotalEnrollStudentOfInstructor(params){
    const url= '/GetTotalEnrollStudentsOfAnInstructor'
    return axiosClient.get(url, { params });
  },
  getTotalReviewOfInstructor(params){
    const url= '/GetTotalCourseReviewOfAnInstructor'
    return axiosClient.get(url, { params });
  },
  getInstructorInfo(params){
    const url=`/Users/${params}`;
    return axiosClient.get(url, { params });
  },
  getPopularInstructorProfile(){
    const url =`https://lmsnet11be.azurewebsites.net/api/Users/popular-instructors`;
    return axiosClient.get(url);
  }

};
export default profileAPI;
