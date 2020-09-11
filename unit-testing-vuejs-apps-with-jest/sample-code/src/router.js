import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Presentation from './views/Presentation.vue'
import Todo from './views/Todo.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/presentation',
      name: 'presentation',
      component: Presentation
    },
    {
      path: '/app',
      name: 'todo',
      component: Todo
    }
  ]
})
