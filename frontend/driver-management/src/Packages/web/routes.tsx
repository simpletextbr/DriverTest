import { Route, Routes, BrowserRouter } from "react-router-dom";

import RegisterPage from "./pages/register";
import HomePage from "./pages/home";
import UpdatePage from "./pages/update/intex";

export default function Router(): React.JSX.Element {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" Component={HomePage} />
        <Route path="/register" Component={RegisterPage} />
        <Route path="/update/:id" Component={UpdatePage} />
      </Routes>
    </BrowserRouter>
  );
}
