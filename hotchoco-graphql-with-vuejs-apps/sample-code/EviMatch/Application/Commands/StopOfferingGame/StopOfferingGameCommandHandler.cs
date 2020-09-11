using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.StopOfferingGame
{
    public class OfferNewGameCommandHandler : IRequestHandler<StopOfferingGameCommand>
    {
        private readonly MatchContext matchContext;

        public OfferNewGameCommandHandler(MatchContext matchContext)
        {
            this.matchContext = matchContext;
        }

        public async Task<Unit> Handle(StopOfferingGameCommand request, CancellationToken cancellationToken)
        {
            var game = await this.matchContext.Games.FirstOrDefaultAsync(x => x.Id == request.GameID);
            if (game == null)
            {
                throw new Exception("No game was found");
            }
            var result = game.StopOffering();
            await this.matchContext.SaveChangesAsync();
            if (!result.IsSucceeded)
            {
                throw new Exception(result.Error);
            }
            return Unit.Value;
        }
    }
}
