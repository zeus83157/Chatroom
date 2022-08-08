<template>
    <li style="width:100%;">
        <div class="msj-rta macro">
            <div class="text text-r">
                <p>{{ message }}</p>
                <p><small>{{ datetime }}</small></p>
            </div>
            <div class="avatar" style="padding:0px 0px 0px 10px !important">
                <img class="img-circle" style="width:65%;" v-bind:src="image">
            </div>
        </div>
    </li>
</template>
<script>
import { defineComponent } from "vue";
export default defineComponent({
    name: "chatRecord",
    props: ["user", "datetime", "message", "image"]
})
</script>