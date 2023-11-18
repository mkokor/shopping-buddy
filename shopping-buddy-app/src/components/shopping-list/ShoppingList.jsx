import "./ShoppingList.css";

import { ShoppingListItem } from "../shopping-list-item/ShoppingListItem";

export const ShoppingList = ({ shoppingList }) => {
  return (
    <div>
      <h1>Shopping List</h1>
      {shoppingList.map((item) => (
        <ShoppingListItem key={item.id} shoppingListItem={item} />
      ))}
    </div>
  );
};
