import React,{ Component }  from 'react';
import '../../App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Admin from '../admin.js';
import Button from 'react-bootstrap/Button';
import AuthService from "../auth/auth.service";


class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            role: '',
            isLogged: false
        };
    }

    onUsernameChange(event) {
        this.setState({ username: event.target.value });
    }

    onPasswordChange(event) {
        this.setState({ password: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();

        AuthService.login(this.state.username, this.state.password).then(
            () => {
                this.setState({ isLogged: true});               
            });

    }

    IsLoggedIn() {
        let user = AuthService.getCurrentUser();
        if (user) {
            return true;
        }
        else {
            return false;
        }
    }

    render(){
        return (
            <div className="App">
                <div>
                    {!this.state.isLogged &&
                        <form id="contact-form" className="forma" onSubmit={this.handleSubmit.bind(this)} method="POST">
                            <div className="form-group">
                                <label htmlFor="username" className="timeline-header">Username</label>
                                <input type="text" className="form-control" value={this.state.username} onChange={this.onUsernameChange.bind(this)} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="exampleInputEmail1" className="timeline-header" >Password</label>
                                <input type="password" className="form-control" value={this.state.password} onChange={this.onPasswordChange.bind(this)} />
                            </div>
                            <Button type="submit" variant="secondary">
                                Login
                        </Button>
                        </form>
                    }
                </div>
                {this.state.isLogged && <Admin />}
            </div>
        );
    }
}

export default Login;
