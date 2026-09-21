import Sidebar from "./Sidebar";
import Footer from "./Footer";
import Header from "./Header";
import { Outlet } from "react-router";

function Layout() {
  return (
    <section className="w-full h-dvh bg-black flex flex-col justify-stretch ">
      <Header />
      <main className="flex flex-1">
        <Sidebar />
        <Outlet />
      </main>
      <Footer />
    </section>
  );
}

export default Layout;
