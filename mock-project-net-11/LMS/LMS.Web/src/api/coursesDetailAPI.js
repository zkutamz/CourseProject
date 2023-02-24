import axiosClient from './axiosClient';

const coursesDetailAPI = {
  getAllReviewByCoursesId(params, paging) {
    const url = `Reviews/course/${params}?${paging}`;
    return axiosClient.get(url, { params, paging });
  },
  getRatingAverage(params) {
    const url = `Reviews/course/${params}/rating-average`;
    return axiosClient.get(url, { params });
  },

  getRatingLevel(params) {
    const url = `Reviews/couse/${params}/rating-level`;
    return axiosClient.get(url, { params });
  },
  searchReviewByContent(paging) {
    const url = `review?${paging}`;
    return axiosClient.get(url, { paging });
  },
  getReviewStudentHaveToday(params) {
    const url = 'Reviews/TheLatest5Reviews';
    return axiosClient.get(url);
  },
};
export default coursesDetailAPI;
