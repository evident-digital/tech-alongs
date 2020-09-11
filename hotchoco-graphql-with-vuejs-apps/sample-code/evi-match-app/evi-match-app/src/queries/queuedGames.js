import gql from 'graphql-tag'

export const GET_QUEUED_GAMES = gql`
    query queuedGames {
      me {
        inQueueForGames {
            game {
                name
                id
                playerCount
                queuedPlayers {
                  player {
                    name
                  }
                }
            }
        }
    }
  }`
