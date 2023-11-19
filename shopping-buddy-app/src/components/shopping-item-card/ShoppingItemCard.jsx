import "./ShoppingItemCard.css";

import { useContext } from "react";

import { capitalizeText } from "../../utils/string.util";
import { StaticFileApi } from "../../apis/static-files.api";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";
import { ShoppingApi } from "../../apis/shopping.api";
import { Button } from "../button/Button";
import { SuccessShopingModal } from "../modals/SuccessShoppingModal";
import { images } from "../../constants";
import { ModalContext } from "../../contexts/modal.context";

export const ShoppingItemCard = ({ shoppingItem, shoppers, setShoppers }) => {
  const { setSuccessShoppingModalOpened } = useContext(ModalContext);
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
    setSuccessShoppingModalOpened(true);
    setSelectedShopper(
      updatedShoppers.filter(
        (shopper) => shopper.id === currentlySelected.id
      )[0]
    );
  };

  return (
    <div>
      <SuccessShopingModal
        icon={images.success}
        title="Success"
        message="Shopping item successfully added to shopping list"
      />
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
          <Button
            message={"Add to Shopping List"}
            onClick={addToShoppingList}
            backgroundColor="#77dd77"
          />
        </div>
      </div>
    </div>
  );
};
