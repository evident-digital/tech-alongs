import gql from 'graphql-tag'

export const ADD_GAME = gql`
    mutation addGame($amountOfPlayers: Int!, $name: String) {
      offerNewGame(playerCount: $amountOfPlayers, name: $name) {
        id
      }
    }`
