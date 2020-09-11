using System;

namespace Domain
{
    public class GamePlayer
    {
        public GamePlayer(Game game, Player player, DateTime QueuedFrom)
        {
            this.Game = game;
            this.Player = player;
            this.QueuedFrom = QueuedFrom;
        }

        /// <remarks>
        /// EntityFrameWork constructor.
        /// </remarks>
        protected GamePlayer()
        {
        }

        public Guid GameId { get; private set; }
        public virtual Game Game { get; set; } = null!;
        public Guid PlayerId { get; private set; }
        public virtual Player Player { get; set; } = null!;
        public DateTime QueuedFrom { get; }
    }
}
