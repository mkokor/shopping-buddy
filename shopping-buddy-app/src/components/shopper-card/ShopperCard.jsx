import "./ShopperCard.css";

import { useContext } from "react";

import { capitalizeText } from "../../utils/string.util";
import { StaticFileApi } from "../../apis/static-files.api";
import { SelectedShopperContext } from "../../contexts/selected-shopper.context";

export const ShopperCard = ({ shopper }) => {
  const { selectedShopper, setSelectedShopper } = useContext(
    SelectedShopperContext
  );

  const updateSelectedShopper = () => {
    if (selectedShopper.id === shopper.id) return;
    setSelectedShopper(shopper);
  };

  return (
    <div
      className={`shopper-card-container`}
      id={
        selectedShopper !== null && selectedShopper.id === shopper.id
          ? "selected"
          : null
      }
      onClick={updateSelectedShopper}
    >
      <div className="shopper-card-container__image-container">
        <img src={StaticFileApi.createUrl(shopper.image)} alt="shopper" />
      </div>
      <div className="shopper-card-container__shopper-name-container">
        {capitalizeText(`${shopper.firstName} ${shopper.lastName}`)}
      </div>
    </div>
  );
};
