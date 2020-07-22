import React from 'react';
import './App.css';
import AboutMeComponent from './components/about-me/about-me.js';
import SkillsComponent from './components/skills/SkillsComponent';
import ExperienceComponent from './components/experience/experience.js';
import HobbiesComponent from './components/hobbies/hobbies.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import Contact from './components/contacts/contact';

function App() {
    return (
        <div className="App">
            <AboutMeComponent /><br></br>
            <ExperienceComponent /><br></br>
            <SkillsComponent /><br></br>
            <HobbiesComponent /><br></br>
            <Contact /><br></br>
        </div>
    );
}

export default App;
