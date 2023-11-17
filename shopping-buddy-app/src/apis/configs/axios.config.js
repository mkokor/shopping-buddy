import axios from "axios";
import environment from "../../configs/environment";

export const api = axios.create({
  baseURL: `${environment.shoppingBuddyApi.domain}/api/v1`,
});

const errorHandler = (error) => {
  return Promise.reject(error);
};

api.interceptors.response.use(undefined, (error) => {
  return errorHandler(error);
});

export default api;
