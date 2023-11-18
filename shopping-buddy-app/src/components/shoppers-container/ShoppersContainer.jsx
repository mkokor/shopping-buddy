import "./ShoppersContainer.css";

import { useContext } from "react";

import { ShopperCard } from "../shopper-card/ShopperCard";
import { ShoppingList } from "../shopping-list/ShoppingList";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";
import { images } from "../../constants";

export const ShoppersContainer = ({ shoppers }) => {
  const { selectedShopper, setSelectedShopper } = useContext(
    SelectedShopperContext
  );

  if (!selectedShopper && shoppers.length > 0) setSelectedShopper(shoppers[0]);

  return (
    <div className="shoppers-container">
      <div className="shoppers-container__shoppers">
        {shoppers.map((shopper) => (
          <ShopperCard key={shopper.id} shopper={shopper} />
        ))}
      </div>
      <div className="shoppers-container__shopping-list-button">
        <img src={images.cart} alt="shopping_list" />
      </div>
      {false && (
        <div className="shoppers-container__shopping-list">
          {selectedShopper ? (
            <ShoppingList shoppingList={selectedShopper.shoppingList} />
          ) : (
            <></>
          )}
        </div>
      )}
    </div>
  );
};
