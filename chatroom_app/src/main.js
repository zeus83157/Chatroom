import { createApp } from 'vue'
import App from './App.vue'
import { globalCookiesConfig } from "vue3-cookies";

globalCookiesConfig({
  expireTimes: "5m",
  path: "/",
  domain: "",
  secure: true,
  sameSite: "None",
});

createApp(App).mount('#app')
