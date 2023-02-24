import axios from 'axios';
import axiosClient from './axiosClient';

const GetHelpStudentAPI = axiosClient.get('/Helps/1');
const GetHelpInstructorAPI = axiosClient.get('/Helps/2');

const GetFaQAPI = (id) => axiosClient.get('/FAQ/' + id);

const GetHelpSearchAPI = (keyword) => axiosClient.get('/Helps/search/' + keyword);

const GetHelpAPI = () => axios.all([GetHelpInstructorAPI, GetHelpStudentAPI]);

export { GetHelpAPI, GetFaQAPI, GetHelpSearchAPI };
