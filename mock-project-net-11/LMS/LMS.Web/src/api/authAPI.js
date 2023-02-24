import axiosClient from './axiosClient';

class AuthAPI {
  signUp = async (params) => {
    const url = `/Auth/register`;
    return await axiosClient.post(url, params);
  };

  signIn = async (params) => {
    const url = `/Auth/login`;
    return await axiosClient.post(url, params);
  };

  verify = async (token) => {
    const url = `/Auth/verify-email`;
    return await axiosClient.post(url, token);
  }

  forgotPassword = async (email) => {
    const url = `/Auth/forgot-password`;
    return await axiosClient.post(url, email);
  }

  resetPassword = async (params) => {
    const url = `/Auth/reset-password`;
    return await axiosClient.post(url, params);
  }

  refreshTokenAsync = async () => {
    const url = '/Auth/refresh-token';

    return await axiosClient.post(url);
  }
}

const authApi = new AuthAPI();

export default authApi;
