import { useContext } from "react";
import AppContext from "../../context/appContext";
import { Navigate } from "react-router";

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const { isLoggedIn } = useContext(AppContext);
  return isLoggedIn ? children : <Navigate to="/login" />;
}

export default ProtectedRoute;
