<template>
  <div id="app" class="c-app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>

<style>
html, body {
  font-size: 18px;
	line-height: 1.5;
  color: #2c3e50;
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

html, body, button {
  font-size: 18px;
	line-height: 1.5;
}

body, ul, li {
  margin: 0;
}

ul, li {
  list-style: none;
	padding: 0;
}

li + li {
  margin-top: 0.5555555555555556rem;
}

a {
  color: #2c3e50;
}

* {
  box-sizing: border-box;
}

*:focus {
  outline: none;
}

h1 {
    font-size: 2.5rem;
}

h2 {
    font-size: 2rem;
}

h3 {
    font-size: 1.75rem;
}

h4 {
    font-size: 1.5rem;
}

h5 {
    font-size: 1.25rem;
}

h6 {
    font-size: 1rem;
}

h1, h2, h3, h4, h5, h6 {
    margin-bottom: .5rem;
    line-height: 1.2;
}

.c-app {
  height: 100vh;
  background-color: #42b883;
}

.c-app__nav {
  position: absolute;
  top: 2rem;
  left: 0;
  z-index: 1;
}

.c-app__todo {
  height: 100%;
}

.c-app__home, .c-app__todo {
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.c-app__todo, .c-app__presentation {
  padding: 3.3333333333333335rem 1.6666666666666667rem;
}

.c-nav__link, .c-nav__link--main {
  padding: 0.8333333333333334rem 1.1111111111111112rem; /* 15px 20px */
  color: #2c3e50;
}

.c-nav__link {
  display: block;
  box-shadow: 0 10px 20px rgba(0,0,0,0.19), 0 6px 6px rgba(0,0,0,0.23);
  border-top-right-radius: 10px;
  border-bottom-right-radius: 10px;
  background-color: #dadada;
}

.c-nav__link + .c-nav__link {
  margin-top: 0.05555555555555555rem; /* 1px */ 
}

.c-nav__link--main + .c-nav__link--main {
  margin-left: 1.3888888888888888rem; /* 25px */
}

.c-nav__link--main {
  display: inline-block;
  vertical-align: middle;
  border-radius: 10px;
  font-size: 1.6666666666666667rem; /* 30px */
  background: #42b883;
  color: #dadada;
  padding: 1.1111111111111112 1.3888888888888888rem; /* 20px 25px */
  box-shadow:  5px 5px 10px #3dab7a, 
             -5px -5px 10px #47c58c;
  transition: box-shadow 100ms linear;
}

.c-nav__link--main:hover {
  box-shadow: inset 5px 5px 10px #3dab7a, inset -5px -5px 10px #47c58c;
}

.c-nav__icon.c-nav__icon {
  width: 1.1111111111111112rem; /* 20px */
  max-height: 1rem;
}

.c-nav__icon--main.c-nav__icon--main {
  width: 1.6666666666666667rem; /* 30px */
  max-height: 1.6666666666666667rem; /* 30px */
}
</style>
