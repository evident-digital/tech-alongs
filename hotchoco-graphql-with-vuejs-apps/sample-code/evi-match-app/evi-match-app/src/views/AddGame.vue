<template>
  <div>
    <h1>Add game</h1>
    <v-form>
      <v-row>
        <v-col>
          <v-text-field label="Game name" v-model="name" />
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-text-field label="Amount of players" v-model="amountOfPlayers" />
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn @click="addGame">Submit</v-btn>
        </v-col>
      </v-row>
    </v-form>
  </div>
</template>

<script>
import { ADD_GAME } from '../mutations/addGame'

export default {
  name: 'AddGame',
  data () {
    return {
      name: '',
      amountOfPlayers: 0
    }
  },
  methods: {
    addGame () {
      this.$apollo.mutate({
        mutation: ADD_GAME,
        variables: {
          name: this.name,
          amountOfPlayers: Number(this.amountOfPlayers)
        }
      }).then((result) => {
        this.$router.push({ name: 'games' })
      })
    }
  }
}
</script>
