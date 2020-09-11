import gql from 'graphql-tag'

export const QUEUE_FOR_GAME = gql`
  mutation queueForGame($gameID: Uuid!) {
    queueForGame(gameID: $gameID) 
  }
`
