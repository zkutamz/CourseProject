import axiosClient from './axiosClient';

const studyCourseAPI = {
  getOverviewCourse(params) {
    const url = `Courses/${params}/overview`;
    return axiosClient.get(url);
  },
  getSectionsStudy(params) {
    const url = `/Courses/${params}/sections-study`;    
    return axiosClient.get(url);
  },
  getLessonCurrent(params) {
    const url = `/Lessons/${params}`;    
    return axiosClient.get(url);
  },
  getQuizCurrent(params) {
    const url = `/Quizzes/${params}`;    
    return axiosClient.get(url);
  },
  getAssignmentCurrent(params) {
    const url = `/Assignments/${params}`;    
    return axiosClient.get(url);
  },
  getTotalItemCourse(params) {
    const url = `Courses/total-item/${params}`;    
    return axiosClient.get(url);
  },
  getTotalItemCourseOfUser(params) {
    console.log(params);
    const url = `Courses/${params.userId}/total-item-comleted-of-user/${params.courseId}`;    
    return axiosClient.get(url);
  },
  postUserCompleteLesson(data) {
    const url = '/LessonCompletions/create-lesson-completion';    
    console.log(data);
    return axiosClient.post(url,data);
  },
  getFileAssigmentDowload(params) {
    console.log(params);
    const url = `Files/download-file-from-azure`;    
    return axiosClient.get(url,{params});
  },
  postSubmitQuiz(data) {
    const url = '/QuizSubmissions/handle-quiz-submission';    
    return axiosClient.post(url,data);
  },
};
export default studyCourseAPI;
