import { createContext } from "react";

const AppContext = createContext<AppProviderProps>({
    isLoggedIn: false,
    setIsLoggedIn: () => {},
    userDetails:{name:"",email:"",phone:""},
    setUserDetails:()=>{}});

export  default AppContext;

interface AppProviderProps{
    isLoggedIn: boolean;
    setIsLoggedIn:(value:boolean)=>void,
    userDetails:LoggedInUserDetails
    setUserDetails:(value:LoggedInUserDetails)=>void  
}

interface LoggedInUserDetails {
  name: string;
  phone: string;
  email: string;
}