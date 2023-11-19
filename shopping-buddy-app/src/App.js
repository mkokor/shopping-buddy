import "./App.css";

import { Dots } from "react-activity";
import "react-activity/dist/library.css";

import SelectedShopperContextProvider from "./contexts/selected-shopper.context";
import ModalContextProvider from "./contexts/modal.context";
import { useGetShoppers } from "./hooks/useGetShoppers";
import { useGetShoppingItems } from "./hooks/useGetShoppingItems";
import { ShoppersContainer } from "./components/shoppers-container/ShoppersContainer";
import { ShoppingItemsContainer } from "./components/shopping-items-container/ShoppingItemsContainer";

const App = () => {
  const [shoppersLoading, shoppers, setShoppers, shoppersError] =
    useGetShoppers();
  const [shoppingItemsLoading, shoppingItems, itemsError] =
    useGetShoppingItems();

  if (shoppersLoading || shoppingItemsLoading || shoppersError || itemsError)
    return (
      <div className="loader-wrapper">
        <div>
          <Dots
            color="#727981"
            size={20}
            speed={1}
            animating={true}
            style={{ display: "inline-block" }}
          />
        </div>
      </div>
    );

  return (
    <div className="App">
      <ModalContextProvider>
        <SelectedShopperContextProvider>
          <ShoppersContainer shoppers={shoppers} setShoppers={setShoppers} />
          <ShoppingItemsContainer
            shoppingItems={shoppingItems}
            shoppers={shoppers}
            setShoppers={setShoppers}
          />
        </SelectedShopperContextProvider>
      </ModalContextProvider>
    </div>
  );
};

export default App;
