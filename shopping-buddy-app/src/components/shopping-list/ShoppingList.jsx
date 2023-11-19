import "./ShoppingList.css";

import { ShoppingListItem } from "../shopping-list-item/ShoppingListItem";

export const ShoppingList = ({ items, shoppers, setShoppers }) => {
  return (
    <div className="shopping-list-container">
      <div className="shopping-list-container__heading">
        <div>TITLE</div>
        <div>QUANTITY</div>
      </div>
      <div className="shopping-list-container__items">
        {items.map((item) => (
          <ShoppingListItem
            item={item}
            shoppers={shoppers}
            setShoppers={setShoppers}
          />
        ))}
      </div>
    </div>
  );
};
