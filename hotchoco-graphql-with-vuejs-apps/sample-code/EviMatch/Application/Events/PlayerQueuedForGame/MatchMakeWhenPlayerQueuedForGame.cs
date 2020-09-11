using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Events.PlayerQueuedForGame
{
    public class MatchMakeWhenPlayerQueuedForGame : INotificationHandler<PlayerQueuedForGameEvent>
    {
        private readonly MatchContext matchContext;
        private readonly IMediator mediator;

        public MatchMakeWhenPlayerQueuedForGame(MatchContext matchContext, IMediator mediator)
        {
            this.matchContext = matchContext;
            this.mediator = mediator;
        }

        public async Task Handle(PlayerQueuedForGameEvent notification, CancellationToken cancellationToken)
        {
            var result = notification.GamePlayer.Game.MatchMake();
            await matchContext.SaveChangesAsync();
            if (result.IsSucceeded)
            {
                await mediator.Publish(new PlayerMatchedEvent(result.Data));
            }
        }
    }
}
