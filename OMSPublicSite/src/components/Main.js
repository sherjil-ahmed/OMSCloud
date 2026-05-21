import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect,
} from 'react-router-dom';
import { getStorageItem } from '../utils/storageHelper';
import { IS_USER_LOGGEDIN, PROFILE_ID, USER_PROFILE } from '../utils/constants';
import { routes } from '../utils/routes';

class Main extends React.Component {
  constructor(props) {
    super(props);
    // this.state = {
    //     doesSessionExists : false
    // }
  }

  componentDidMount() {}

  componentDidUpdate() {}

  render() {
    let sessionProfile = getStorageItem(IS_USER_LOGGEDIN);
    let userProfile = getStorageItem(USER_PROFILE);
    return sessionProfile ? (
      <Router>
        <Switch>
          {userProfile.routeList && userProfile.routeList.length > 0
            ? routes
                .filter((a) => userProfile.routeList.includes(a.path))
                .map((mappedRoute, i) => (
                  <Route
                    exact
                    path={mappedRoute.path}
                    component={() => mappedRoute.component}
                    key={i}
                  />
                ))
            : routes
                .filter((a) => a.isAnon)
                .map((mappedRoute, i) => (
                  <Route
                    exact
                    path={mappedRoute.path}
                    component={() => mappedRoute.component}
                    key={i}
                  />
                ))}
          <Route component={() => <Redirect to="/" />} />
        </Switch>
      </Router>
    ) : (
      <Router>
        <Switch>
          {routes
            .filter((a) => a.isAnon)
            .map((mappedRoute, i) => (
              <Route
                exact
                path={mappedRoute.path}
                component={() => mappedRoute.component}
                key={i}
              />
            ))}
          <Route component={() => <Redirect to="/" />} />
        </Switch>
      </Router>
    );
  }
}

export default Main;
