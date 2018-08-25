import router from '../router'

export const mutations = {
    loggedIn(state, data) {
        state.loggedIn = true
        console.log(state);
        //state.userName = (data.name || '').split(' ')[0] || 'Hello'

        let redirectTo = state.route.query.redirect || '/'
        router.push(redirectTo)
    },

    loggedOut(state) {
        state.loggedIn = false
        router.push('/login')
    },

    loginError(state, message) {
        state.loginError = message
    },

    loadPosts(state, posts) {
        state.posts = posts || []
    },

    loginUser(state) {
        state.loggedIn = true
        router.push({ name: 'dashboard' })
    },
    logoutUser(state) {
        state.loggedIn = false
        router.push('/login')
    },
}
