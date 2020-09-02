import React, { Component } from 'react';
import './about-me.css';
import Button from 'react-bootstrap/Button';
import axios from 'axios';
import AboutMeService from "../services/aboutme.service";


class AboutMeComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name:'',
            job:'',
            summary:'',
            image: '',
            githubProfileLink: '',
            linkedinProfileLink: '',
            resume:''
        };
      }

      componentDidMount() {
          AboutMeService.getData()
              .then(res => {
                  const data = res;
                  this.setState({ id: data.id });
                  this.setState({ name: data.name });
                  this.setState({ job: data.job });
                  this.setState({ summary: data.summary });
                  this.setState({ image: data.image });
                  this.setState({ githubProfileLink: data.githubProfileLink });
                  this.setState({ linkedinProfileLink: data.linkedinProfileLink });
                  this.setState({ resume: data.resume });
              })
    }
   
    render() {
        return (

            <header className="App-header">
                <div>
                    <img src={`${this.state.image}`}  className="profile-image" alt="logo" />
                <p>{this.state.name}</p>
                <p>{this.state.job}</p>
                <p className="about-me-header">{this.state.summary}</p>
                    <span>
                        <Button variant="secondary" href={`${this.state.resume}`} download="StefanVasic_Resume.pdf" >Download resume</Button>
                        <Button variant="secondary" href={`${this.state.githubProfileLink}`} target="_blank" >Github</Button>
                        <Button variant="secondary" href={`${this.state.linkedinProfileLink}`} target="_blank" >Linkedin</Button>
                </span>

                </div>

            </header>
            
        );
    }
}
export default AboutMeComponent;
