import { useState, useEffect } from "react";

import { ShoppingItemsApi } from "../apis/shopping-items.api";

export const useGetShoppingItems = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [shoppingItems, setShoppingItems] = useState([]);

  const getShoppingItems = async () => {
    try {
      const data = await ShoppingItemsApi.getAll();
      setShoppingItems(data);
    } catch (error) {
      setError(error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    setIsLoading(true);
    setError(null);
    (async () => {
      getShoppingItems();
    })();
  }, []);

  return [isLoading, shoppingItems, error];
};
