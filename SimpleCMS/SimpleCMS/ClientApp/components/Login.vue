<template>
    <div>
        <h2>Login</h2>
        <p v-if="$route.query.redirect">
            You need to login first.
        </p>

        <form @submit.prevent="login" autocomplete="off">
            <label for="username">UserName</label>
            <input id="username" v-model="username" placeholder="admin">
            <label for="password">Password</label>
            <input id="password" v-model="password" placeholder="password" type="password">
            <button type="submit">login</button>
            <p v-if="loginError" class="error">{{loginError}}</p>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                username: '',
                password: '',
                error: false
            }
        },
        computed: {
            loginError() {
                return this.$store.state.loginError
            }
        },
        methods: {
            login() {
                  this.$store.dispatch('login', {
                    username: this.username,
                    password: this.password
                   })
                }
            }
        }
</script>

<style scoped>
    .error {
        color: red;
    }

    label {
        display: block;
    }

    input {
        display: block;
        margin-bottom: 10px;
    }
</style>
