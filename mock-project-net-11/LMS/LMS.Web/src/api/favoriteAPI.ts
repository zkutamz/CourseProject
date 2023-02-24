import { AxiosResponse } from "axios";
import axiosClient from "./axiosClient";

class FavoriteAPI {
    getFavoritesAsync = async (pagingRequest: {pageNumber: number, pageSize: number} | null = null) : Promise<AxiosResponse> => {
        const url = `/Courses/favorites${pagingRequest === null ? '' : `?PageNumber=${pagingRequest.pageNumber}&PageSize=${pagingRequest.pageSize}`}`;
        
        return await axiosClient.get(url);
    };

    addToFavoriteCoursesAsync = async (courseId : number): Promise<AxiosResponse>  => {
        const url = `/Courses/${courseId}/favorites`;
        return await axiosClient.post(url);
      };
    
    deleteACourseFromFavoritesAsync = async (courseId: number): Promise<AxiosResponse>  => {
        const url = `/Courses/${courseId}/favorites`;
        return await axiosClient.delete(url);
    };

    deleteCoursesFromFavoritesAsync = async () : Promise<AxiosResponse> => {
        const url = "/Courses/favorites";

        return await axiosClient.delete(url);
    };
}

const favoriteAPI = new FavoriteAPI();

export default favoriteAPI;