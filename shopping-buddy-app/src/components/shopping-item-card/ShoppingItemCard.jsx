import "./ShoppingItemCard.css";

import { useContext } from "react";

import { capitalizeText } from "../../utils/string.util";
import { StaticFileApi } from "../../apis/static-files.api";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";
import { ShoppingApi } from "../../apis/shopping.api";

export const ShoppingItemCard = ({ shoppingItem, shoppers, setShoppers }) => {
  const { selectedShopper, setSelectedShopper } = useContext(
    SelectedShopperContext
  );

  const getQuantity = (shoppingItem) => {
    return shoppers
      .map((shopper) => shopper.shoppingList)
      .filter((shoppingList) => shoppingList.length !== 0)
      .filter(
        (shoppingList) =>
          shoppingList.filter((item) => item.id === shoppingItem.id).length !==
          0
      ).length;
  };

  const isAvailable = (shoppingItem) => {
    if (!selectedShopper) return false;
    if (
      selectedShopper.shoppingList.filter((item) => item.id === shoppingItem.id)
        .length !== 0
    )
      return true;
    return getQuantity(shoppingItem) >= 3 ? false : true;
  };

  const addToShoppingList = async () => {
    if (!isAvailable(shoppingItem)) return;
    const currentlySelected = selectedShopper;
    const updatedShoppers = await ShoppingApi.addToShoppingList(
      selectedShopper.id,
      shoppingItem.id
    );
    setShoppers(updatedShoppers);
    setSelectedShopper(currentlySelected);
  };

  return (
    <div
      className={`shopping-item-card-container ${
        !isAvailable(shoppingItem) ? "disabled" : ""
      }`}
    >
      <div className="">
        <img
          src={StaticFileApi.createUrl(shoppingItem.image)}
          alt="shopping_item"
        />
      </div>
      <div className="shopping-item-card-container__title-container">
        {capitalizeText(shoppingItem.title)}
      </div>
      <div>
        <button onClick={addToShoppingList}>Add to Shopping List</button>
      </div>
    </div>
  );
};
