import "./Modal.css";

import { useContext } from "react";

import { Button } from "../button/Button";
import { ModalContext } from "../../contexts/modal.context";
import { capitalizeText } from "../../utils/string.util";

export const SuccessShopingModal = ({ title, message, icon }) => {
  const { successShoppingModalOpened, setSuccessShoppingModalOpened } =
    useContext(ModalContext);

  const close = () => {
    setSuccessShoppingModalOpened(false);
  };

  if (!successShoppingModalOpened) return <></>;

  return (
    <div className="modal-container">
      <div className="modal-content">
        <div className="modal-content__icon">
          <img src={icon} alt="icon" />
        </div>
        <h1 className="modal-content__title">{capitalizeText(title)}</h1>
        <p className="modal-content__message">{message}</p>
        <div className="modal-content__close-button">
          <Button message="Close" onClick={close} />
        </div>
      </div>
    </div>
  );
};
