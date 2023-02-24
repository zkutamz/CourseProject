import axiosClient from './axiosClient';

class CourseManagementAPI {
    getAllActiveCourseOfInstructor = async (params) => {
        const url = `/CourseManagement/GetAllActiveCourseOfInstructor`;
        return await axiosClient.get(url);
    };
    getAllPurchaseCourseOfInstructor = async (params) => {
        const url = `/CourseManagement/GetAllPurchaseCourseOfInstructor`;
        return await axiosClient.get(url);
    };
    getAllPendingCourseOfInstructor = async (params) => {
        const url = `/CourseManagement/GetAllPendingCourseOfInstructor`;
        return await axiosClient.get(url);
    };
    getAllDiscountCourseOfInstructor = async (params) => {
        const url = `/CourseManagement/GetAllDiscountCourseOfInstructor`;
        return await axiosClient.get(url);
    };
}

const courseManagementAPI = new CourseManagementAPI();

export default courseManagementAPI;
