﻿import React, { Component } from 'react';
import './hobbies-crud.css';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Form from 'react-bootstrap/Form';
import HobbiesService from "../services/hobbies.service";


class HobbiesCrud extends Component {
    constructor(props) {
        super(props);
        this.state = {
            hobbies: [],
            id: '',
            name: '',
            explanation: '',
            image: '',

            selectValue: '',
            groupSelectValue: '',
            addEnabled: '',
            editEnabled: '',
            deleteEnabled: '',
            object:null
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
 
        HobbiesService.delete(id).then(res => {
            this.getData();
            this.resetForm();
        })

    }

    getData() {
        HobbiesService.getData().then(res => {
            const data = res;
            this.setState({ hobbies: data });
        })
    }

    post() {   
        let data = {
            id: "",
            image: String(this.state.image),
            name: this.state.name,
            explanation: this.state.explanation    
        }

        HobbiesService.post(data).then((response) => {
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
            image: String(this.state.image),
            name: this.state.name,
            explanation: this.state.explanation
        }
        console.log(data);
        HobbiesService.update(data)
            .then((response) => {
                this.getData();
                this.resetForm();
        })
    }

    onDescriptionChange(event) {
        this.setState({ explanation: event.target.value });
    }
    onImageChange(event){
        var file = event.target.files[0];
        var reader = new FileReader();

        reader.onload = () => this.setState({ image: reader.result })
        reader.readAsDataURL(file);
    }
   
    onNameChange(event) {
        this.setState({ name: event.target.value });
    }
   
    yourChangeHandler(event) {
        let i = event.target.value;
        this.setState({
            groupSelectValue: i,
            addEnabled: false,
            editEnabled: true,
            deleteEnabled: true
        });
        this.setState({ object: this.state.hobbies[i] });

        if (i !== "-1") {
            this.setState({ id: this.state.hobbies[i].id });
            this.setState({ name: this.state.hobbies[i].name });
            this.setState({ explanation: this.state.hobbies[i].explanation });
            this.setState({ image: this.state.hobbies[i].image });
        }
        else {
            this.resetForm();
        }

    }
    resetForm() {
        this.setState({
            id: "",
            name: "",
            explanation: "",
            image: "",
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
                                this.state.hobbies.map((item, i) =>
                                    <option key={item.id} value={i}>{item.name}</option>
                                )
                            }

                        </Form.Control>
                    </Form.Group>
                    <div>
                        <label >Name</label>
                        <input type="text" className="form-control" value={this.state.name} onChange={this.onNameChange.bind(this)} />
                    </div>
                    <div>
                        <label >Description</label>
                        <textarea className="form-control" rows="5" value={this.state.explanation} onChange={this.onDescriptionChange.bind(this)} />

                    </div>
                  
                    <div>
                        <label  >Image</label>
                        <input type="file" accept="image/png,image/jpeg" className="form-control" onChange={this.onImageChange.bind(this)} />
                    </div>
                    <div>
                        <img src={`${this.state.image}`} className="hobby-image" alt="sports" />
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
export default HobbiesCrud;