import "./App.css";

import { Dots } from "react-activity";

import { useGetShoppers } from "./hooks/useGetShoppers";
import { useGetShoppingItems } from "./hooks/useGetShoppingItems";
import { ShoppersContainer } from "./components/shoppers-container/ShoppersContainer";
import SelectedShopperContextProvider from "./contexts/selected-shopper.context";
import { ShoppingItemsContainer } from "./components/shopping-items-container/ShoppingItemsContainer";

const App = () => {
  const [shoppersLoading, shoppersError, shoppers, setShoppers] =
    useGetShoppers();
  const [shoppingItemsLoading, shoppingItemsError, shoppingItems] =
    useGetShoppingItems();

  if (shoppersLoading || shoppingItemsLoading) return <Dots />;

  return (
    <div className="App">
      <SelectedShopperContextProvider>
        <ShoppersContainer shoppers={shoppers} />
        <ShoppingItemsContainer
          shoppingItems={shoppingItems}
          shoppers={shoppers}
          setShoppers={setShoppers}
        />
      </SelectedShopperContextProvider>
    </div>
  );
};

export default App;
