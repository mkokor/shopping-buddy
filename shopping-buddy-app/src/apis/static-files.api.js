import environment from "../configs/environment";

const createUrl = (path) => {
  return `${environment.shoppingBuddyApi.domain}${path}`;
};

export const StaticFileApi = {
  createUrl: createUrl,
};
