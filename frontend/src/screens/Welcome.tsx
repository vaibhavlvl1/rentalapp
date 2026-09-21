import { useState } from "react";
import LoginModal from "../components/ui/LoginModal";
import SignupModal from "../components/ui/SignupModal";

function Welcome() {
  const [isNewUser, setIsNewUser] = useState<boolean>(false);
  const handleIsNewUser = () => {
    setIsNewUser((prev) => !prev);
  };
  return (
    <section className="w-full h-dvh bg-black d-flex justify-center items-center">
      {isNewUser ? (
        <SignupModal handleIsNewUser={handleIsNewUser} />
      ) : (
        <LoginModal handleIsNewUser={handleIsNewUser} />
      )}
    </section>
  );
}

export default Welcome;
