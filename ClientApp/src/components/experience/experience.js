import React, { Component } from 'react';
import './experience.css';
import { VerticalTimeline, VerticalTimelineElement } from 'react-vertical-timeline-component';
import 'react-vertical-timeline-component/style.min.css';
import axios from 'axios';

class ExperienceComponent extends Component {

    constructor(props){
        super(props);
        this.state = {
            experience:[]
        }
    }

    componentDidMount() {
        axios.get('/api/resume/experience')
            .then(res => {
                const data = res.data;
                this.setState({ experience: data });
            })
    }
    render() {
        return (
            <div className="aboutme">
                 <div>
                    <h4 className="timeline-header">
                        Experience and education
                    </h4>
                </div>
                <VerticalTimeline >
                    {this.state.experience.map(item =>
                        
                        <VerticalTimelineElement
                        className="vertical-timeline-element--work"
                            contentStyle={{ background: 'rgb(15, 93, 44)', color: '#fff' }}
                            contentArrowStyle={{ borderRight: '7px solid  rgb(15, 93, 44)' }}
                        date={item.date}
                            iconStyle={{ background: 'rgb(15, 93, 44)', color: '#fff' }}
                  
                    >
                        <h3 className="vertical-timeline-element-title">{item.title}</h3>
                        <h4 className="vertical-timeline-element-subtitle">{item.subtitle}</h4>
                        <ul>
                            Project and technologies:
                              {item.work.map(element =>
                                    <li>
                                       {element}
                                    </li>)}
                        </ul>
                    </VerticalTimelineElement>
               
                        
                        )}
                 
                   
                </VerticalTimeline>
            </div>
        );
    }
}
export default ExperienceComponent;
