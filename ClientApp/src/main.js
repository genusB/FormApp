import Vue from 'vue'
import App from './App.vue'
import Vuelidate from 'vuelidate'
import axios from 'axios'
import router from './router'
import vueCountryRegionSelect from 'vue-country-region-select'

Vue.config.productionTip = false
Vue.use(Vuelidate);
Vue.use(vueCountryRegionSelect)
Vue.prototype.$http = axios;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
