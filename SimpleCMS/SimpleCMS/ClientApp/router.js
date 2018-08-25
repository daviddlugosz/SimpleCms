import Vue from 'vue'
import Router from 'vue-router'
import store from './store'
import Dashboard from './components/Dashboard.vue'
import Login from './components/Login.vue'
import Posts from './components/Posts.vue'

Vue.use(Router)

function requireAuth(to, from, next) {
    // check if the route requires authentication and user is not logged in
    if (to.matched.some(route => route.meta.requiresAuth) && !store.state.isLoggedIn) {
        // redirect to login page
        next({ name: 'login' })
        return
    }

    // if logged in redirect to dashboard
    if (to.path === '/login' && store.state.isLoggedIn) {
        next({ name: 'dashboard' })
        return
    }

    next()
}

export default new Router({
    mode: 'history',
    base: __dirname,
    beforeEnter: requireAuth,
    routes: [
        { name: 'dashboard', path: '/', component: Dashboard, meta: { requiresAuth: true } },
        { name: 'login', path: '/login', component: Login },
        {
            path: '/logout',
            async beforeEnter(to, from, next) {
                await store.dispatch('logout')
            }
        },
        { name: 'posts', path: '/posts', component: Posts, meta: { requiresAuth: true } },
    ]
})