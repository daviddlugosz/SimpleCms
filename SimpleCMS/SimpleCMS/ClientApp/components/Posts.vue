<template>
    <div class="container">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <h1>Posts</h1>


                <div class="panel panel-default">
                    <div class="panel-body">
                        <div v-if="postsCount > 0">
                            <div v-for="post in posts" :style="{ backgroundImage: 'url(' + post.coverImagePath + ')' }" class="post">{{post.name}}</div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>


<script>
    export default {
        mounted() {
            this.$store.dispatch('loadPosts')
        },
        computed: {
            posts() {
                return this.$store.state.posts
            },
            postsCount() {
                return this.$store.state.posts.length
            }
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

<style>
    .post {
        width: 200px;
        height: 200px;
    }
</style>
