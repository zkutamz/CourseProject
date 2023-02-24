import axiosClient from './axiosClient';

class File {
    uploadFileAsync = async (file: any) => {
        const url = '/Files/upload-file';

        const formData = new FormData();

        formData.append('file', file);

        return await axiosClient.post(url, formData);
    };

    uploadFilesAsync = async (files: any) => {
        const url = '/Files/upload-files';

        let formData = new FormData();

        for (const key in files) {
            if (Object.prototype.hasOwnProperty.call(files, key)) {
                formData.append('files', files[key]);
            }
        }

        return await axiosClient.post(url, formData);
    };

    uploadFileToAzureAsync = async (file: any) => {
        const url = '/Files/upload-file-to-azure';

        const formData = new FormData();

        formData.append('file', file);

        return await axiosClient.post(url, formData);
    };

    uploadFilesToAzureAsync = async (files: any) => {
        const url = '/Files/upload-files-to-azure';

        let formData = new FormData();

        for (const key in files) {
            if (Object.prototype.hasOwnProperty.call(files, key)) {
                formData.append('files', files[key]);
            }
        }

        return await axiosClient.post(url, formData);
    };

    deleteFileAsync = async(fileName: string) => {
        const url = `/Files?fileName=${fileName}`;

        return await axiosClient.delete(url);
    };

    deleteFileFromAzureAsync = async(fileName: string) => {
        const url = `/Files/delete-file-from-azure?fileName=${fileName}`;

        return await axiosClient.delete(url);
    };
}

const file = new File();

export default file;