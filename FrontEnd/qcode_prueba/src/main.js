import { createApp } from 'vue'
import router from './router';
import App from './App.vue';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.js'

window.localStorage.setItem('token', '');
const app= createApp(App);
app.use(router);
app.mount('#app');

