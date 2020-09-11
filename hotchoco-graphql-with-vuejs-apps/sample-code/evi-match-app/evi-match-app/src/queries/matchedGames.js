import gql from 'graphql-tag'

export const GET_MATCHED_GAMES = gql`
  query matchesForPlayer {
    me {
      inMatches {
        match {
          id
          matchStatus
          game {
            name
          }
          players {
            player {
              name
            }
          }
        }
      }
    }
  }
`
