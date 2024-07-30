import axios from 'axios';
import util from './util';

const api = axios.create({
  baseURL: 'http://localhost:5027/api',
});

export default api;