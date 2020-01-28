import React, { Component } from 'react';
import { LoginActions } from "./api-authorization/ApiAuthorizationConstants";
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';

export class Register extends Component {

    constructor() {
        super();

        this.state = {
            firstName: '',
            lastName: '',
            Email: '',
            UserName: '',
            password: '',
            confirmPassword: '',
            address: ''
        }

        this.firstName = this.firstName.bind(this);
        this.lastName = this.lastName.bind(this);
        this.Email = this.Email.bind(this);
        this.UserName = this.UserName.bind(this);
        this.password = this.password.bind(this);
        this.confirmPassword = this.confirmPassword.bind(this);
        this.address = this.address.bind(this);
        this.registerSubmit = this.registerSubmit.bind(this);
    }

    firstName(event) {
        this.setState({ firstName: event.target.value })
    }

    lastName(event) {
        this.setState({ lastName: event.target.value })
    }
    Email(event) {
        this.setState({ Email: event.target.value })
    }

    UserName(event) {
        this.setState({ UserName: event.target.value })
    }
    password(event) {
        this.setState({ password: event.target.value })
    }
    confirmPassword(event) {
        this.setState({ confirmPassword: event.target.value })
    }
    address(event) {
        this.setState({ address: event.target.value })
    }


    registerSubmit(event) {
        fetch('https://localhost:44302/accounts/register', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                firstName: this.state.firstName,
                lastName: this.state.lastName,
                Email: this.state.Email,
                UserName: this.state.UserName,
                password: this.state.password,
                address: this.state.address
            })
        }).then((Response) => Response.json())
            .then((findresponse) => {
                alert(findresponse.result);
            })

        //this.props.history.push("/register");

    }


    render() {
        return (
            <div>
                <div className="row">
                </div>

                <h3>Sign Up</h3>
                <div className="form-group">
                    <label>First name</label>
                    <input type="text" className="form-control" onChange={this.firstName} placeholder="First name" />
                </div>

                <div className="form-group">
                    <label>Last name</label>
                    <input type="text" className="form-control" onChange={this.lastName} placeholder="Last name" />
                </div>

                <div className="form-group">
                    <label>Email address</label>
                    <input type="email" className="form-control" onChange={this.Email} placeholder="Enter email" />
                </div>

                <div className="form-group">
                    <label>Sublime Name </label>
                    <input type="text" className="form-control" onChange={this.UserName} placeholder="Enter your sublime name!" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" className="form-control" onChange={this.password} placeholder="Enter password" />
                </div>

                <div className="form-group">
                    <label>address</label>
                    <input type="text" className="form-control" onChange={this.address} placeholder="Enter your address" />
                </div>

                <button type="submit" onClick={this.registerSubmit} className="btn btn-primary btn-block">Submit</button>
                <p className="forgot-password text-right">
                    Already registered <a href="#">sign in?</a>
                </p>
            </div>
        );
    }
}

export default Register;