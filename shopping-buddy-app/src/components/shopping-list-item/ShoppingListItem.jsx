import "./ShoppingListItem.css";

import { useContext } from "react";

import { images } from "../../constants";
import { ShoppingApi } from "../../apis/shopping.api";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";

export const ShoppingListItem = ({ item, shoppers, setShoppers }) => {
  const { selectedShopper, setSelectedShopper } = useContext(
    SelectedShopperContext
  );

  const decreaseItemQuantity = async () => {
    const currentlySelected = selectedShopper;
    const updatedShoppers = await ShoppingApi.decreaseQuantity(
      selectedShopper.id,
      item.id
    );
    setShoppers(updatedShoppers);
    setSelectedShopper(
      updatedShoppers.filter(
        (shopper) => shopper.id === currentlySelected.id
      )[0]
    );
  };

  return (
    <div className="wrapper">
      <div className="shopping-list-item-container">
        <div>{item.title}</div>
        <div className="shopping-list-container__quantity">{item.quantity}</div>
      </div>
      <div
        className="shopping-list-item-container__decrease-button"
        onClick={decreaseItemQuantity}
      >
        <img src={images.trash} alt={"decrease"} />
      </div>
    </div>
  );
};
