import { axiosInstance } from "../axiosConfig"
import type { LoginFormData, RegisterFormData } from "../zodSchemas/loginRegister"

export const login = async (data:LoginFormData)=>{
    return axiosInstance.post("/login",data)
}

export const register = async (data:RegisterFormData)=>{
    return axiosInstance.post("/registerbyphone",data)
}