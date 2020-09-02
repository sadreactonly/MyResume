import React, { Component } from 'react';
import axios from 'axios';
import './experience-crud.css';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Form from 'react-bootstrap/Form';
import ExperienceService from "../services/experience.service";

class ExperienceCrud extends Component {
    constructor(props) {
        super(props);
        this.state = {
            experience: [],
            id: '',
            title: '',
            subtitle: '',
            startDate: '',
            endDate:'',
            work: [],
            newTech: '', 
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

        ExperienceService.delete(id)
            .then(res => {
                this.getData();
                this.resetForm();
            })
            .catch((err) => {
                console.log(err);
            })
    }

    getData() {
        ExperienceService.getData()
            .then(res => {
                const data = res;
                this.setState({ experience: data });
            })
    }
    clickAdd() {

        let tmp = this.state.work;
        tmp.push(this.state.newTech);
        this.setState({ work: tmp });
        this.setState({ newTech: "" });
    }
    post() {
        let data = {
            id: "",
            title: this.state.title,
            subtitle: this.state.subtitle,
            startDate: parseInt(this.state.startDate),
            endDate: parseInt(this.state.endDate),
            work: this.state.work,
        }

        ExperienceService.post(data)
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
            startDate: parseInt(this.state.startDate),
            endDate: parseInt(this.state.endDate),
            work:this.state.work,
        }

        ExperienceService.update(data)
            .then((response) => {
                this.getData();
                this.resetForm();
            })
    }

    onNewTechChange(event) {
        this.setState({ newTech: event.target.value });
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
        var tmp = this.state.work;
        let i = event.target.getAttribute('a-key');
       
        tmp[i] = event.target.value;
        this.setState({ work: tmp });
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
            this.setState({ id: this.state.experience[i].id });
            this.setState({ title: this.state.experience[i].title });
            this.setState({ subtitle: this.state.experience[i].subtitle });
            this.setState({ startDate: this.state.experience[i].startDate });
            this.setState({ endDate: this.state.experience[i].endDate });
            this.setState({ work: this.state.experience[i].work });
            
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
            startDate: '',
            endDate: '',
            work: [],
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
                            <option value="-1" >Add new..</option>
                            {
                                this.state.experience.map((item, i) =>
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
                        <label  >Start date</label>
                        <input type="number" className="form-control" value={this.state.startDate} onChange={this.onStartDateChange.bind(this)} />
                    </div>
                    <div>
                        <label>End date</label>
                        <input type="number" className="form-control" value={this.state.endDate} onChange={this.onEndDateChange.bind(this)} />
                    </div>
                    <br></br>
                    <div>
                        <input type="text" className="form-control" value={this.state.newTech} onChange={this.onNewTechChange.bind(this)}/>
                        </div>
                    <div>
                        <input
                            type="button"
                            value="Add."
                            onClick={this.handleClick}/>
                    </div>
                    <div className="form-group">
                        <ul>
                              {this.state.work.map((element, i) =>
                            <li>
                                <input type="text" className="form-control" value={element} a-key={i} onChange={this.onElementChange.bind(this)} />
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
export default ExperienceCrud;