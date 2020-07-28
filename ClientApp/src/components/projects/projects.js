import React, { Component } from 'react';
import './projects.css';
import { VerticalTimeline, VerticalTimelineElement } from 'react-vertical-timeline-component';
import 'react-vertical-timeline-component/style.min.css';
import axios from 'axios';
import Button from 'react-bootstrap/Button';


class ProjectsComponent extends Component {

    constructor(props){
        super(props);
        this.state = {
            Projects:[]
        }
    }

    componentDidMount() {
        axios.get('/api/projects')
            .then(res => {
                const data = res.data;
                this.setState({ Projects: data });
            })
    }
    render() {
        return (
            <div className="aboutme">
                 <div>
                    <h4 className="timeline-header">
                        Projects and education
                    </h4>
                </div>
                <VerticalTimeline >
                    {this.state.Projects.map(item =>
                        
                        <VerticalTimelineElement key={item.id}
                        className="vertical-timeline-element--work"
                            contentStyle={{ background: 'rgb(15, 93, 44)', color: '#fff' }}
                            contentArrowStyle={{ borderRight: '7px solid  rgb(15, 93, 44)' }}
                        date={item.date}
                            iconStyle={{ background: 'rgb(15, 93, 44)', color: '#fff' }}
                  
                    >
                        <h3 className="vertical-timeline-element-title">{item.name}</h3>
                        <h4 className="vertical-timeline-element-subtitle">{item.technologies}</h4>
                            <p >
                                {item.description}
                            </p>
                            <Button variant="secondary" href={item.githubLink} target="_blank" >View code</Button>

                    </VerticalTimelineElement>
               
                        
                        )}
                 
                   
                </VerticalTimeline>
            </div>
        );
    }
}
export default ProjectsComponent;
