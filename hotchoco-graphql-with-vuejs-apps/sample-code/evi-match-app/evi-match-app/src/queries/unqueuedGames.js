import gql from 'graphql-tag'

export const GET_UNQUEUED_GAMES = gql`
    query unqueuedGames($queuedGames: [Uuid!]) {
      games(where: {
        id_not_in: $queuedGames
        isOffered: true
      }) {
        id
        name
        playerCount
        queuedPlayers {
           player {
             name
           }
        }
      }
    }`
