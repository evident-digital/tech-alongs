using System;

namespace Domain
{
    public class MatchPlayer
    {
        public MatchPlayer(Match match, Player player)
        {
            this.Match = match;
            this.Player = player;
        }

        /// <remarks>
        /// EntityFrameWork constructor.
        /// </remarks>
        protected MatchPlayer()
        {
        }

        public Guid MatchId { get; private set; }
        public virtual Match Match { get; set; } = null!;
        public Guid PlayerId { get; private set; }
        public virtual Player Player { get; set; } = null!;
    }
}
