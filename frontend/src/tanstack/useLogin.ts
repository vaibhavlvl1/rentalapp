import { login } from "../apicalls/apiCalls";
import {useMutation} from "@tanstack/react-query"
import type { LoginFormData } from "../zodSchemas/loginRegister";
import { useContext } from "react";
import AppContext from "../context/appContext";


export const useLogin = ()=>{
    const {setUserDetails,setIsLoggedIn} = useContext(AppContext)
    const mutation = useMutation({
        mutationFn: (data: LoginFormData) => login(data),
        onSuccess:(data)=>{
            // set user details to context to easy fetch
            console.log("login data",data);
            const loggedInUserDetails = data.data.user_data || null;
            //set token to localstorage 
            const token = data.data.data.token || null;
            setUserDetails(loggedInUserDetails);
            localStorage.setItem("token",token);
            setIsLoggedIn(true)
            
        }
    });
    
    return {
        login:mutation.mutate,
        isLoading:mutation.isPending,
        isError:mutation.isError,
        error:mutation.error,
        data:mutation.data
    }
} 