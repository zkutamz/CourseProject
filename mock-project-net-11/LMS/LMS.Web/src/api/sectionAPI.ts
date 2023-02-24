import { AxiosResponse } from 'axios';
import axiosClient from './axiosClient';
import SectionEdit from '../model/Section/sectionEdit';

class SectionAPI {
    createSectionAsync = async (section : object) : Promise<AxiosResponse> => {
        const url = '/Sections';

        return await axiosClient.post(url, section);
    }

    editSectionAsync = async(section: SectionEdit) : Promise<AxiosResponse> => {
        const url = '/Sections';

        return await axiosClient.put(url, section);
    }

    deleteSectionAsync = async (sectionId: number) : Promise<AxiosResponse> => {
        const url = `/Sections/${sectionId}`;

        return await axiosClient.delete(url);
    }
}

const sectionApi = new SectionAPI();

export default sectionApi;