import axios from 'axios'

const sleep = ms => {
    return new Promise(resolve => setTimeout(resolve, ms))
}

const addAuthHeader = () => {
    return {
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token')
        }
    }
}

export const actions = {
    checkLoggedIn({ commit }) {
        //if (oktaAuth.client.tokenManager.get('access_token')) {
        //    let idToken = oktaAuth.client.tokenManager.get('id_token')
        //    commit('loggedIn', idToken.claims)
        //}
    },

    async login({ dispatch, commit }, data) {
        let authResponse
        try {
            //this.loginError = false;
            axios.post('api/users/authenticate', {
                username: data.username,
                password: data.password
            }).then(response => {
                console.log(response.data.token);
                // login user, store the token and redirect to dashboard
                localStorage.setItem('token', response.data.token)
                commit('loginUser')
            }).catch(error => {
                commit('logoutUser')
            });
            //authResponse = await oktaAuth.client.signIn({
            //    username: data.email,
            //    password: data.password
            //})
        }
        catch (err) {
            let message = err.message || 'Login error'
            dispatch('loginFailed', message)
            return
        }

        commit('loggedIn')

        //if (authResponse.status !== 'SUCCESS') {
        //    console.error('Login unsuccessful, or more info required', response.status)
        //    dispatch('loginFailed', 'Login error')
        //    return
        //}

        //let tokens
        //try {
        //    //tokens = await oktaAuth.client.token.getWithoutPrompt({
        //    //    responseType: ['id_token', 'token'],
        //    //    scopes: ['openid', 'email', 'profile'],
        //    //    sessionToken: authResponse.sessionToken,
        //    //})
        //}
        //catch (err) {
        //    let message = err.message || 'Login error'
        //    dispatch('loginFailed', message)
        //    return
        //}

        //// Verify ID token validity
        //try {
        //    //await oktaAuth.client.token.verify(tokens[0])
        //} catch (err) {
        //    dispatch('loginFailed', 'An error occurred')
        //    console.error('id_token failed validation')
        //    return
        //}

        ////oktaAuth.client.tokenManager.add('id_token', tokens[0]);
        ////oktaAuth.client.tokenManager.add('access_token', tokens[1]);

        //commit('loggedIn', tokens[0].claims)
    },

    async logout({ commit }) {
        //oktaAuth.client.tokenManager.clear()
        //await oktaAuth.client.signOut()
        localStorage.removeItem('token')
        commit('logoutUser')
    },

    async loginFailed({ commit }, message) {
        commit('loginError', message)
        await sleep(3000)
        commit('loginError', null)
    },

    async loadPosts({ commit }) {
        let response = await axios.get('/api/posts/listallposts', addAuthHeader())

        if (response && response.data) {
            let updatedPosts = response.data
            commit('loadPosts', updatedPosts)
        }
    },

    //async addTodo({ dispatch }, data) {
    //    // Todo: save a new to-do item
    //    await dispatch('getAllTodos')
    //},

    //async toggleTodo({ dispatch }, data) {
    //    // Todo: toggle to-do item completed/not completed
    //    await dispatch('getAllTodos')
    //},

    //async deleteTodo({ dispatch }, id) {
    //    // Todo: delete to-do item
    //    await dispatch('getAllTodos')
    //}
}
