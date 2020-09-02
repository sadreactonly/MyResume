import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import MainPage  from './components/mainpage.js';
import AdminPage from './components/admin.js'
import Login from './components/login/login.js'
import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";

function App() {
    return (
        <Router>
            <div>
            
                <Switch>
                    <Route exact path="/">
                        <MainPage />
                    </Route>
                    <Route path="/adminpage">
                        <Login />
                    </Route>
                </Switch>
            </div>
        </Router>
    );
}

export default App;
