import axiosClient from './axiosClient';

class AuthAPI {
  signup = async (params) => {
    const url = `/Auth/register`;
    return await axiosClient.post(url, params);
  };

  signin = async (params) => {
    const url = `/Auth/login`;
    return await axiosClient.post(url, params);
  };

  verify = async (token) => {
    const url = `/Auth/verify-email`;
    return await axiosClient.post(url, token);
  }
}

const authApi = new AuthAPI();

export default authApi;
