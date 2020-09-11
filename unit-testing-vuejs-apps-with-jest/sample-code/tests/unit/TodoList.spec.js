import { shallowMount } from '@vue/test-utils'
import TodoList from '@/components/TodoList.vue'

describe('TodoList.vue', () => {
  it('renders props.title when passed', () => {
    const title = 'My title'
    const wrapper = shallowMount(TodoList, {
      propsData: { title }
    })

    const el = wrapper.find('.ut-todo-title')
    expect(el.text()).toMatch(title)
  })

  it('renders props.placeholderText when passed', () => {
    const placeholderText = 'Placeholder text'
    const wrapper = shallowMount(TodoList, {
      propsData: { placeholderText }
    })

    const input = wrapper.find('.ut-todo-input')
    expect(input.element.placeholder).toMatch(placeholderText)
  })

  it('renders data.todos correctly when added', async () => {
    const wrapper = shallowMount(TodoList)
    const todoText = 'My first to do item'

    expect(wrapper.find('.ut-todo-list').exists()).toBe(false)

    const input = wrapper.find('.ut-todo-input')
    await input.setValue(todoText)

    expect(input.element.value).toBe(todoText)

    await input.trigger('keyup.enter')

    expect(wrapper.find('.ut-todo-list').exists()).toBe(true)
    expect(wrapper.find('.ut-todo-item').exists()).toBe(true)
    expect(input.element.value).toBe('')
  })

  it('renders data.todos correctly when removed', async () => {
    const wrapper = shallowMount(TodoList)
    const todoText = 'My first to do item'

    const input = wrapper.find('.ut-todo-input')
    await input.setValue(todoText)
    await input.trigger('keyup.enter')

    const todoItem = wrapper.find('.ut-todo-item')
    await todoItem.trigger('click')

    expect(wrapper.find('.ut-todo-list').exists()).toBe(false)
    expect(wrapper.find('.ut-todo-item').exists()).toBe(false)
  })
})
