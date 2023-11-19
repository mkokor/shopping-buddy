import { api } from "./configs/axios.config";

const addToShoppingList = async (shopperId, shoppingItemId) => {
  const response = await api.request({
    url: `/shopping?shopper=${shopperId}&shopping_item=${shoppingItemId}`,
    method: "POST",
  });

  return response.data;
};

const decreaseQuantity = async (shopperId, shoppingItemId) => {
  const response = await api.request({
    url: `/shopping/quantity?shopper=${shopperId}&shopping_item=${shoppingItemId}`,
    method: "DELETE",
  });

  return response.data;
};

export const ShoppingApi = {
  addToShoppingList: addToShoppingList,
  decreaseQuantity: decreaseQuantity,
};
