<template>
  <LoginForm />
  <appForm v-bind:dataset="dataset" />
</template>
<script>
// @ is an alias to /src
import LoginForm from '@/components/LoginForm.vue'
import appForm from '@/components/appForm.vue'

export default {
  name: 'LoginView',
  components: {
    LoginForm,
    appForm
  },
  create: function () {

  },
  data: function () {
    return {
      dataset: {
        names: ["username", "password"],
        recard: ["test", "test"],
        attrs: [{
          placeholder: "username",
          type: "text"
        }, {
          placeholder: "password",
          type: "password"
        }]
      }
    }
  }
}
</script>
