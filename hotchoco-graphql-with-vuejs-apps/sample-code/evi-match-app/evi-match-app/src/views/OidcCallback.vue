<template>
  <div>
  </div>
</template>

<script>
import { mapActions } from 'vuex'
import gql from 'graphql-tag'

const REGISTER_PLAYER = gql`
   mutation registerPlayer {
     registerPlayer {
        id
        name
        principalId
    }
   }`

export default {
  name: 'OidcCallback',
  methods: {
    ...mapActions([
      'oidcSignInCallback'
    ]),
    async registerPlayer () {
      const loginCredentials = window.localStorage.getItem('oidc.user:https://login.microsoftonline.com/f927e0d2-5ac9-4d98-b514-df7b4d776ac3/v2.0:4be6421c-bdfd-4a53-8962-af56d4c3fd96')
      const token = JSON.parse(loginCredentials).access_token
      if (token) {
        this.$apollo.mutate({
          mutation: REGISTER_PLAYER
        })
      }
    }
  },
  mounted () {
    this.oidcSignInCallback()
      .then(async (redirectPath) => {
        await this.registerPlayer()
        this.$router.push(redirectPath)
      })
      .catch((err) => {
        console.error(err)
        // this.$router.push('/oidc-callback-error') // Handle errors any way you want
      })
  }
}
</script>
