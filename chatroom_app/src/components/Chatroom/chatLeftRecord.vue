<template>
    <li style="width:100%">
        <div class="msj macro">
            <div class="avatar"><img class="img-circle" style="width:65%;"
                    v-bind:src="image">
            </div>
            <div class="text text-l">
                <p>{{message}}</p>
                <p><small>{{datetime}}</small></p>
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