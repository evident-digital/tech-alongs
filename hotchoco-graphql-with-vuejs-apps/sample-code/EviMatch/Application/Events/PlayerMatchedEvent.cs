using Domain;
using MediatR;

namespace Application.Events
{
    public class PlayerMatchedEvent : INotification
    {
        public PlayerMatchedEvent(Match match)
        {
            this.Match = match;
        }

        public Match Match { get; }
    }
}
