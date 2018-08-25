export const state = {
    posts: [],
    loggedIn: !!localStorage.getItem('token'),
    loginError: null,
    userName: null
}