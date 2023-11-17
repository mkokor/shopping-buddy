import "./App.css";
import { useGetShoppers } from "./hooks/useGetShoppers";
import { useGetShoppingItems } from "./hooks/useGetShoppingItems";

function App() {
  const [isLoading, error, shoppers] = useGetShoppers();
  const [loading, isError, shoppingItems] = useGetShoppingItems();
  console.log(shoppers);
  console.log(shoppingItems);
  return <div className="App"></div>;
}

export default App;
