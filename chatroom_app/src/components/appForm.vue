<template>
    <form class="form">
        <formTextbox v-for="(item, index) in this.dataset.textfields" :key="index" v-bind="item.attr"
            v-bind:name="item.name" :value="item.value" v-on:input="this.fields[item.name] = $event.target.value"
            style="margin-bottom: 10px;" />
        <formRadio v-for="(item, index) in this.dataset.radiofields" :key="index" v-bind="item.attr"
            v-bind:name="item.name" v-bind:options="item.options"
            v-on:input="this.fields[item.name] = $event.target.value" style="margin-bottom: 10px;" />
        <input type="button" @click="btnLogin_Click(this)" class="btn btn-lg btn-primary btn-block" value="Submit" />
    </form>
</template>

<style lang="css" src="@/assets/css/Form.css">
</style>

<script>
import { defineComponent } from "vue";
import formTextbox from "@/components/formTextbox.vue";
import formRadio from "@/components/formRadio.vue";
const axios = require('axios').default;
export default defineComponent({
    name: 'appForm',
    props: ["dataset", "url", "successfunc"],
    components: {
        formTextbox,
        formRadio
    },
    created() {
        let obj = {}
        if (this.dataset.textfields)
            this.dataset.textfields.forEach(function (item) {
                obj[item.name] = item.value;
            });
        if (this.dataset.radiofields)
            this.dataset.radiofields.forEach(function (item) {
                obj[item.name] = String(item.options[0].value);
            });
        this.fields = obj;
    },
    data() {
        return {
            fields: {}
        }
    },
    methods: {
        btnLogin_Click(component) {
            let url = process.env.VUE_APP_WEBAPI_ENDPOINT + this.url;
            let data = JSON.stringify(component.fields);
            axios.post(url, data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(function (response) {
                    component.successfunc(response);
                })
                .catch(function (error) {
                    console.log(error);
                    alert("Action Fail.")
                });
        }
    }
})
</script>