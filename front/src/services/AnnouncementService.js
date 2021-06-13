import axios from 'axios';

axios.defaults.withCredentials = true;

class AnnouncementService {

    getAll() {
        return axios.get("/Announcements");
    }

    get(id) {
        return axios.get(`/Announcements/${id}`);
    }

    create(data) {
        return axios.post("https://localhost:44350/api/Announcements", data);
    }

    update(id, data) {
        return axios.put(`/Announcements/${id}`, data);
    }

    remove(id) {
        return axios.delete(`/Announcements/${id}`);
    }

    findByTitle(title) {
        return axios.get(`/items?title=${title}`);
    }
}

const service = new AnnouncementService();
export default service;