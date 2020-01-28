import React, { Component } from "react";

export class Login extends Component {


    constructor() {
        super();

        this.state = {
            UserName: '',
            password: ''
        }
        this.UserName = this.UserName.bind(this);
        this.password = this.password.bind(this);
        this.loginSubmit = this.loginSubmit.bind(this);
    }

 
    UserName(event) {
        this.setState({ UserName: event.target.value })
    }
    password(event) {
        this.setState({ password: event.target.value })
    }


    loginSubmit(event) {
        fetch('https://localhost:44302/auth/login', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                UserName: this.state.UserName,
                password: this.state.password,
            })
        }).then((Response) => Response.json())
            .then((findresponse) => {
                alert(findresponse.result);
            })

        //this.props.history.push("/register");

    }
    render() {
        return (
            <form>
                <h3>Sign In</h3>

                <div className="form-group">
                    <label>Sublime name</label>
                    <input type="text" className="form-control" onChange={this.UserName}  placeholder="Enter username" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" className="form-control" onChange={this.password} placeholder="Enter password" />
                </div>

                <div className="form-group">
                    <div className="custom-control custom-checkbox">
                        <input type="checkbox" className="custom-control-input" id="customCheck1" />
                        <label className="custom-control-label" htmlFor="customCheck1">Remember me</label>
                    </div>
                </div>

                <button type="submit" onClick={this.loginSubmit} className="btn btn-primary btn-block">Submit</button>
                <p className="forgot-password text-right">
                    Forgot <a href="#">password?</a>
                </p>
            </form>
        );
    }
}

export default Login;