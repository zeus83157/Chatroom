<template>
  <div class="text-center">
    <img class="mb-4" src="@/assets/logo.svg" alt="" width="72" height="72">
  </div>
  <div class="text-center" id=content>
    <form id="loginForm" class="form-signin">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <input v-model="LoginForm.username" name="username" class="form-control" placeholder="Username">
      <input v-model="LoginForm.password" name="password" type="password" class="form-control" placeholder="Password">
      <div class="checkbox mb-3">
      </div>
      <input type="button" @click="btnLogin_Click(this)" class="btn btn-lg btn-primary btn-block" value="Submit" />
    </form>
    <form id="registerForm" class="form-signin">
      <h1 class="h3 mb-3 font-weight-normal">Please Register</h1>
      <input name="username" class="form-control" v-model="RegisterForm.username" placeholder="Username">
      <input type="password" name="password" v-model="RegisterForm.password" class="form-control"
        placeholder="Password">
      <input type="email" name="email" v-model="RegisterForm.email" class="form-control" placeholder="Email">
      <div class="checkbox mb-3">
        <label>
          <input type="radio" value="male" v-model="RegisterForm.gender">Male
        </label>
        <label>
          <input type="radio" value="female" v-model="RegisterForm.gender">Female
        </label>
      </div>
      <div class="checkbox mb-3">
      </div>
      <input type="button" @click="btnRegister_Click(this)" class="btn btn-lg btn-primary btn-block" value="Submit" />
    </form>
  </div>
  <div class="text-center">
    <p class="mt-5 mb-3 text-muted">© Kernel.Yang</p>
  </div>
</template>

<style>
#loginForm{
  margin-bottom: 12rem;
}
#registerForm{
  margin-bottom: 9rem;
}
#content {
  height: 450px;
  overflow: auto;
}

label {
  margin-right: 1rem;
}

html,
body {
  height: 100%;
}

body {
  display: -ms-flexbox;
  display: flex;
  -ms-flex-align: center;
  align-items: center;
  padding-top: 40px;
  padding-bottom: 40px;
  background-color: #f5f5f5;
}

.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
}

.form-signin .checkbox {
  font-weight: 400;
}

.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}

.form-signin .form-control:focus {
  z-index: 2;
}

.bd-placeholder-img {
  font-size: 1.125rem;
  text-anchor: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

@media (min-width: 768px) {
  .bd-placeholder-img-lg {
    font-size: 3.5rem;
  }
}
</style>

<script>
import { useCookies } from "vue3-cookies";
import { defineComponent } from "vue";
const axios = require('axios').default;
export default defineComponent({
  name: "HomePage",
  setup() {
    const { cookies } = useCookies();
    return { cookies };
  },
  data() {
    return {
      LoginForm: {
        username: "",
        password: ""
      },
      RegisterForm: {
        username: "",
        password: "",
        email: "",
        gender: "male"
      }
    }
  },
  methods: {
    btnLogin_Click: (component) => {
      let api_url = process.env.VUE_APP_ENDPOINT + 'api/Auth/login';
      let data = JSON.stringify(component.LoginForm);
      axios.post(api_url, data, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(function (response) {
          component.cookies.set("token", response.data.token)
        })
        .catch(function (error) {
          alert(error);
        });
    },
    btnRegister_Click: (component) => {
      let api_url = process.env.VUE_APP_ENDPOINT + 'api/Account/register';
      let gender = component.RegisterForm.gender == "male";
      let data = component.RegisterForm;
      data.gender = gender;
      data = JSON.stringify(data);

      axios.post(api_url, data, {
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(function () {
          alert("Welcome!")
        })
        .catch(function (error) {
          alert(error);
        });
    }
  }
});
</script>