<template>
    <form class="form">
        <formTextbox v-for="(item, index) in this.dataset.textfields" :key="index" v-bind="item.attr" v-bind:name="item.name" v-bind:value="item.value" style="margin-bottom: 10px;" />
        <formRadio v-for="(item, index) in this.dataset.radiofields" :key="index" v-bind="item.attr" v-bind:name="item.name" v-bind:options="item.options" style="margin-bottom: 10px;" />
        <input type="button" @click="btnLogin_Click(this)" class="btn btn-lg btn-primary btn-block" value="Submit" />
    </form>
</template>

<style lang="css" src="@/assets/css/Form.css">
</style>

<script>
import { defineComponent } from "vue";
import formTextbox from "@/components/formTextbox.vue";
import formRadio from "@/components/formRadio.vue";
export default defineComponent({
    props: ["dataset", "url"],
    components: {
        formTextbox,
        formRadio
    },
    methods: {
        btnLogin_Click(component) {
            console.log(component);
        }
    }
})
</script>