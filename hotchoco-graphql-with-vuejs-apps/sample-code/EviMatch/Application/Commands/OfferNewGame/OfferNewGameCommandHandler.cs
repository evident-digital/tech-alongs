using Application.Dtos;
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.OfferNewGame
{
    public class OfferNewGameCommandHandler : IRequestHandler<OfferNewGameCommand, GameDto>
    {
        private readonly MatchContext matchContext;

        public OfferNewGameCommandHandler(MatchContext matchContext)
        {
            this.matchContext = matchContext;
        }

        public async Task<GameDto> Handle(OfferNewGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(name: request.Name, playerCount: request.PlayerCount);

            this.matchContext.Add(game);
            await this.matchContext.SaveChangesAsync();

            return new GameDto(id: game.Id, name: game.Name);
        }
    }
}
