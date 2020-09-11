using System.Collections.Generic;

namespace Domain
{
    public class Player : Entity
    {
        private string principalId;
        private string name;
        private readonly List<GamePlayer> _inQueueForGames = null!;
        private readonly List<MatchPlayer> _inMatches = null!;

        public Player(string principalId, string name)
        {
            if (string.IsNullOrWhiteSpace(principalId))
            {
                throw new System.ArgumentException("Principal can't be empty", nameof(principalId));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Name can't be empty", nameof(name));
            }

            this.principalId = principalId;
            this.name = name;
        }

        public string Name { get => name; private set => name = value; }
        public string PrincipalId { get => principalId; set => principalId = value; }
        public virtual IReadOnlyList<GamePlayer> InQueueForGames => this._inQueueForGames;
        public virtual IReadOnlyList<MatchPlayer> InMatches => this._inMatches;
    }
}
