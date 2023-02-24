import { AxiosResponse } from "axios";
import axiosClient from "./axiosClient";

class AssignmentAPI {
    createAssignmentAsync = async (assignment: object) : Promise<AxiosResponse> => {
        const url = '/Assignments';
        
        return await axiosClient.post(url, assignment);
    }; 

    updateAssignmentAsync = async(params: {
        id: number,
        assignment: object
    }) : Promise<AxiosResponse> => {
        const url = `/Assignments/${params.id}`;

        return await axiosClient.put(url, params.assignment);
    }
}

const assignmentAPI = new AssignmentAPI();

export default assignmentAPI;