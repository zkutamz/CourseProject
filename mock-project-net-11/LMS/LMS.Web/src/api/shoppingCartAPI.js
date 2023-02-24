import axiosClient from "./axiosClient";

class ShoppingCartApi {

    async getAllShoppingCart() {
        return await axiosClient.get("/ShoppingCart/ShoppingCart");
    }
}

export default ShoppingCartApi;