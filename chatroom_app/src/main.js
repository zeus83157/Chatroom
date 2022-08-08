import { createApp } from 'vue'
import App from './App.vue'
import { globalCookiesConfig } from "vue3-cookies";
import router from './router'
import VueCookies from "vue3-cookies";

globalCookiesConfig({
  expireTimes: "5m",
  path: "/",
  domain: "",
  secure: true,
  sameSite: "None",
});

const app = createApp(App);

app.use(router);
router.app = app;

app.use(VueCookies);
app.mount("#app");
