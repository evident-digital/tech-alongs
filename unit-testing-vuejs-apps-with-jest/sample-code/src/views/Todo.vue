<template>
  <div class="c-app__todo">
    <div class="c-app__nav">
      <nav class="c-nav">
        <router-link to="/" title="Home" class="c-nav__link"><font-awesome-icon :icon="['fas', 'house-user']" class="c-nav__icon"></font-awesome-icon></router-link>
        <router-link to="/presentation" title="Presentation" class="c-nav__link"><font-awesome-icon :icon="['fas', 'file-alt']" class="c-nav__icon"></font-awesome-icon></router-link>
      </nav>
    </div>
    <todo-list title="To-Do List"/>
  </div>
</template>

<script>
// @ is an alias to /src
import TodoList from '@/components/TodoList.vue'

export default {
  name: 'todoApp',
  components: {
    TodoList
  }
}
</script>
