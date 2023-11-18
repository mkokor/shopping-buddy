import { createContext, useState } from "react";

export const SelectedShopperContext = createContext(null);

const SelectedShopperContextProvider = ({ children }) => {
  const [selectedShopper, setSelectedShopper] = useState(null);

  return (
    <SelectedShopperContext.Provider
      value={{ selectedShopper, setSelectedShopper }}
    >
      {children}
    </SelectedShopperContext.Provider>
  );
};

export default SelectedShopperContextProvider;
