import Vue from 'vue'
import VueRouter from 'vue-router'
import OidcCallback from '../views/OidcCallback'
import { vuexOidcCreateRouterMiddleware } from 'vuex-oidc'
import store from '@/store'

Vue.use(VueRouter)

const router = new VueRouter({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'MyGames',
      component: () =>
        import('../views/MyGames.vue')
    },
    {
      path: '/games',
      name: 'games',
      component: () =>
        import('../views/GameList.vue')
    },
    {
      path: '/add-game',
      name: 'addGame',
      component: () =>
        import('../views/AddGame.vue')
    },
    {
      path: '/oidc-signin', // Needs to match redirectUri (redirect_uri if you use snake case) in you oidcSettings
      name: 'oidcCallback',
      component: OidcCallback
    }
  ]
})

router.beforeEach(vuexOidcCreateRouterMiddleware(store))

export default router
