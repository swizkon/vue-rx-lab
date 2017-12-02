import Vue from 'vue'
import App from './App'

import router from './router'

import Toasted from 'vue-toasted';

import AccountHistory from './components/AccountHistory'
import Footer from './components/Footer'

import "vueify/lib/insert-css" // required for .vue file <style> tags

Vue.config.productionTip = false

Vue.use(Toasted, {
    position: 'bottom-right',
    duration: 1500
});

/* eslint-disable no-new */ 
new Vue({
    el: '#app',
    router,
    render: h => h(App),
    components: {
       'account-history': AccountHistory,
       'app-footer': Footer 
    }
})