import React from "react";
import GlobalStyles from "./Packages/web/styles/globalStyles";
import Router from "./Packages/web/routes";

function App(): JSX.Element {
  return (
    <React.Fragment>
      <GlobalStyles />
      <Router />
    </React.Fragment>
  );
}

export default App;
