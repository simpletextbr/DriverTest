import React from "react";
import GlobalStyles from "./Packages/web/styles/globalStyles";
import Router from "./Packages/web/routes";
import { ToastContainer } from "react-toastify";

import "react-toastify/dist/ReactToastify.css";
import "bootstrap/dist/css/bootstrap.min.css";

function App(): React.JSX.Element {
  return (
    <React.Fragment>
      <GlobalStyles />
      <Router />
      <ToastContainer
        position="bottom-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="colored"
      />
    </React.Fragment>
  );
}

export default App;
