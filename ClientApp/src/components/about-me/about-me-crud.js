import React, { Component } from 'react';
import './about-me-crud.css';
import Button from 'react-bootstrap/Button';
import AboutMeService from "../services/aboutme.service";

class AboutMeCrudComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            id:'',
            name:'',
            job:'',
            summary:'',
            image:''
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
                this.setState({image:data.image});
            })
    }

    onNameChange(event) {
        this.setState({ name: event.target.value });
    }

    onJobChange(event) {
        this.setState({ job: event.target.value });
    }

    onSummaryChange(event) {
        this.setState({ summary: event.target.value });
    }
  

    resetForm() {
        this.setState({ name: "", job: "", summary: "", image:"" });
    }

    handleSubmit(event)
    {
        event.preventDefault();
        if (this.state.id != null)
        {
            this.update();
        }
        else
        {
            this.post();
        }

    }

    post() {
        AboutMeService.post(this.state).then((response) => {
            if (response.status === 200) {

            } else {
                alert("Message failed to send.")
            }
        })
    }

    update() {
        AboutMeService.update(this.state)
            .then((response) => { 
                
            })
    }

    onImageChange(event) {
        var file = event.target.files[0];
        var reader = new FileReader();

        reader.onload = () => this.setState({ image: reader.result })
        reader.readAsDataURL(file);
    }
   
    render() {
        return (
            <div>
                <h2>About me</h2>
               
            <form id="contact-form" className="forma" onSubmit={this.handleSubmit.bind(this)} method="POST">
                    <div className="form-group">
                        <label htmlFor="name" className="timeline-header">Name</label>
                        <input type="text" className="form-control" value={this.state.name} onChange={this.onNameChange.bind(this)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="exampleInputEmail1" className="timeline-header" >Job</label>
                        <input type="text" className="form-control" value={this.state.job} onChange={this.onJobChange.bind(this)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="subject" className="timeline-header">Summary</label>
                        <textarea className="form-control" rows="5" value={this.state.summary} onChange={this.onSummaryChange.bind(this)} />
                    </div>
                    <div className="newTechDiv">
                        <label  >Image</label>
                        <input type="file" accept="image/png,image/jpeg" className="form-control" onChange={this.onImageChange.bind(this)} />
                        <img src={`${this.state.image}`} className="pn-image" alt="logo" />

                    </div>
                    <br></br>
                    <Button type="submit" variant="secondary">
                           Save
                    </Button>
                
                </form>

                </div>
        );
    }
}
export default AboutMeCrudComponent;
