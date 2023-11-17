import { api } from "./configs/axios.config";

const getAll = async () => {
  const response = await api.request({
    url: "/shopping-items",
    method: "GET",
  });

  return response.data;
};

export const ShoppingItemsApi = {
  getAll: getAll,
};
