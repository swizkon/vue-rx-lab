import Vue from 'vue'
import Router from 'vue-router'

import Hello from '../components/Hello'
import CircuitDetails from '../components/CircuitDetails'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/accounts/:id/history',
      name: 'AccountHistory',
      component: CircuitDetails
    },
    {
      path: '*',
      redirect: '/'
    }
  ]
})