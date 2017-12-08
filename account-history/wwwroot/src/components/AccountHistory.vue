<template>
  <div class="hello">
    <h1>{{ title }}</h1>

    <div class="loading" v-if="loading">
      Loading...
    </div>
    <div v-if="error" class="error">
        Error: {{ error }}
    </div>

    <div v-if="circuitDetails" class="content">
      <h2>{{ circuitDetails.name }}</h2>
      <p>{{ circuitDetails.id }}</p>
    </div>

    <h3>Dump</h3>
    <pre><code>{{dump}}</code></pre>
  </div>
</template>

<script>

  import { Observable, Subject } from "rxjs/Rx"

  export default {
    name: 'accountHistory',
    data() { 
      return {
        title: 'Entity history',
        circuitDetails: null,
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

                 // Observable.from(jsonData)
                 //           .subscribe(function (e) {
                 //         this.$toasted.info("e: " + e)
                 //           });
        });
    },
    updated (){
      this.$nextTick(function () {
        // Handle data? 
      })
    }
  }
</script>