using Application.Dtos;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.RegisterPlayer
{
    public class RegisterPlayerCommandHandler : IRequestHandler<RegisterPlayerCommand, PlayerDto>
    {
        private readonly MatchContext matchContext;

        public RegisterPlayerCommandHandler(MatchContext matchContext)
        {
            this.matchContext = matchContext;
        }

        public async Task<PlayerDto> Handle(RegisterPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = matchContext.Players.FirstOrDefault(x => x.PrincipalId == request.PrincipalID);
            if (player != null)
            {
                return CreateDto(player);
            }

            var newPlayer = new Player(request.PrincipalID, request.Name);
            matchContext.Players.Add(newPlayer);
            await matchContext.SaveChangesAsync();
            return CreateDto(newPlayer);
        }

        private PlayerDto CreateDto(Player player)
        {
            return new PlayerDto(id: player.Id, principalId: player.PrincipalId, name: player.Name);
        }
    }
}
