import axios from "axios";

const currentAxios = axios.create({
    baseURL: 'http://localhost:5162/api/'
});

export default currentAxios;