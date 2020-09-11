using Domain.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Game : Entity
    {
        private string _name;
        private int _playerCount;
        private bool _isOffered;
        private readonly List<GamePlayer> _queuedPlayers;
        private readonly List<Match> _matches;

        public Game(string name, int playerCount)
        {
            this._name = name;
            this._playerCount = playerCount;
            this._queuedPlayers = new List<GamePlayer>();
            this._matches = new List<Match>();
            this._isOffered = true;
        }

        public string Name { get => _name; private set => _name = value; }
        public int PlayerCount { get => _playerCount; private set => _playerCount = value; }
        public bool IsOffered { get => _isOffered; private set => _isOffered = value; }
        public virtual IReadOnlyList<GamePlayer> QueuedPlayers => this._queuedPlayers;
        public virtual IReadOnlyList<Match> Matches => this._matches;

        public Result<GamePlayer> Queue(Player player)
        {
            if (this.QueuedPlayers.Select(x => x.Player).Contains(player))
            {
                return Result<GamePlayer>.Failure("Player is already in queue for this game");
            }

            var gamePlayer = new GamePlayer(this, player, DateTime.UtcNow);

            this._queuedPlayers.Add(gamePlayer);
            return Result<GamePlayer>.Success(gamePlayer);
        }

        public Result StopQueueing(Player player)
        {
            var gamePlayer = this.QueuedPlayers.FirstOrDefault(x => x.Player == player);
            if (gamePlayer == null)
            {
                return new Result(false, "The player was not found in the queue");
            }
            this._queuedPlayers.Remove(gamePlayer);
            return new Result(true);
        }

        public Result StopOffering()
        {
            if (!this.IsOffered)
            {
                return new Result(false, "This game is not in the offering");
            }

            if (this.QueuedPlayers.Count > 0)
            {
                return new Result(false, "Can't stop offering because players are still in queue");
            }

            this._isOffered = false;
            return new Result(true);
        }

        public Result<Match> MatchMake()
        {
            if (this.QueuedPlayers.Count >= this._playerCount)
            {
                var matchedPlayers = this.QueuedPlayers.Take(this._playerCount).Select(x => x.Player).ToList();
                var match = new Match(matchedPlayers);
                this._matches.Add(match);
                this._queuedPlayers.RemoveRange(0, matchedPlayers.Count);
                return Result<Match>.Success(match);
            }

            return Result<Match>.Failure("Not enough players in queue");
        }
    }
}
