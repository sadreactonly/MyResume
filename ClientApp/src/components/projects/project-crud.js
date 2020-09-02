import React, { Component } from 'react';
import './project-crud.css';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Form from 'react-bootstrap/Form';
import ProjectsService from "../services/projects.service";

class ProjectCrud extends Component {
    constructor(props) {
        super(props);
        this.state = {
            projects: [],
            id: '',
            name: '',
            description: '',
            technologies: '',
            githubLink: '',

            selectValue: '',
            groupSelectValue: '',
            addEnabled: '',
            editEnabled: '',
            deleteEnabled: ''
        }

        this.handleSave = () => this.post();
        this.handleUpdate = () => this.update();
        this.handleClick = () => this.clickAdd();
        this.handleDelete = () => this.delete();

    }

    componentDidMount() {

        this.getData();
        this.setState({
            addEnabled: true,
            editEnabled: false,
            deleteEnabled: false
        });

    }

    delete() {
        let id = this.state.id;
        ProjectsService.delete(id)
            .then(res => {
                this.getData();
                this.resetForm();
            })
            .catch((err) => {
                console.log(err);
            })
    }

    getData() {
        ProjectsService.getData()
            .then(res => {
                const data = res;
                this.setState({ projects: data });
            })
    }

 
    post() {
        let data = {
            id: "",
            name: this.state.name,
            description: this.state.description,
            githubLink: this.state.githubLink,
            technologies: this.state.technologies,
        }

        ProjectsService.post(data)
            .then((response) => {
            if (response.status === 200) {
                this.getData();
                this.resetForm();
            } else {
                alert("Message failed to send.")
            }
        })
    }
    update() {
        let data = {
            id: this.state.id,
            name: this.state.name,
            description: this.state.description,
            technologies: this.state.technologies,
            githubLink: this.state.githubLink
        }

        ProjectsService.update(data)
            .then((response) => {
                this.getData();
                this.resetForm();
            })
    }

    onDescriptionChange(event) {
        this.setState({ description: event.target.value });
    }
    onTechnologiesChange(event) {
        this.setState({ technologies: event.target.value });
    }

    onNameChange(event) {
        this.setState({ name: event.target.value });
    }
    onGithubLinkChange(event) {
        this.setState({ githubLink: event.target.value });

    }
    yourChangeHandler(event) {
        let i = event.target.value;
        this.setState({
            groupSelectValue: i,
            addEnabled: false,
            editEnabled: true,
            deleteEnabled: true
        });

        if (i !== "-1") {
            this.setState({ id: this.state.projects[i].id });
            this.setState({ name: this.state.projects[i].name });
            this.setState({ description: this.state.projects[i].description });
            this.setState({ githubLink: this.state.projects[i].githubLink });
            this.setState({ technologies: this.state.projects[i].technologies });
        }
        else {
            this.resetForm();
        }

    }
    resetForm() {
        this.setState({
            id: "",
            name: "",
            description: "",
            githubLink: "",
            technologies:"",
            groupSelectValue: -1,
            addEnabled: true,
            editEnabled: false,
            deleteEnabled: false
        });
    }

    render() {
        return (
            <div className="MainDiv">

                <Form className="forma">
                    <Form.Group controlId="exampleForm.SelectCustom">
                        <Form.Label>Custom select</Form.Label>
                        <Form.Control as="select" value={this.state.groupSelectValue} onChange={this.yourChangeHandler.bind(this)} custom>
                            <option key="-1" value="-1" >Add new..</option>
                            {
                                this.state.projects.map((item, i) =>
                                    <option key={item.id}  value={i}>{item.name}</option>
                                )
                            }

                        </Form.Control>
                    </Form.Group>
                    <div>
                        <label >Name</label>
                        <input type="text" className="form-control" value={this.state.name} onChange={this.onNameChange.bind(this)} />
                    </div>
                    <div>
                        <label  >Technologies</label>
                        <input type="text" className="form-control" value={this.state.technologies} onChange={this.onTechnologiesChange.bind(this)} />
                    </div>
                    <div>
                        <label >Description</label>
                        <textarea className="form-control" rows="5" value={this.state.description} onChange={this.onDescriptionChange.bind(this)} />

                    </div>
                    <div>
                        <label  >Github link</label>
                        <input type="text" className="form-control" value={this.state.githubLink} onChange={this.onGithubLinkChange.bind(this)} />
                    </div>
                </Form>
                <ButtonGroup aria-label="Basic example">
                    <Button variant="secondary" disabled={!this.state.addEnabled} onClick={this.handleSave}>Add</Button>
                    <Button variant="secondary" disabled={!this.state.editEnabled} onClick={this.handleUpdate}>Edit</Button>
                    <Button variant="secondary" disabled={!this.state.deleteEnabled} onClick={this.handleDelete}>Delete</Button>
                </ButtonGroup>
            </div>
        );
    }
}
export default ProjectCrud;