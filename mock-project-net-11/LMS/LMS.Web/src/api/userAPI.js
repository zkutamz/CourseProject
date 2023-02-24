import axiosClient from './axiosClient';

class UserAPI {
    voteAUser = async (params) => {
        const url = `/Users/${params.userId}/vote?isUpVote=${params.isUpVote}`;
        return await axiosClient.put(url);
    }
}

const userAPI = new UserAPI();

export default userAPI;