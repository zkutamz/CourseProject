import axiosClient from './axiosClient';

class FileAPI {

    async uploadFile(file) {
        //const url = '/Files/upload-file';
        const url = '/Files/upload-file-to-azure';
        const formData = new FormData();
        formData.append('file', file);
        return await axiosClient.post(url, formData);
    }
    
}

const fileApi = new FileAPI();

export default fileApi;
