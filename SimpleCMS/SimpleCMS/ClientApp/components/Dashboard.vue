<template>
    <div class="container">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <h1>Dashboard</h1>

                <p>
                    <router-link :to="{ name: 'dashboard' }">Dashboard</router-link> |
                    <router-link :to="{ name: 'login' }">Login</router-link>
                    <router-link :to="{ name: 'posts' }">Posts</router-link>
                </p>

                <div class="panel panel-default">
                    <div class="panel-heading">Dashboard</div>
                    <div class="panel-body">
                        <p>Data: ""</p>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>


<script>
    export default {
        data() {
            return {
                data: 'nothing'
            }
        },
        mounted() {
            //axios.get('/api/dashboard', {
            //    headers: {
            //        Authorization: 'Bearer ' + localStorage.getItem('token')
            //    }
            //})
            //    .then(response => {
            //        this.data = response.data.data
            //    }).catch(error => {

            //    })
        }
    }

    //import TodoItem from './TodoItem'

    //export default {
    //    components: { TodoItem },
    //    mounted() {
    //        this.$store.dispatch('getAllTodos')
    //    },
    //    computed: {
    //        name() {
    //            return this.$store.state.userName
    //        },
    //        todos() {
    //            return this.$store.state.todos
    //        },
    //        complete() {
    //            return this.todos.filter(todo => todo.completed).length
    //        },
    //        remaining() {
    //            return this.todos.filter(todo => !todo.completed).length
    //        }
    //    },
    //    methods: {
    //        addTodo(e) {
    //            var text = e.target.value || ''
    //            text = text.trim()

    //            if (text.length) {
    //                this.$store.dispatch('addTodo', { text })
    //            }

    //            e.target.value = ''
    //        },
    //    }
    //}
</script>

<!--<style>
    .new-todo {
        width: 100%;
        font-size: 18px;
        margin-bottom: 15px;
        border-top-width: 0;
        border-left-width: 0;
        border-right-width: 0;
        border-bottom: 1px solid rgba(0, 0, 0, 0.2);
    }
</style>-->
