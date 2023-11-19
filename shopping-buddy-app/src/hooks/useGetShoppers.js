import { useState, useEffect } from "react";

import { ShoppersApi } from "../apis/shoppers.api";

export const useGetShoppers = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [shoppers, setShoppers] = useState([]);

  const getShoppers = async () => {
    try {
      const data = await ShoppersApi.getAll();
      setShoppers(data);
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
      getShoppers();
    })();
  }, []);

  return [isLoading, shoppers, setShoppers, error];
};
