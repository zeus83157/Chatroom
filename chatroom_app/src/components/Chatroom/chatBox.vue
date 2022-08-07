<template>
    <div class="col-sm-5 col-sm-offset-6 frame" style="margin:auto;">
        <ul>
            <chatLeftRecord />
            <chatRightRecord />
        </ul>
        <div>
            <div class="msj-rta macro" style="margin: 8px;">
                <div class="text text-r" style="background:whitesmoke !important">
                    <input class="mytext" placeholder="Type a message" v-model="Newmsg" />
                </div>

            </div>
            <div style="margin: auto;">
                <button @click="send" style="margin-right: 10px;width: 50px; height: 40px; border-radius: 10px;">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                        class="bi bi-send" viewBox="0 0 16 16">
                        <path
                            d="M15.854.146a.5.5 0 0 1 .11.54l-5.819 14.547a.75.75 0 0 1-1.329.124l-3.178-4.995L.643 7.184a.75.75 0 0 1 .124-1.33L15.314.037a.5.5 0 0 1 .54.11ZM6.636 10.07l2.761 4.338L14.13 2.576 6.636 10.07Zm6.787-8.201L1.591 6.602l4.339 2.76 7.494-7.493Z" />
                    </svg>
                </button>
            </div>
        </div>
    </div>
</template>
<style lang="css" src="@/assets/css/Chatroom.css">
</style>
<script>
import { defineComponent } from "vue";
import chatLeftRecord from '@/components/Chatroom/chatLeftRecord.vue'
import chatRightRecord from '@/components/Chatroom/chatRightRecord.vue'
import * as signalr from '@microsoft/signalr'
export default defineComponent({
    name: "chatBox",
    components: {
        chatLeftRecord,
        chatRightRecord
    },
    created() {
        const token = this.$cookies.get("token");
        this.Connection = new signalr.HubConnectionBuilder()
            .withUrl(process.env.VUE_APP_WEBAPI_ENDPOINT + "ChatHub", {
                accessTokenFactory: () => token,
                skipNegotiation: true,
                transport: 1
            })
            .build();
    },
    async mounted() {
        async function start(connection) {
            try {
                await connection.start()
            } catch (err) {
                console.log('連線失敗')
            }
        }
        await start(this.Connection)
        const currentUser = this.$cookies.get("user");
        this.Connection.on("ReceiveMessage", function (user, datetime, message) {
            if (user == currentUser)
                console.log("I say: " + message + "(" + datetime + ")");
            else
                console.log(user + " say: " + message + "(" + datetime + ")");
        })
    },
    data() {
        return {
            Connection: null,
            CurrentRecord: [],
            OtherRecord: [],
            Newmsg: ""
        }
    },
    methods: {
        send() {
            this.Connection.invoke('SendMessage', this.Newmsg)
        }
    }
})
</script>