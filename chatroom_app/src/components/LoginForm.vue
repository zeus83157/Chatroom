<template>
    <div class="text-center">
        <form class="form">
            <input v-model="LoginForm.username" name="username" class="form-control" placeholder="Username">
            <input v-model="LoginForm.password" name="password" type="password" class="form-control"
                placeholder="Password">
            <div class="checkbox mb-3">
            </div>
            <input type="button" @click="btnLogin_Click(this)" class="btn btn-lg btn-primary btn-block"
                value="Submit" />
        </form>
    </div>
</template>

<style lang="css" src="@/assets/css/Form.css"></style>

<script>
import { useCookies } from "vue3-cookies";
import { defineComponent } from "vue";
const axios = require('axios').default;
export default defineComponent({
    name: "LoginForm",
    setup() {
        const { cookies } = useCookies();
        return { cookies };
    },
    data() {
        return {
            LoginForm: {
                username: "",
                password: ""
            }
        }
    },
    methods: {
        btnLogin_Click: (component) => {
            let api_url = process.env.VUE_APP_WEBAPI_ENDPOINT + 'api/Auth/login';
            let data = JSON.stringify(component.LoginForm);
            axios.post(api_url, data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(function (response) {
                    component.cookies.set("token", response.data.token, 60 * 10)
                })
                .catch(function (error) {
                    alert(error);
                });
        }
    }
});
</script>