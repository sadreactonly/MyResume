import axios from "axios";
import authHeader from '../auth/auth-header';

const API_URL = "http://localhost:44337/api/aboutme/";

class AboutMeService {

    delete(id) {
        return axios.delete("/api/aboutme/" + id, {
            headers: authHeader()
        }).then(res => {
            return res;
        }).catch((err) => {
            console.log(err);
        });
    }

    getData() {
        return axios.get('/api/aboutme')
            .then(res => {
                const data = res.data;
                return data;
            })
    }

    post(data) {
        let headers = authHeader();

        return axios({
            method: "POST",
            url: "/api/aboutme/",
            data: data,
            headers: headers
        }).then((response) => {
            if (response.status === 200) {
                return response;
            } else {
                alert("Message failed to send.")
            }
        })
    }

    update(object) {
        return axios.put(`/api/aboutme/${object.id}`, object, { headers: authHeader() })
            .then((response) => {

                if (response.status === 200) {
                    alert("Message Sent.");

                } else {
                    alert("Message failed to send.")
                }
            })
    }
}

export default new AboutMeService();