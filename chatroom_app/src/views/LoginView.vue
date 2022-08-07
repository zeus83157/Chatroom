<template>
  <appForm v-bind:dataset="dataset" v-bind:successfunc="successfunc" url="api/Auth/login" />
</template>
<script>
// @ is an alias to /src
import appForm from '@/components/appForm.vue'
import { useCookies } from "vue3-cookies";

export default {
  name: 'LoginView',
  components: {
    appForm
  },
  data() {
    return {
      dataset: {
        url: process.env.VUE_APP_WEBAPI_ENDPOINT + "api/Auth/login",
        textfields: [{
          name: "username",
          value: "",
          attr: {
            type: "text",
            placeholder: "please input your username"
          }
        },
        {
          name: "password",
          value: "",
          attr: {
            type: "password",
            placeholder: "please input your password"
          }
        }]
      },
    }
  },
  methods: {
    successfunc: (response) => {
      const { cookies } = useCookies();
      cookies.set("token", response.data.token, 60 * 10);
    }
  }
}
</script>
