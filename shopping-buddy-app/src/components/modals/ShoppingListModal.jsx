import "./Modal.css";

import { useContext } from "react";

import { ShoppingList } from "../shopping-list/ShoppingList";
import { Button } from "../button/Button";
import { ModalContext } from "../../contexts/modal.context";
import { capitalizeText } from "../../utils/string.util";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";

export const ShoppingListModal = ({ icon, shoppers, setShoppers }) => {
  const { selectedShopper } = useContext(SelectedShopperContext);
  const { shoppingListModalOpened, setShoppingListModalOpened } =
    useContext(ModalContext);

  const close = () => {
    setShoppingListModalOpened(false);
  };

  if (!shoppingListModalOpened) return <></>;

  return (
    <div className="modal-container">
      <div className="modal-content">
        <div className="modal-content__icon">
          <img src={icon} alt="icon" />
        </div>
        <h1 className="modal-content__title">
          {capitalizeText(`${selectedShopper.firstName}'s list`)}
        </h1>
        <div className="modal-content__content">
          <ShoppingList
            items={selectedShopper.shoppingList}
            shoppers={shoppers}
            setShoppers={setShoppers}
          />
        </div>
        <div className="modal-content__close-button">
          <Button message="Close" onClick={close} />
        </div>
      </div>
    </div>
  );
};
