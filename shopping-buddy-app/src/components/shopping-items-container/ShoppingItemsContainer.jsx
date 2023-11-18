import "./ShoppingItemsContainer.css";

import { useState } from "react";

import { ShoppingItemCard } from "../shopping-item-card/ShoppingItemCard";
import { images } from "../../constants";

export const ShoppingItemsContainer = ({
  shoppingItems,
  shoppers,
  setShoppers,
}) => {
  const [searchInput, setSearchInput] = useState("");

  const handleInputChange = (input) => {
    setSearchInput(input.target.value);
  };

  return (
    <div className="shopping-items-container">
      <div className="shopping-items-container__search-field">
        <input
          type="text"
          value={searchInput}
          onChange={handleInputChange}
          placeholder="Search for an items..."
        />
        <div>
          <img src={images.search} alt="search" />
        </div>
      </div>
      <div className="shopping-items-container__items">
        {shoppingItems.map((shoppingItem) => {
          const condition =
            searchInput === "" ||
            shoppingItem.title
              .toLowerCase()
              .startsWith(searchInput.toLowerCase());
          return condition ? (
            <ShoppingItemCard
              key={shoppingItem.id}
              shoppingItem={shoppingItem}
              shoppers={shoppers}
              setShoppers={setShoppers}
            />
          ) : (
            <></>
          );
        })}
      </div>
    </div>
  );
};
