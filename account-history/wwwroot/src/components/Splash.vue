<template>
  <div class="container body-content">
    <nav></nav>

      <div class="hello">
        <h1>{{ msg }}</h1>
      </div>

    <footer></footer>
  </div>
</template>

<script>

import Nav from '../components/Nav'
import Footer from '../components/Footer'

  export default {
    name: 'splash',
    data() {
      return {
        msg: 'Enter account id:' 
      }
    },
    components: {
      'nav': Nav,
      'footer': Footer
    },
    created () {
    }
  } 
</script>