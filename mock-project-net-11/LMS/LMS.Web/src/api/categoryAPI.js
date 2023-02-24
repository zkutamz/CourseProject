import axiosClient from "./axiosClient";

class CategoryApi {

    async getCategories() {
        return await axiosClient.get("/Categories/paging");
    }

    async getAllCategories() {
        return await axiosClient.get("/Categories");
    }
}

const categoryApi = new CategoryApi();

export default categoryApi;
