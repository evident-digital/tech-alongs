<template>
  <div class="c-app__home">
    <nav class="c-nav">
      <router-link to="/presentation" title="Presentation" class="c-nav__link--main"><font-awesome-icon :icon="['fas', 'file-alt']" class="c-nav__icon--main"></font-awesome-icon></router-link>
      <router-link to="/app" title="App" class="c-nav__link--main"><font-awesome-icon :icon="['fas', 'list-alt']" class="c-nav__icon--main"></font-awesome-icon></router-link>
    </nav>
  </div>
</template>

<script>
export default {
  name: 'home'
}
</script>
