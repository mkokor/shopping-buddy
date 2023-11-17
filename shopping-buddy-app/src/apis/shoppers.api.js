import { api } from "./config/axios.config";

export const ShoppersApi = {
  getAll: async function () {
    const response = await api.request({
      url: "/shoppers",
      method: "GET",
    });

    return response.data;
  },
};
