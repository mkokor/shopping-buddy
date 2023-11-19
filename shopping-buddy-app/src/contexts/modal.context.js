import { createContext, useState } from "react";

export const ModalContext = createContext(null);

const ModalContextProvider = ({ children }) => {
  const [shoppingListModalOpened, setShoppingListModalOpened] = useState(false);
  const [successShoppingModalOpened, setSuccessShoppingModalOpened] =
    useState(false);

  return (
    <ModalContext.Provider
      value={{
        successShoppingModalOpened,
        setSuccessShoppingModalOpened,
        shoppingListModalOpened,
        setShoppingListModalOpened,
      }}
    >
      {children}
    </ModalContext.Provider>
  );
};

export default ModalContextProvider;
