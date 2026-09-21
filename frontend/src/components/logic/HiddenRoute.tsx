import { useContext } from "react";
import AppContext from "../../context/appContext";
import { Navigate } from "react-router";

function HiddenRoute({ children }: { children: React.ReactNode }) {
  const { isLoggedIn } = useContext(AppContext);
  return !isLoggedIn ? children : <Navigate to="/" />;
}

export default HiddenRoute;
