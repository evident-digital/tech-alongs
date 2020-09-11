using Domain.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Match : Entity
    {
        private MatchStatus _matchStatus { get; set; }
        private readonly List<MatchPlayer> _players = null!;
        private readonly Game _game = null!;
        private readonly Guid _gameId;

        public Match(List<Player> players) : this()
        {
            this._players = players.Select(x => new MatchPlayer(this, x)).ToList();
        }

        protected Match()
        {
            // EF constructor
            this._matchStatus = MatchStatus.InProgress;
        }

        public Result Finish(string principalId)
        {
            if (this.Players.Select(x => x.Player).Any(x => x.PrincipalId == principalId))
            {
                this._matchStatus = MatchStatus.Finished;
                return Result.Success();
            }
            return Result.Failure("Player is not part of match");
        }

        public MatchStatus MatchStatus
        {
            get => this._matchStatus;
            private set => this._matchStatus = value;
        }
        public virtual IReadOnlyList<MatchPlayer> Players => this._players;
        public virtual Game Game => this._game;
        public virtual Guid GameId => this._gameId;
    }
}
