import axiosClient from './axiosClient';
const baseURL = 'https://lmsnet11be.azurewebsites.net';
const notesAPI = {
    async getNotes(params) {
        const url = configGetNotesURL(params);
        return await axiosClient.get(url)
    },
    async createNote(params) {
        const url = '/Notes';
        return await axiosClient.post(url, params)
    },
    async deleteNote(params) {
        const url = `/Notes/SoftDeleteNote?noteId=${params}`;
        return await axiosClient.put(url);
    },
    async getEnrollCourseByCourseId(params) {
        const url = `/Notes/SoftDeleteNote?noteId=${params}`;
        return await axiosClient.put(url);
    },
    async getEnrollCourseId(params) {
        const url = configGetEnrollCourseURL(params)
        return await axiosClient.get(url);
    }
};


function configGetNotesURL(params) {
    let url = new URL("/api/Notes", baseURL);
    if (params.PageNumber != 0)
        url.searchParams.append("PageNumber", params.PageNumber);
    if (params.PageSize != 0)
        url.searchParams.append("PageSize", params.PageSize);
    if (params.courseId != 0)
        url.searchParams.append("courseId", params.courseId);
    if (params.lessonId != 0)
        url.searchParams.append("lessonId", params.lessonId);
    if (params.filterByAllLesson != false)
        url.searchParams.append("filterByAllLesson", params.filterByAllLesson);
    if (params.sortByOldest != false)
        url.searchParams.append("sortByOldest", params.sortByOldest);
    return url;
}
function configGetEnrollCourseURL(params) {
    let url = new URL('/Notes/GetEnrollCourseId', baseURL);
    // let url = new URL('/api/Notes/GetEnrollCourseId', 'https://localhost:5001');
    if (params.courseId > 0)
        url.searchParams.append('courseId', params.courseId);
    if (params.userId > 0) {
        url.searchParams.append('studentId', params.userId)
    }
    return url;
}

export default notesAPI;
