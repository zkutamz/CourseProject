import axiosClient from './axiosClient';

const articleAPI = {
  getAllArticle(params) {
    const url = '/Helps/all-article?';
    return axiosClient.get(url, { params });
  },
  getArticleDetail(params) {
    const url = `/Helps/article/${params.id}`;
    return axiosClient.get(url);
  },
};
export default articleAPI;
