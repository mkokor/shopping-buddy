import "./ShoppersContainer.css";

import { useContext } from "react";

import { ShopperCard } from "../shopper-card/ShopperCard";
import { ShoppingList } from "../shopping-list/ShoppingList";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";

export const ShoppersContainer = ({ shoppers }) => {
  const { selectedShopper, setSelectedShopper } = useContext(
    SelectedShopperContext
  );

  if (!selectedShopper && shoppers.length > 0) setSelectedShopper(shoppers[0]);

  return (
    <div className="shopper-container">
      <div className="shopper-container__shoppers">
        {shoppers.map((shopper) => (
          <ShopperCard key={shopper.id} shopper={shopper} />
        ))}
      </div>
      {false && (
        <div className="shopper-container__shopping-list">
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
