<template>
    <v-container fluid>
        <v-row>
            <v-col cols="12" sm="8">
                <div v-if="error">{{ error }}</div>
                <v-card
                    class="mx-auto"
                    max-width="1500"
                    tile
                >
                    <v-list dense>
                    <v-subheader>Matched Games</v-subheader>
                    <v-list-item-group v-if="matchesForPlayer && matchesForPlayer.length > 0"
                        color="primary">
                        <v-list-item
                            v-for="(match, i) in matchesForPlayer"
                            :key="i"
                            >
                            <v-list-item-content>
                                <v-list-item-title>{{ match.game.name }}</v-list-item-title>
                                <v-list-item-subtitle class="player-names">
                                  {{ match.players.flatMap(x => x.player.name).join(' - ') }}
                                </v-list-item-subtitle>
                            </v-list-item-content>
                            <v-btn color="primary" dark @click="finishGame(match.id)">
                                finished
                            </v-btn>
                        </v-list-item>
                    </v-list-item-group>
                    </v-list>
                </v-card>

                 <v-card
                    class="mx-auto"
                    max-width="1500"
                    tile
                >
                    <v-list dense>
                    <v-subheader>Queued Games</v-subheader>
                    <v-list-item-group v-if="queuedGamesForPlayer && queuedGamesForPlayer.length > 0"
                        color="primary">
                        <v-list-item
                            v-for="(item, i) in queuedGamesForPlayer"
                            :key="i"
                            >
                            <v-list-item-content>
                                <v-list-item-title v-text="item.game.name" style="font-size: 16px"></v-list-item-title>
                                <v-list-item-subtitle>{{ item.game.playerCount - item.game.queuedPlayers.length }} needed</v-list-item-subtitle>
                                <v-btn @click.prevent="stopQueueing(item.game.id)">
                                  Cancel
                                </v-btn>
                            </v-list-item-content>
                        </v-list-item>
                    </v-list-item-group>
                    </v-list>
                </v-card>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="10" justify="end" align="end">
                <v-btn color="primary" dark @click.prevent="goToQueueGamePage()">
                    Queue new games
                </v-btn>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import gql from 'graphql-tag'
import { GET_QUEUED_GAMES } from '../queries/queuedGames'
import { GET_MATCHED_GAMES } from '../queries/matchedGames'
import { FINISH_GAME } from '../mutations/finishGame'

const STOP_QUEUEING_FOR_GAME = gql`
   mutation stopQueueingForGame($gameID: Uuid!) {
    stopQueueingForGame(gameID: $gameID) 
   }
 `

export default {
  name: 'MyGames',
  data () {
    return {
      matchesForPlayer: null,
      error: null
    }
  },
  methods: {
    goToQueueGamePage () {
      this.$router.push({ name: 'games' })
    },
    finishGame (matchId) {
      // remove player from queue
      this.$apollo.mutate({
        mutation: FINISH_GAME,
        variables: {
          matchId: matchId
        },
        update: () => {
          this.$apollo.queries.matchesForPlayer.refetch()
        }
      })
    },
    stopQueueing (gameID) {
      // remove player from queue
      this.$apollo.mutate({
        mutation: STOP_QUEUEING_FOR_GAME,
        variables: {
          gameID: gameID
        },
        update: () => {
          this.$apollo.queries.queuedGamesForPlayer.refetch()
        }
      })
    }
  },
  apollo: {
    matchesForPlayer: {
      query: GET_MATCHED_GAMES,
      update: data => data.me && data.me.inMatches.flatMap(x => x.match).filter(x => x.matchStatus === 'INPROGRESS'),
      pollInterval: 5000,
      error (error) {
        console.error('error', error.graphQLErrors)
        this.error = JSON.stringify(error.message)
      }
    },
    queuedGamesForPlayer: {
      query: GET_QUEUED_GAMES,
      update: data => data.me.inQueueForGames,
      pollInterval: 5000,
      error (error) {
        console.error('error', error.graphQLErrors)
        this.error = JSON.stringify(error.message)
      }
    }
  }
}
</script>

<style scoped>
.player-names {
  white-space: normal;
}
</style>
