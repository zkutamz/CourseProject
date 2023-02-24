import axiosClient from './axiosClient';

const instructorAPI = {
    GetTotalEnrollStudentsOfAnInstructor(params)
    {
        const url = `/${params}/GetTotalEnrollStudentsOfAnInstructor`;
        return axiosClient.get(url,{params});
    },
    GetTotalCourseOfAnInstructor(params)
    {
        const url = `/${params}/GetTotalCourseOfAnInstructor`;
        return axiosClient.get(url,{params});
    }
};
export default instructorAPI;