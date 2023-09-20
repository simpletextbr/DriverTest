import DetailedPage from "./pages/detailed";
import ActionPage from "./pages/actions";
import HomePage from "./pages/home";
import { Route, Routes, BrowserRouter } from "react-router-dom";

export default function (): JSX.Element {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" Component={HomePage} />
        <Route path="/detailed" Component={DetailedPage} />
        <Route path="/actions" Component={ActionPage} />
      </Routes>
    </BrowserRouter>
  );
}
