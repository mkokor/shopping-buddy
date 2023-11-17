import { api } from "./configs/axios.config";

const getAll = async () => {
  const response = await api.request({
    url: "/shoppers",
    method: "GET",
  });

  return response.data;
};

export const ShoppersApi = {
  getAll: getAll,
};
