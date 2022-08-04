<template>
    <form class="form">
        <formTextbox style="margin-bottom: 10px;" />
        <input type="button" @click="btnLogin_Click(this)" class="btn btn-lg btn-primary btn-block" value="Submit" />
    </form>
</template>

<style lang="css" src="@/assets/css/Form.css">
</style>

<script>
import { defineComponent } from "vue";
import formTextbox from "@/components/formTextbox.vue";
export default defineComponent({
    props: ["dataset"],
    components: {
        formTextbox
    },
    methods: {
        btnLogin_Click: function () {
        }
    }
})
</script>