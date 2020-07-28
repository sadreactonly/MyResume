import React, { Component } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import AboutMeCrudComponent from './about-me/about-me-crud.js'
import './admin.css'
import ExperienceCrud from './experience/experience-crud.js'
import SkillsCrud from "./skills/skills-crud.js";
import ProjectCrud from "./projects/project-crud.js";
import HobbiesCrud from "./hobbies/hobbies-crud.js";

class Admin extends Component {

    render() {
        return (
            <div className="App" >
                <AboutMeCrudComponent /><br></br>
                <ExperienceCrud /><br></br>
                <SkillsCrud /><br></br>
                <ProjectCrud /><br></br>
                <HobbiesCrud/><br></br>
            </div>
        );
    }

   
}

export default Admin; 