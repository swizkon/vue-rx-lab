<template>
  <div class="container body-content">
    <nav></nav>
    <div id="app">
      <div class="hello">
        <h1>{{ msg }}</h1>
      </div>
      <router-view></router-view>
    </div>
    <footer></footer>
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
      'nav': Nav,
      'footer': Footer
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