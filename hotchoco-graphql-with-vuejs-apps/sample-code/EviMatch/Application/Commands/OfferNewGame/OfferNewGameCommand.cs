using Application.Dtos;
using MediatR;

namespace Application.Commands.OfferNewGame
{
    public class OfferNewGameCommand : IRequest<GameDto>
    {
        public OfferNewGameCommand(string name, int playerCount)
        {
            this.Name = name;
            this.PlayerCount = playerCount;
        }

        public string Name { get; }
        public int PlayerCount { get; }
    }
}
