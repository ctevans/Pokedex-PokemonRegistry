import React from "react";
import { Router, Route, Switch } from "react-router-dom";
import history from "../history";
import LandingPage from "./LandingPage";

const App = () => {
  return (
    <div className="ui container">
      <Router history={history}>
        <div>
          <Switch>
            <Route path="/" exact component={LandingPage} />
          </Switch>
        </div>
      </Router>
    </div>
  );
};

export default App;
