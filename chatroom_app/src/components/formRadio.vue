<template>
    <div class="checkbox mb-3">
        <label v-for="(item, index) in this.options" :key="index">
            <input v-bind:name="this.name" type="radio" v-bind:value="item.value">{{ item.htmltext }}
        </label>
    </div>
</template>
<script>
import { defineComponent } from "vue";

export default defineComponent({
    props: ["options", "name"],
})
</script>