import React, { Component } from "react";
import './contact.css';
import axios from 'axios';
import Spinner from 'react-bootstrap/Spinner';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';


class Contact extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            email: '',
            subject:'',
            message: '',
            spinnerLoading: false
        }
    }

    render() {
        return (
            <div className="contact-form">
                <h4 className="timeline-header">
                    Contacts
                </h4>
                <form id="contact-form" className="forma" onSubmit={this.handleSubmit.bind(this)} method="POST">
                    <div className="form-group">
                        <label htmlFor="name" className="timeline-header">Name</label>
                        <input type="text" className="form-control" value={this.state.name} onChange={this.onNameChange.bind(this)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="exampleInputEmail1" className="timeline-header" >Email address</label>
                        <input type="email" className="form-control" aria-describedby="emailHelp" value={this.state.email} onChange={this.onEmailChange.bind(this)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="subject" className="timeline-header">Subject</label>
                        <input type="text" className="form-control" value={this.state.subject} onChange={this.onSubjectChange.bind(this)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="message" className="timeline-header">Message</label>
                        <textarea className="form-control" rows="5" value={this.state.message} onChange={this.onMessageChange.bind(this)} />
                    </div>
                    <Button type="submit" variant="secondary">
                        {this.state.spinnerLoading ? 'Sending…' : 'Send'}
                    {this.state.spinnerLoading && <Spinner animation="border" size="sm" />}
                    </Button>
                
                </form>
            </div>
        );
    }

    onNameChange(event) {
        this.setState({ name: event.target.value });
    }

    onEmailChange(event) {
        this.setState({ email: event.target.value });
    }

    onSubjectChange(event) {
        this.setState({ subject: event.target.value });
    }
    onMessageChange(event) {
        this.setState({ message: event.target.value });
    }

    resetForm() {
        this.setState({ name: "", email: "", message: "", subject:"" });
    }

    handleSubmit(event)
    {
        event.preventDefault();
        this.setState({ spinnerLoading: true });
        axios({
            method: "POST",
            url: "/api/resume/send-mail",
            data: this.state
        }).then((response) => {
            console.log(response);

            if (response.status === 200) {
                alert("Message Sent.");
                this.resetForm()
            } else {
                alert("Message failed to send.")
            }
            this.setState({ spinnerLoading: false });
        })
    }
}

export default Contact;