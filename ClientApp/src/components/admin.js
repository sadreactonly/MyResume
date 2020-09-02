import React, { Component } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import AboutMeCrudComponent from './about-me/about-me-crud.js'
import './admin.css'
import ExperienceCrud from './experience/experience-crud.js'
import SkillsCrud from "./skills/skills-crud.js";
import ProjectCrud from "./projects/project-crud.js";
import HobbiesCrud from "./hobbies/hobbies-crud.js";
import Tab from 'react-bootstrap/Tab';
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Nav from 'react-bootstrap/Nav'

class Admin extends Component {

    render() {
        return (
            <div className="App" >
                <Tab.Container  id="left-tabs-example" defaultActiveKey="first">
                    <Row>
                        <Col sm={5}>
                            <Nav variant="tabs" className="tab"  className="flex-column">
                                <Nav.Item>
                                    <Nav.Link eventKey="first">About me</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link eventKey="second">Experience</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link eventKey="third">Skills</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link eventKey="fourth">Projects</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link eventKey="fifth">Hobbies</Nav.Link>
                                </Nav.Item>
                            </Nav>
                        </Col>
                        <Col sm={7}>
                            <Tab.Content>
                                <Tab.Pane eventKey="first">
                                    <AboutMeCrudComponent />
                                </Tab.Pane>
                                <Tab.Pane eventKey="second">
                                    <ExperienceCrud />
                                </Tab.Pane>
                                <Tab.Pane eventKey="third">
                                    <SkillsCrud />
                                </Tab.Pane>
                                <Tab.Pane eventKey="fourth">
                                    <ProjectCrud />
                                </Tab.Pane>
                                <Tab.Pane eventKey="fifth">
                                    <HobbiesCrud />
                                </Tab.Pane>
                            </Tab.Content>
                        </Col>
                    </Row>
                </Tab.Container>
            </div>
        );
    }

   
}

export default Admin; 