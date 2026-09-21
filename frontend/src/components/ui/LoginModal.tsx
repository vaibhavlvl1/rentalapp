import { useForm } from "react-hook-form";
import login_image from "../../assets/login_image.jpg";
import {
  loginSchema,
  type LoginFormData,
} from "../../zodSchemas/loginRegister";
import { zodResolver } from "@hookform/resolvers/zod";
import { useLogin } from "../../tanstack/useLogin";
import CircularProgress from "@mui/material/CircularProgress";
import { useContext } from "react";
import AppContext from "../../context/appContext";

interface LoginModalProps {
  //setIsNewUser: Dispatch<SetStateAction<boolean>>;
  handleIsNewUser: () => void;
}

function LoginModal({ handleIsNewUser }: LoginModalProps) {
  // tanstack usequery
  const { login, isLoading, isError } = useLogin();

  //hook form variables
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({ resolver: zodResolver(loginSchema) });

  // form submit function

  const onSubmit = async (data: LoginFormData) => {
    console.log("login form data", data);
    login(data);
  };

  // handle is new user to swithc to register modal

  const { userDetails } = useContext(AppContext);

  return (
    <div className="flex h-full justify-center items-center">
      <div className="flex bg-gray-900 h-1/2 w-full">
        {/* lhs */}
        <div className="flex flex-col h-full flex-1 justify-center items-center">
          <form
            onSubmit={handleSubmit(onSubmit)}
            className="w-96 bg-gray-800 flex flex-col  p-5"
          >
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
            <button
              className="bg-gray-600 hover:bg-gray-500 w-auto px-2 py-1 text-xs rounded-xs cursor-pointer disabled:pointer-events-none"
              type="submit"
              disabled={isLoading}
            >
              {isLoading ? <CircularProgress size={20} /> : "Login"}
            </button>
            <p className="mt-5 text-xs">
              Dont Have an Account ? Register{" "}
              <span
                className="underline cursor-pointer"
                onClick={handleIsNewUser}
              >
                Here
              </span>
              {""}
            </p>
          </form>
          {isError && <p className="form-error">Invalid Credentials</p>}
        </div>
        {/* rhs */}
        <div className="h-full flex-1">
          <img
            className=" h-full w-full object-cover opacity-50"
            src={login_image}
            alt="login image"
          />
        </div>
        <div>
          <button onClick={() => console.log(userDetails)}>
            Check USerDetails
          </button>
        </div>
      </div>
    </div>
  );
}

export default LoginModal;
