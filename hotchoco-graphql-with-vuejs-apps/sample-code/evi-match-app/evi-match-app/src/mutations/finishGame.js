import gql from 'graphql-tag'

export const FINISH_GAME = gql`
  mutation finishGame($matchId: Uuid!) {
    finishGame(matchId: $matchId)
  }
  `
