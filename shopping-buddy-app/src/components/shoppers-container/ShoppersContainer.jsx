import "./ShoppersContainer.css";

import { useContext } from "react";

import { ShopperCard } from "../shopper-card/ShopperCard";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";
import { ModalContext } from "../../contexts/modal.context";
import { ShoppingListModal } from "../modals/ShoppingListModal";
import { images } from "../../constants";

export const ShoppersContainer = ({ shoppers, setShoppers }) => {
  const { setShoppingListModalOpened } = useContext(ModalContext);
  const { selectedShopper, setSelectedShopper } = useContext(
    SelectedShopperContext
  );

  if (!selectedShopper && shoppers.length > 0) setSelectedShopper(shoppers[0]);

  const openShoppingList = () => {
    setShoppingListModalOpened(true);
  };

  return (
    <div>
      <ShoppingListModal
        icon={images.cart}
        shoppers={shoppers}
        setShoppers={setShoppers}
      />
      <div className="shoppers-container">
        <div className="shoppers-container__shoppers">
          {shoppers.map((shopper) => (
            <ShopperCard key={shopper.id} shopper={shopper} />
          ))}
        </div>
        <div
          className="shoppers-container__shopping-list-button"
          onClick={openShoppingList}
        >
          <img src={images.cart} alt="shopping_list" />
        </div>
      </div>
    </div>
  );
};
