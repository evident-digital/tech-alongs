<template>
    <v-container fluid>
        <v-row align="center" justify="center" style="height: 500px">
            <v-col class="text-center" cols="12" sm="4">
                <div v-if="error">{{ error }}</div>
                <div v-if="unqueuedGames" class="d-flex justify-between flex-column">
                    <div v-for="game in unqueuedGames"
                        :key="`not-queued-games-${game.id}`"
                        class="my-5">
                        <v-btn color="primary" @click.prevent="queueForGame(game.id)">
                            Queue For {{ game.name }}
                        </v-btn>
                        <p>{{ game.playerCount }} player game.</p>
                        <p>{{ game.queuedPlayers && game.queuedPlayers.length }} people queueing.</p>
                    </div>
                </div>
            </v-col>
        </v-row>
        <v-btn
          color="pink"
          dark
          fixed
          bottom
          right
          fab
          :to="{ name: 'addGame' }"
        ><v-icon>mdi-plus</v-icon></v-btn>
    </v-container>
</template>

<script>
import { GET_QUEUED_GAMES } from '../queries/queuedGames'
import { GET_UNQUEUED_GAMES } from '../queries/unqueuedGames'
import { QUEUE_FOR_GAME } from '../mutations/queueForGame'

export default {
  name: 'GameList',
  data () {
    return {
      queuedGames: [],
      unqueuedGames: null,
      error: null
    }
  },
  methods: {
    queueForGame (gameID) {
      this.$apollo.mutate({
        mutation: QUEUE_FOR_GAME,
        variables: {
          gameID: gameID
        }
      }).then((data) => {
        this.$router.push({ name: 'MyGames' })
      }).catch((error) => {
        console.error(error)
        this.error = JSON.stringify(error.message)
      })
    }
  },
  apollo: {
    apolloQueuedGames: {
      query: GET_QUEUED_GAMES,
      error (error) {
        console.error('error', error.graphQLErrors)
        this.error = JSON.stringify(error.message)
      },
      update (data) {
        this.queuedGames = data.me.inQueueForGames.flatMap(x => x.game)
      }
    },
    apolloUnqueuedGames: {
      query: GET_UNQUEUED_GAMES,
      update (data) {
        this.unqueuedGames = data.games
      },
      variables () {
        return {
          queuedGames: this.queuedGames.map(x => x.id)
        }
      },
      pollInterval: 5000,
      skip () {
        return !this.queuedGames
      },
      error (error) {
        console.error('error', error.graphQLErrors)
        this.error = JSON.stringify(error.message)
      }
    }
  }
}
</script>
