<template>
    <div class="text-center">
        <img class="mb-4" src="@/assets/image/logo.svg" alt="" width="72" height="72">
    </div>
    <section style="height: 95%">
        <chatBox />
    </section>
</template>
<script>
// @ is an alias to /src
import chatBox from '@/components/Chatroom/chatBox.vue'

export default {
    name: 'ChatroomView',
    components: {
        chatBox
    }
}
</script>
