<template>
  <appNav />
  <section style="height: 95%">
    <appForm v-bind:dataset="dataset" v-bind:successfunc="successfunc" url="api/Account/register" />
  </section>
  <appFooter />
</template>
<script>
// @ is an alias to /src
import appForm from '@/components/Form/appForm.vue'
import router from '../router'
import appNav from '@/components/appNav.vue'

export default {
  name: 'RegisterView',
  components: {
    appForm,
    appNav
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
            placeholder: "please input your password",
            autocomplete: "off"
          }
        },
        {
          name: "email",
          value: "",
          attr: {
            type: "email",
            placeholder: "please input your email"
          }
        }],
        radiofields: [{
          name: "gender",
          options: [{
            htmltext: "Male",
            value: true
          }, {
            htmltext: "Female",
            value: false
          }],
          attr: {
            checked: "pacheckedssword",
          }
        }
        ]
      }
    }
  },
  methods: {
    successfunc: (response) => {
      if (response)
        alert("Register Success!");
      router.push({ path: "/" });
    }
  }
}
</script>
