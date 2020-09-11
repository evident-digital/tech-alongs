<template>
  <div class="c-todo">
    <div class="c-todo__board">
      <h2 class="c-todo__title ut-todo-title">{{ title }} <font-awesome-icon :icon="['fas', 'list-alt']"></font-awesome-icon></h2>
      <ul v-if="todos.length" class="c-todo__list ut-todo-list">
        <li v-for="(todo, index) in todos" :key="index" class="c-todo__item ut-todo-item" @click="removeTodoItem(todo)">
          {{ todo }}
        </li>
      </ul>
    </div>

    <input type="text" class="c-todo__input ut-todo-input" :placeholder="placeholderText" v-model="inputValue" @keyup.enter="addTodoItem($event.target.value)">
  </div>
</template>

<script>
export default {
  name: 'TodoList',
  data() {
    return {
      todos: [],
      inputValue: ''
    }
  },
  props: {
    title: {
      type: String,
      default: ''
    },
    placeholderText: {
      type: String,
      default: 'What do you want to do next?'
    }
  },
  methods: {
    addTodoItem(item) {
      if (item) {
        this.inputValue = ''

        this.todos.push(item) 
      }
    },
    removeTodoItem(item) {
      const filteredTodos = this.todos.filter(todo => todo !== item)

      this.todos = filteredTodos
    }
  }
}
</script>

<style>
.c-todo {
  width: 100%;
	max-width: 350px;
	margin: 0 auto;
}

.c-todo__board {
  border-radius: 10px;
  background: #42b883;
  box-shadow:  5px 5px 10px #3dab7a, 
             -5px -5px 10px #47c58c;
  margin-bottom: 50px;
  overflow: hidden;
}

.c-todo__title {
  display: flex;
  align-items: center;
  justify-content: space-between;
	color: #35495e;
	padding: 20px 25px;
	margin: 0;
}

.c-todo__item {
  cursor: pointer;
	display: block;
	padding: 20px 25px;
	position: relative;
	color: #35495e;
	transition: box-shadow 100ms linear, color 100ms linear;	
}

.c-todo__item:hover {
  box-shadow: inset 5px 5px 10px #3dab7a, inset -5px -5px 10px #47c58c;
	color:#35495e;
  text-decoration: line-through;
}

.c-todo__item:last-child {
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
}

.c-todo__item + .c-todo__item {
  margin-top: 0;
}

.c-todo__input {
  width: 100%;
  border-radius: 10px;
  background: #42b883;
  box-shadow: inset 5px 5px 10px #3dab7a, 
            inset -5px -5px 10px #47c58c;
	border: none;
	border-radius: 10px;
	margin: 0;
	padding: 20px 25px;
  font-size: 0.9rem;
}

.c-todo__input::placeholder, .c-todo__input:focus {
  color: #dadada;
}

.c-todo__input:focus {
  color: #35495e;
  outline:none;
}
</style>
