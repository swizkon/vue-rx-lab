<template>
  <div class="hello">
    <h1>{{ label }}</h1>
    <form v-on:submit.prevent="onSubmit">
      <input class="input-lg" name="entityid" type="number" v-model="entityId" placeholder="Enter entity id" />
    </form>
  </div>
</template>

<script>
  export default {
    name: 'hello',
    data() { 
      return {
        label: `Enter  id`,
        entityId: '12345'
      }
    },
    
    components: {
    },

    created () {
    },
    methods: {
        onSubmit: function (event) {
          this.$toasted.info('Go to history for entity ' + this.entityId)
          
          this.$router.push({ name: 'AccountHistory', params: { id: this.entityId }})
        }
      }
  }
</script>