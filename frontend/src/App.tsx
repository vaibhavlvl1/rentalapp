import { Route, Routes } from "react-router";
import "./App.css";
import Layout from "./components/ui/Layout";
import Welcome from "./screens/Welcome";
import ProtectedRoute from "./components/logic/ProtectedRoute";
import HiddenRoute from "./components/logic/HiddenRoute";

function App() {
  return (
    <>
      <Routes>
        <Route path="/">
          <Route
            path=""
            element={
              <ProtectedRoute>
                <Layout />
              </ProtectedRoute>
            }
          />
        </Route>

        <Route
          path="/login"
          element={
            <HiddenRoute>
              <Welcome />
            </HiddenRoute>
          }
        ></Route>
      </Routes>
    </>
  );
}

export default App;
