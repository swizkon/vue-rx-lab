<template>
  <div class="container body-content">
    <app-nav></app-nav>
    <div id="app">
      <router-view></router-view>
    </div>
    <app-footer></app-footer>
  </div>
</template>

<script>

import Nav from './components/Nav'
import Footer from './components/Footer'
import VueMarkdown from 'vue-markdown'

  export default {
    name: 'app',
    data() {
      return {
      }
    },
    components: {
      'app-nav': Nav,
      'app-footer': Footer,
      'vue-markdown': VueMarkdown
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