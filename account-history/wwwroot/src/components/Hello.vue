<template>
  <div class="hello">
    <h2>{{ msg }}</h2>
    <input type="text" />
  </div>
</template>

<script>
  export default {
    name: 'hello',
    data() { 
      return {
        msg: `Enter account id`
      }
    },
    
    components: {
    },

    created () {
      var _this = this;
    }
  }
</script>