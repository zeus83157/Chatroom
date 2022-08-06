<template>
    <div class="text-center">
        <form class="form">
            <input name="username" class="form-control" v-model="RegisterForm.username" placeholder="Username">
            <input type="password" name="password" v-model="RegisterForm.password" class="form-control"
                placeholder="Password">
            <input type="email" name="email" v-model="RegisterForm.email" class="form-control" placeholder="Email">
            <br>
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
            <input type="button" @click="btnRegister_Click(this)" class="btn btn-lg btn-primary btn-block"
                value="Submit" />
        </form>
    </div>
</template>

<style lang="css" src="@/assets/css/Form.css">
</style>

<script>
import { defineComponent } from "vue";
const axios = require('axios').default;
export default defineComponent({
    name: "RegisterForm",
    data() {
        return {
            RegisterForm: {
                username: "",
                password: "",
                email: "",
                gender: "male"
            }
        }
    },
    methods: {
        btnRegister_Click: (component) => {
            let api_url = process.env.VUE_APP_WEBAPI_ENDPOINT + 'api/Account/register';
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