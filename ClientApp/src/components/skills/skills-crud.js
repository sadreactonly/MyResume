import React, { Component } from 'react';
import axios from 'axios';
import './skills-crud.css';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Form from 'react-bootstrap/Form';
import SkillsService from "../services/skills.service";


class SkillsCrud extends Component {
    constructor(props) {
        super(props);
        this.state = {
            skills: [],
            id: '',
            title: '',
            subtitle: '',
            technologies: [],
            techName: '',
            techDescripion: '',
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
        SkillsService.delete(id)
            .then(res => {
                this.getData();
                this.resetForm();
            })
            .catch((err) => {
                console.log(err);
            })
    }

    getData() {
        SkillsService.getData()
            .then(res => {
                const data = res;
                this.setState({ skills: data });
            })
    }

    clickAdd() {

        let tmp = this.state.technologies;

        tmp.push(this.state.techName);
        this.setState({ technologies: tmp });
        this.setState({ techName: ""});
    }

    post() {
        let data = {
            id: "",
            title: this.state.title,
            subtitle: this.state.subtitle,
            technologies: this.state.technologies,
        }

        SkillsService.post(data)
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
            title: this.state.title,
            subtitle: this.state.subtitle,
            technologies: this.state.technologies,
        }

        SkillsService.update(data)
            .then((response) => {
                this.getData();
                this.resetForm();
            })
    }
    onNewTechChange(event) {
        this.setState({ techName: event.target.value });
    }
    onDescriptionChange(event) {
        this.setState({ techDescripion: event.target.value });
    }

    onTitleChange(event) {
        this.setState({ title: event.target.value });
    }
    onSubtitleChange(event) {
        this.setState({ subtitle: event.target.value });

    }
    onStartDateChange(event) {
        this.setState({ startDate: event.target.value });

    }
    onEndDateChange(event) {
        this.setState({ endDate: event.target.value });

    }

    onElementChange(event) {
        var tmp = this.state.technologies;
        let i = event.target.getAttribute('a-key');

        tmp[i] = event.target.value;
        this.setState({ technologies: tmp });
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
            this.setState({ id: this.state.skills[i].id });
            this.setState({ title: this.state.skills[i].title });
            this.setState({ subtitle: this.state.skills[i].subtitle });
            this.setState({ startDate: this.state.skills[i].startDate });
            this.setState({ endDate: this.state.skills[i].endDate });
            this.setState({ technologies: this.state.skills[i].technologies });

        }
        else {
            this.resetForm();
        }

    }
    resetForm() {
        this.setState({
            id: "",
            title: "",
            subtitle: "",
            technologies: [],
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
                            <option  value="-1" >Add new..</option>
                            {
                                this.state.skills.map((item, i) =>
                                    <option key={item.id} value={i}>{item.title},{item.subtitle}</option>
                                )
                            }

                        </Form.Control>
                    </Form.Group>
                    <div>
                        <label >Title</label>
                        <input type="text" className="form-control" value={this.state.title} onChange={this.onTitleChange.bind(this)} />
                    </div>
                    <div>
                        <label  >Subtitle</label>
                        <input type="text" className="form-control" value={this.state.subtitle} onChange={this.onSubtitleChange.bind(this)} />
                    </div>
                    <br></br>
                    <div>
                        <input type="text" className="form-control" placeholder="Tecnology name" value={this.state.techName} onChange={this.onNewTechChange.bind(this)} />
                    </div>
                    <div>
                        <input
                            type="button"
                            value="Add."
                            onClick={this.handleClick} />
                    </div>
                    <div className="form-group">
                        <ul>
                            {this.state.technologies.map((element, i) =>
                                <li>
                                    <input type="text" className="form-control" value={element} a-key={i} onChange={this.onElementChange.bind(this)} />
                                    <br></br>
                                </li>)}
                        </ul>
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
export default SkillsCrud;