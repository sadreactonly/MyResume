import axios from "axios";

const API_URL = "http://localhost:44337/api/account/";

class AuthService {
    login(username, password) {
        return axios({
            method: "POST",
            url: "/api/account/login",
            data: { username, password }
        }).then((response) => {
            if (response.status === 200) {
                if (response.data.accessToken) {
                    localStorage.setItem("user", JSON.stringify(response.data));
                }
            } else {
                alert("Message failed to send.")
            }
            return response.data;
        })
    }


    logout() {
        localStorage.removeItem("user");
    }

    getCurrentUser() {
        return JSON.parse(localStorage.getItem('user'));;
    }
}

export default new AuthService();