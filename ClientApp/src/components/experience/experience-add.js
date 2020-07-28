import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import axios from 'axios';
class ExperienceAdd extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            show: false,
            object: {
                id: '',
                title: '',
                subtitle: '',
                work: [],
            },
            actionName: '',


        }
        this.handleClose = () => this.close();
        this.handleShow = () => this.setState({ show: true });
        this.handleSave = () => this.addOrUpdate();
    }

   componentDidMount() {

        if (this.props.dataFromParent) {
            this.setState({ actionName: "Edit" });
            axios.get(`/api/experience/${this.props.dataFromParent}`)
                .then(res => {
                    const data = res.data;
                    this.setState({ object: data });
                })
        }
        else {
            this.setState({ actionName: "Add" });

        }

    }

    addOrUpdate() {
        if (this.props.dataFromParent) {
            this.update();
        }
        else {
            this.post();
        }
    }

    post() {
        axios.post(`/api/experience/`, this.state.object)
            .then((response) => {
                console.log(response);

                if (response.status === 200) {
                    alert("Message Sent.");
                    this.setState({ show: false });

                } else {
                    alert("Message failed to send.")
                }
            })
    }
    update() {

        axios.put(`/api/experience/${this.state.object.id}`, this.state.object)
            .then((response) => {
                console.log(response);

                if (response.status === 200) {
                    alert("Message Sent.");
                    this.setState({ show: false });

                } else {
                    alert("Message failed to send.")
                }
            })
    }

    close() {
        if (this.props.dataFromParent) {

            axios.get(`/api/experience/${this.props.dataFromParent}`)
                .then(res => {
                    const data = res.data;
                    this.setState({ object: data });
                })
        }
        this.setState({ show: false });

    }
    onTitleChange(event) {
        let v = this.state.object;
        v.title = event.target.value;
        this.setState({ object: v });
    }
    onSubtitleChange(event) {
        let v = this.state.object;
        v.subtitle = event.target.value;
        this.setState({ object: v });
    }
    onElementChange(event) {
        let v = this.state.object;
        let i = event.target.getAttribute('a-key');
        v.work[i] = event.target.value;
        this.setState({ object: v });
    }
    render() {
        return (
            <>
                <Button variant="primary" onClick={this.handleShow}>
                    {this.state.actionName}
                </Button>

                <Modal show={this.state.show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>{this.state.title}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <form >
                            <div className="form-group">
                                <label >Title</label>
                                <input type="text" className="form-control" value={this.state.object.title} onChange={this.onTitleChange.bind(this)} />
                            </div>
                            <div className="form-group">
                                <label  >Subtitle</label>
                                <input type="text" className="form-control" value={this.state.object.subtitle} onChange={this.onSubtitleChange.bind(this)} />
                            </div>
                            <div className="form-group">
                                <ul>
                                    Project and technologies:
                              {this.state.object.work.map((element, i) =>
                                    <li>
                                        <input type="text" className="form-control" value={element} a-key={i} onChange={this.onElementChange.bind(this)} />
                                    </li>)}
                                </ul>
                            </div>
                        </form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={this.handleClose}>
                            Close
          </Button>
                        <Button variant="primary" onClick={this.handleSave}>
                            Save Changes
          </Button>
                    </Modal.Footer>
                </Modal>
            </>
        );
    }
}

export default ExperienceAdd;