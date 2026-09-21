import { useMutation } from "@tanstack/react-query";
import { register } from "../apicalls/apiCalls";
import type { RegisterFormData } from "../zodSchemas/loginRegister";
import axios from "axios";

export const useRegister = ()=>{

    let registrationStatus = false;
    const mutation = useMutation({
        mutationFn:(data:RegisterFormData)=>register(data),
        onSuccess() {
            registrationStatus = true;
        },
    });

    const registerUser = mutation.mutateAsync;

    let errorMessage:string|null = null;

    if(axios.isAxiosError(mutation.error)){
        errorMessage = mutation.error.response?.data?.message ?? mutation.error.message;
    }

    return {
        registerUser,
        isLoading:mutation.isPending,
        isError:mutation.isError,
        errorMessage,
        response:mutation.data,
        registrationStatus
    }
}