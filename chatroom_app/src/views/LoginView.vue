<template>
  <appForm v-bind:dataset="dataset" url="api/Auth/login" />
</template>
<script>
// @ is an alias to /src
import appForm from '@/components/appForm.vue'

export default {
  name: 'LoginView',
  components: {
    appForm
  },
  data() {
    return {
      dataset: {
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
  }
}
</script>
