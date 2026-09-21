import { useForm } from "react-hook-form";
import login_image from "../../assets/login_image.jpg";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  registerSchema,
  type RegisterFormData,
} from "../../zodSchemas/loginRegister";
import { useRegister } from "../../tanstack/useRegister";
import CircularProgress from "@mui/material/CircularProgress";
import { useNavigate } from "react-router";
import { useEffect } from "react";

interface SignupProps {
  //setIsNewUser: Dispatch<SetStateAction<boolean>>;
  handleIsNewUser: () => void;
}

function SignupModal({ handleIsNewUser }: SignupProps) {
  const navigate = useNavigate();

  //tanstack query

  const { registerUser, isLoading, isError, errorMessage, registrationStatus } =
    useRegister();

  // hook form
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({ resolver: zodResolver(registerSchema) });

  //form submit
  const onSubmit = async (data: RegisterFormData) => {
    try {
      const result = await registerUser(data);
      console.log("api response", result);
    } catch (e) {}
  };

  // To navigate to login after succesfull registration

  useEffect(() => {
    if (registrationStatus == true) {
      navigate("/login");
    }
  }, [registrationStatus]);

  return (
    <div className="flex h-full justify-center items-center">
      <div className="flex bg-gray-900 h-1/2 w-full">
        {/* rhs */}
        <div className="h-full flex-1">
          <img
            className=" h-full w-full object-cover opacity-50"
            src={login_image}
            alt="login image"
          />
        </div>
        {/* lhs */}
        <div className="flex flex-col h-full flex-1 justify-center items-center">
          {/* register form */}
          <form
            onSubmit={handleSubmit(onSubmit)}
            className="w-96 bg-gray-800 flex flex-col  p-5"
          >
            <div className="mb-5">
              <input
                className="border-0 border-b w-full  border-b-white outline-0 p-1"
                type="text"
                placeholder="Name"
                {...register("fullname")}
              />
              {errors.fullname && (
                <p className="form-error">
                  {errors.fullname.message as String}
                </p>
              )}
            </div>

            <div className="mb-5">
              <input
                className="border-0 border-b w-full  border-b-white outline-0 p-1"
                type="tel"
                placeholder="Phone"
                {...register("phone")}
              />
              {errors.phone && (
                <p className="form-error">{errors.phone.message as String}</p>
              )}
            </div>

            <div className="mb-5">
              <input
                className="border-0 border-b w-full  border-b-white outline-0 p-1"
                type="tel"
                placeholder="Email"
                {...register("email")}
              />
              {errors.email && (
                <p className="form-error">{errors.email.message as String}</p>
              )}
            </div>

            <div className="mb-3">
              <input
                className="border-0 border-b w-full  border-b-white outline-0 p-1"
                type="password"
                placeholder="password"
                {...register("password")}
              />
              {errors.password && (
                <p className="form-error">
                  {errors.password.message as String}
                </p>
              )}
            </div>

            <div className="mb-3">
              <input
                className="border-0 border-b w-full  border-b-white outline-0 p-1"
                type="password"
                placeholder="confirm password"
                {...register("confirmPassword")}
              />
              {errors.confirmPassword && (
                <p className="form-error">
                  {errors.confirmPassword.message as String}
                </p>
              )}
            </div>
            <button
              className="bg-gray-600 hover:bg-gray-500 w-auto px-2 py-1 text-xs rounded-xs cursor-pointer disabled:pointer-events-none"
              type="submit"
              disabled={isLoading}
            >
              {isLoading ? <CircularProgress size={20} /> : "Register"}
            </button>
            <p className="mt-5 text-xs">
              Already have an Account ? Login{" "}
              <span
                className="underline cursor-pointer"
                onClick={handleIsNewUser}
              >
                Here
              </span>
              {""}
            </p>
          </form>
          {isError && <p className="form-error">{errorMessage}</p>}
          {registrationStatus && (
            <p className="form-success">
              {"User Has been Registered. Going to Login Page"}
            </p>
          )}
        </div>
      </div>
    </div>
  );
}

export default SignupModal;
