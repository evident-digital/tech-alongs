using Application.Events.PlayerQueuedForGame;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.QueueForGame
{
    public class QueueForGameHandler : IRequestHandler<QueueForGameCommand>
    {
        private readonly MatchContext matchContext;
        private readonly IMediator mediator;

        public QueueForGameHandler(MatchContext matchContext, IMediator mediator)
        {
            this.matchContext = matchContext;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(QueueForGameCommand request, CancellationToken cancellationToken)
        {
            var game = await this.matchContext.Games.FirstOrDefaultAsync(x => x.Id == request.GameID);
            if (game == null)
            {
                throw new Exception("No game was found");
            }

            var player = await this.matchContext.Players.FirstOrDefaultAsync(x => x.PrincipalId == request.PrincipalID);
            if (player == null)
            {
                throw new Exception("No player was found");
            }
            var result = game.Queue(player);

            if (!result.IsSucceeded)
            {
                throw new Exception(result.Error);
            }

            await this.matchContext.SaveChangesAsync();

            if (result.IsSucceeded)
            {
                await mediator.Publish(new PlayerQueuedForGameEvent(result.Data));
            }
            return Unit.Value;
        }
    }
}
