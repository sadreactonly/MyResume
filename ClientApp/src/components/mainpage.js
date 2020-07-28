import React,{ Component }  from 'react';
import '../App.css';
import AboutMeComponent from './about-me/about-me.js';
import SkillsComponent from './skills/SkillsComponent';
import ExperienceComponent from './experience/experience.js';
import HobbiesComponent from './hobbies/hobbies.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import Contact from './contacts/contact';
import ProjectsComponent from './projects/projects';

class MainPage extends Component {
        
    render(){

        return (
            <div className="App">
                <AboutMeComponent /><br></br>
                <ExperienceComponent /><br></br>
                <SkillsComponent /><br></br>
                <ProjectsComponent /><br></br>
                <HobbiesComponent /><br></br>
                <Contact /><br></br>
            </div>
        );
    }
  
    
}

export default MainPage;
