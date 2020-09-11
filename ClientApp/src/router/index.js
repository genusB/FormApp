import Vue from 'vue'
import Router from 'vue-router'
import Form from '@/components/Form'
import Search from '@/components/Search'

Vue.use(Router)

export default new Router({
  routes: [
    {
        path: '/',
        name: 'Form',
        component: Form
    },
    {
        path: '/search',
        name: 'Search',
        component: Search
    }
  ]
})