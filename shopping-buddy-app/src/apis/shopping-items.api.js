import { api } from "./configs/axios.config";

export const ShoppingItemsApi = {
  getAll: async function () {
    const response = await api.request({
      url: "/shopping-items",
      method: "GET",
    });

    return response.data;
  },
};
