<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2>count: {{ count }}</h2>
  </div>
</template>

<script>

import {Observable} from 'rxjs/Observable'
import 'rxjs/add/observable/interval'

export default {
  name: 'HelloWorld',
  data () {
    return {
      msg: 'Welcome to Your sdfsdfVue.js App',
      count: 0
    }
  },
  created () {
      const counter = Observable.interval(1000)

      counter.subscribe(value => {

        this.count = value;
      })
  }
}
</script>