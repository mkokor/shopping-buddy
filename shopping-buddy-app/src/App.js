import "./App.css";
import { useGetShoppers } from "./hooks/useGetShoppers";

function App() {
  const [isLoading, error, shoppers] = useGetShoppers();
  console.log(shoppers);
  return <div className="App"></div>;
}

export default App;
