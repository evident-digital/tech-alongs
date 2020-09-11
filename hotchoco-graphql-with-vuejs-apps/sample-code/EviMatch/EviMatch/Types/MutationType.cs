using Application.Commands.OfferNewGame;
using Application.Commands.QueueForGame;
using Application.Commands.RegisterPlayer;
using Application.Commands.StopOfferingGame;
using Application.Commands.StopQueueingForGame;
using Application.Dtos;
using HotChocolate.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace EviMatch.Types
{
    [Authorize]
    public class MutationType
    {
        private readonly IMediator mediator;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MutationType(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<PlayerDto> RegisterPlayer()
        {
            var user = httpContextAccessor.HttpContext.User;
            var sub = user.FindFirst("sub")?.Value;
            var name = user.FindFirst("name")?.Value;
            return await mediator.Send(new RegisterPlayerCommand(principalID: sub, name: name));
        }

        public async Task<GameDto> OfferNewGame(string name, int playerCount)
        {
            return await mediator.Send(new OfferNewGameCommand(name: name, playerCount: playerCount));
        }

        public async Task<bool> StopOfferingGame(Guid gameID)
        {
            await mediator.Send(new StopOfferingGameCommand(gameID));
            return true;
        }

        public async Task<bool> QueueForGame(Guid gameID)
        {
            var user = httpContextAccessor.HttpContext.User;
            var sub = user.FindFirst("sub")?.Value;
            await mediator.Send(new QueueForGameCommand(gameID: gameID, principalID: sub));
            return true;
        }

        public async Task<bool> StopQueueingForGame(Guid gameID)
        {
            var user = httpContextAccessor.HttpContext.User;
            var sub = user.FindFirst("sub")?.Value;
            await mediator.Send(new StopQueueingForGameCommand(gameID: gameID, principalID: sub));
            return true;
        }

        public async Task<bool> FinishGame(Guid matchId)
        {
            var user = httpContextAccessor.HttpContext.User;
            var sub = user.FindFirst("sub")?.Value;
            await mediator.Send(new FinishMatchCommand(matchId: matchId, principalID: sub));
            return true;
        }
    }
}
