<template>
  <div class="hello">
    <h1>{{ title }}</h1>

    <div class="loading" v-if="loading">
      Loading...
    </div>
    <div v-if="error" class="error">
        Error: {{ error }}
    </div>

    <h2>lastProcess: <strong>{{ lastProcess }}</strong></h2>

    <div v-if="circuitDetails" class="content">
      <h2>{{ circuitDetails.name }}</h2>
      <p>{{ circuitDetails.id }}</p>
    </div>

    <h3>Dump</h3>
    <pre><code>{{dump}}</code></pre>
  </div>
</template>

<script>

import { Observable } from 'rxjs/Observable'
import 'rxjs/add/observable/interval'

  export default {
    name: 'accountHistory',
    data() { 
      return {
        title: 'Entity history',
        circuitDetails: null,
        lastProcess: null,
        loading: true,
        error: null,
        dump: null
      }
    },

    created () {
      var _this = this
      var id = this.$route.params.id

      console.log(id)
      
      _this.loading = true

      var url = (id) ? "/api/accountEvent?accountId=" + id 
                    : "/api/accountEvent/mocks/" + this.$route.params.mockfile

      this.$toasted.info("url: " + url)

        fetch(url)
        .then(function(response) {
          return response.json();
         }).then(function(jsonData) {
         _this.dump = jsonData

            var timer$ = Observable.interval(300)
            var event$ = Observable.from(jsonData)

            var stream = Observable.zip(event$, timer$, (a,b) => a);

            stream.subscribe(function (e) {
                          _this.$toasted.info("e: " + e.source)
                            });

            stream.pluck('source')
                      .distinctUntilChanged()
                      .subscribe(v => {
                        _this.lastProcess = v;
                      });                            
        });
    }
  }
</script>