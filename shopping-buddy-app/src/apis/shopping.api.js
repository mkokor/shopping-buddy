import { api } from "./configs/axios.config";

const addToShoppingList = async (shopperId, shoppingItemId) => {
  const response = await api.request({
    url: `/shopping?shopper=${shopperId}&shopping_item=${shoppingItemId}`,
    method: "POST",
  });

  return response.data;
};

export const ShoppingApi = {
  addToShoppingList: addToShoppingList,
};
