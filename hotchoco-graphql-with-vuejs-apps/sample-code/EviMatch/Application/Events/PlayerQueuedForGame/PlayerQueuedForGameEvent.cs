using Domain;
using MediatR;

namespace Application.Events.PlayerQueuedForGame
{
    public class PlayerQueuedForGameEvent : INotification
    {
        public PlayerQueuedForGameEvent(GamePlayer gamePlayer)
        {
            this.GamePlayer = gamePlayer;
        }

        public GamePlayer GamePlayer { get; }
    }
}
