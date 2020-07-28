import React, { Component } from 'react';
import './about-me.css';
import Button from 'react-bootstrap/Button';
import axios from 'axios';


class AboutMeComponent extends Component {

    constructor(props) {
        super(props);
        this.downloadClick = this.downloadClick.bind(this);
        this.state = {
            name:'',
            job:'',
            summary:'',
            image:''

        };
      }

      componentDidMount() {
          axios.get('/api/aboutme')
            .then(res => {
                const data = res.data;
                this.setState({ name: data.name });
                this.setState({ job: data.job });
                this.setState({ summary: data.summary });
                this.setState({image:data.image});
            })

    }


      downloadClick() {
          axios.get('/api/resume', {responseType: 'arraybuffer'})
        .then(res => {
          const url = window.URL.createObjectURL(new Blob([res.data]
            ,{type: "application/pdf"}))
          var link = document.createElement('a');
          link.href = url;
          link.setAttribute('download', 'resume.pdf');
          document.body.appendChild(link);
          link.click();
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
                        <Button variant="secondary" onClick={this.downloadClick} >Download resume</Button>
                        <Button variant="secondary" href="https://github.com/sadreactonly" target="_blank" >Github</Button>
                        <Button variant="secondary" href="https://www.linkedin.com/in/vasic-stefan/" target="_blank" >Linkedin</Button>
                </span>

                </div>

            </header>
            
        );
    }
}
export default AboutMeComponent;
