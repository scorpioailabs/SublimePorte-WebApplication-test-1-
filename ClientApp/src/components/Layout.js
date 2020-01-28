import React, { Component } from 'react';
import 'reactstrap';
import NavMenu from './NavMenu';
import { LinkBrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css'
import Register from './Register'
import Login from './Login'

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div className="App">
            <nav className="navbar navbar-expand-lg navbar-light fixed-top">
                <div className="container">
                    <Link className="navbar-brand" to={"/auth/login"}>SublimePorte</Link>
                    <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
                        <ul className="navbar-nav ml-auto">
                            <li className="nav-item">
                                <Link className="nav-link" to={"/auth/login"}>Login</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="NavLink" to={"/accounts/register"}>Sign up</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
              <div className="auth-wrapper">
                  <div className="auth-inner">
                      <Switch>
                          <Route exact path='/' component={Login} />
                          <Route path="/auth/login" component={Login} />
                          <Route path="/accounts/register" component={Register} />
                      </Switch>
                  </div>
              </div>
        </div>
    );
  }
}
