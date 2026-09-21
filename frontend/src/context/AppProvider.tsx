import { useState } from "react";
import AppContext from "./appContext";

function AppProvider({ children }: { children: React.ReactNode }) {
  const token = localStorage.getItem("token") || "";
  const [isLoggedIn, setIsLoggedIn] = useState<boolean>(token ? true : false);
  const [userDetails, setUserDetails] = useState({
    name: "",
    phone: "",
    email: "",
  });
  return (
    <AppContext.Provider
      value={{
        isLoggedIn: isLoggedIn,
        setIsLoggedIn,
        userDetails: userDetails,
        setUserDetails,
      }}
    >
      {children}
    </AppContext.Provider>
  );
}

export default AppProvider;
