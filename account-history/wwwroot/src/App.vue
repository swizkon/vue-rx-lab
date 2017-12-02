<template>
  <div class="container body-content">
    <app-nav></app-nav>
    <div id="app">
      <div class="hello">
        <h1>{{ msg }}</h1>
      </div>
      <router-view></router-view>
    </div>
    <app-footer></app-footer>
  </div>
</template>

<script>

import Nav from './components/Nav'
import Footer from './components/Footer'

  export default {
    name: 'app',
    data() {
      return {
        msg: 'Bundled with Brunch!'
      }
    },
    components: {
      'app-nav': Nav,
      'app-footer': Footer
    }
  } 
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
  }
</style>