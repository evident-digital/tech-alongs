<template>
  <div class="c-app__presentation">
    <div class="c-app__nav">
      <nav class="c-nav">
        <router-link to="/" title="Home" class="c-nav__link"><font-awesome-icon :icon="['fas', 'house-user']" class="c-nav__icon"></font-awesome-icon></router-link>
        <router-link to="/app" title="App" class="c-nav__link"><font-awesome-icon :icon="['fas', 'list-alt']" class="c-nav__icon"></font-awesome-icon></router-link>
      </nav>
    </div>

    <div class="c-presentation">
      <div class="c-presentation__slides">
        <hooper :settings="hooperSettings">
          <slide>
            <h1>Unit testing with Jest + Vue Test Utils</h1>
          </slide>
          <slide>
            <h2>What benefits does it bring?</h2>
            <div class="o-separator"></div>
            <h5>More confidence</h5>
            <h5>Better code quality</h5>
            <h5>Better documentation</h5>
          </slide>
          <slide>
            <h2>What should we test?</h2>
            <h5>Components (through the Component Contract by <a href="https://www.oreilly.com/library/view/testing-vuejs-applications/9781617295249/" target="_blank">Ed Yerburgh</a>)</h5>
            <div class="o-separator"></div>
            <div class="c-table">
              <div class="c-table__col">
                <ul>
                  <li class="c-table__title"><strong>Inputs</strong></li>
                  <li>Data</li>
                  <li>Props</li>
                  <li>User Interaction</li>
                  <li>Lifecycle Methods</li>
                  <li>Vuex Store</li>
                  <li>Route Params</li>
                </ul>
              </div>
              <div class="c-table__col">
                <ul>
                  <li class="c-table__title"><strong>Output</strong></li>
                  <li>What is rendered to the DOM</li>
                  <li>External function calls</li>
                  <li>Events emitted by the component</li>
                  <li>Route Change</li>
                  <li>Updates to the Vuex Store</li>
                  <li>Connection with children</li>
                </ul>
              </div>
            </div>
          </slide>
          <slide>
            <h3>What shouldn't we test?</h3>
            <div class="o-separator"></div>
            <h5>Implementation details</h5>
            <h5>The framework itself</h5>
            <h5>Third party libraries</h5>
          </slide>
        </hooper>
      </div>
    </div>
  </div>
</template>

<script>
import { Hooper, Slide } from 'hooper';
import 'hooper/dist/hooper.css';

export default {
  name: 'Presentation',
  components: {
    Hooper,
    Slide
  },
  data() {
    return {
      hooperSettings: {
        vertical: true,
        centerMode: true,
        keysControl: true,
        wheelControl: false,

      }
    };
  }
}
</script>

<style>
.c-presentation {
  position: relative;
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 100%;
  text-align: center;
}

.c-presentation__slides {
  flex-grow: 1;
}

.c-table {
  display: flex;
  justify-content: space-around;
  width: 100%;
}

.c-table__title {
  font-size: 1.1rem;
}

.hooper {
  height: 100%;
}

.hooper-list {
  display: flex;
  flex-direction: column;
}

.hooper-slide {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.hooper.is-vertical .hooper-track {
  height: calc(100vh - 3.3333333333333335rem * 2);
}

.o-separator {
  margin-top: 2.7777777777777777rem;
}
</style>
