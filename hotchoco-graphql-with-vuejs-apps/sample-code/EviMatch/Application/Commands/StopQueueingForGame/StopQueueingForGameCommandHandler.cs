using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.StopQueueingForGame
{
    public class StopQueueingForGameCommandHandler : IRequestHandler<StopQueueingForGameCommand>
    {
        private readonly MatchContext matchContext;

        public StopQueueingForGameCommandHandler(MatchContext matchContext)
        {
            this.matchContext = matchContext;
        }

        public async Task<Unit> Handle(StopQueueingForGameCommand request, CancellationToken cancellationToken)
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
            var result = game.StopQueueing(player);
            await this.matchContext.SaveChangesAsync();
            if (!result.IsSucceeded)
            {
                throw new Exception(result.Error);
            }
            return Unit.Value;
        }
    }
}
