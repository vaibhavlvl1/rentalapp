import {z} from "zod";

export const loginSchema = z.object({
    phone:z.string().regex(/^\d{10}$/, "Enter valid phone number"),
    password:z.string().min(8,"Password Must be Atleast 8 Characters Long")
});


export const registerSchema = z.object({
    fullname:z.string().min(3,"Enter Valid Name"),
    phone:z.string().regex(/^\d{10}$/, "Enter valid phone number"),
    email:z.email().optional().or(z.literal("")),
    password:z.string().min(8,"Password Must be of atleast 8 chars"),
    confirmPassword:z.string()
}).refine((data)=> data.password === data.confirmPassword,{message:"Passwords donot match",path:['confirmPassword']})

export type LoginFormData = z.infer<typeof loginSchema>;
export type RegisterFormData = z.infer<typeof registerSchema>;