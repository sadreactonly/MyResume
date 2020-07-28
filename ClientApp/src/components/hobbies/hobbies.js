import './hobbies.css';
import React, { Component } from 'react';
import axios from 'axios';

class HobbiesComponent extends Component {

    constructor(props) {
        super(props);

        this.state = {
            hobbies: []
        }

    }

    componentDidMount() {
        axios.get('/api/hobbies')
            .then(res => {
                const data = res.data;
                this.setState({ hobbies: data });
            });
    }


    render() {
        return (
              
                <div className="background">
                <h4 className="timeline-header">
                    Hobbies
                </h4>
                    {this.state.hobbies.map(item =>
                        <div className="maincontainer" key={item.id}>
                            <div className="thecard">
                                <div className="thefront">
                                    <img src={`${item.image}`}  className="hobby-image" alt="sports" />
                                    <h2 className="hobby-name">{item.name}</h2>
                                </div>
                                <div className="theback">
                                    <p className="explanation">{item.explanation}</p>
                                </div>
                            </div>
                        </div>
                            )};
                    </div>
        );
    }
}
export default HobbiesComponent;