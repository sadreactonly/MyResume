import { VerticalTimeline, VerticalTimelineElement } from 'react-vertical-timeline-component';
import 'react-vertical-timeline-component/style.min.css';
import React, { Component } from 'react';
import './SkillsComponent.css';
import axios from 'axios';

class SkillsComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            skills: []
        };
    }

    componentDidMount() {
        axios.get('/api/resume/skills')
            .then(res => {
                const data = res.data;
                this.setState({ skills: data });
            });
    }

    render() {
        return (
            <div className="Timeline">
                    <h4 className="timeline-header">
                        Skills
                    </h4>
                <VerticalTimeline >
                    {this.state.skills.map(item =>
                        <VerticalTimelineElement
                            className="vertical-timeline-element--work"
                            contentStyle={{ background: 'rgb(15, 93, 44)', color: '#fff' }}
                            contentArrowStyle={{ borderRight: '7px solid  rgb(15, 93, 44)' }}
                            date=""
                            iconStyle={{ background: 'rgb(15, 93, 44)', color: '#fff' }}
                          
                        >
                            <h3 className="vertical-timeline-element-title">{item.title}</h3>
                            <h2 className="vertical-timeline-element-subtitle">{item.subtitle}</h2>
                            <ul>
                                {item.technologies.map(res =>
                                    <li>
                                        <p className="skillName">
                                            {res.name}
                                        </p>
                                        {res.description}
                                    </li>

                                )}
                            </ul>
                        </VerticalTimelineElement>
                    )}
                </VerticalTimeline>
            </div>
        );
    }
}
export default SkillsComponent;
