import axiosClient from './axiosClient';

class CourseAPI {
  get = async (params) => {
    const url = `/Courses/${params}`;
    return await axiosClient.get(url);
  };

  getCourseSections = async (params) => {
    const url = `/Courses/${params}/sections`;
    return await axiosClient.get(url);
  };

  getNewestCourses = async () => {
    const url = `/Courses/get-newest-course`;
    return await axiosClient.get(url);
  }
  async getFeaturedCourse() {
    const url = '/Courses/get-feature-course';
    return await axiosClient.get(url);
  }
  async getAverageRateOfCourse(id) {
    const url = '/Reviews/course/' + id;
    return await axiosClient.get(url);
  }

  async createBasicInforCourse(basicCourse) {
    const url = '/Courses/draft';
    return await axiosClient.post(url, basicCourse);
  }

  async createCourseMedia(courseMedia) {
    const url = '/Courses/draft/' + courseMedia.id + '/media';
    return await axiosClient.put(url, courseMedia);
  }

  async createCoursePrice(coursePrice) {
    const url = '/Courses/draft/' + coursePrice.id + '/price';
    return await axiosClient.put(url, coursePrice);
  }

  async createCourseFinish(id) {
    const url = '/Courses/draft/' + id + '/finish-create';
    return await axiosClient.put(url);
  }
}

const courseApi = new CourseAPI();

export default courseApi;
