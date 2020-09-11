import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'

import VueApollo from 'vue-apollo'
import ApolloClient from 'apollo-client'
import { HttpLink } from 'apollo-link-http'
import { InMemoryCache } from 'apollo-cache-inmemory'

Vue.use(VueApollo)

Vue.config.productionTip = false

const getHeaders = () => {
  const headers = {}
  const loginCredentials = window.localStorage.getItem('oidc.user:https://login.microsoftonline.com/f927e0d2-5ac9-4d98-b514-df7b4d776ac3/v2.0:4be6421c-bdfd-4a53-8962-af56d4c3fd96')
  if (loginCredentials) {
    const token = JSON.parse(loginCredentials).access_token
    if (token) {
      headers.authorization = `Bearer ${token}`
    }
  }

  return headers
}
// Create an http link:
const link = new HttpLink({
  uri: 'http://localhost:5000',
  fetch,
  headers: getHeaders()
})
const client = new ApolloClient({
  link: link,
  cache: new InMemoryCache({
    addTypename: true
  })
})

const apolloProvider = new VueApollo({
  defaultClient: client,
  defaultOptions: {
    $query: {
      fetchPolicy: 'no-cache'
    }
  }
})

new Vue({
  router,
  store,
  apolloProvider,
  vuetify,
  render: h => h(App)
}).$mount('#app')
