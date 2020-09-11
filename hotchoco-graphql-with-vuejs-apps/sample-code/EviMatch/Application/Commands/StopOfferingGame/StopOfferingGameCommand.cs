using MediatR;
using System;

namespace Application.Commands.StopOfferingGame
{
    public class StopOfferingGameCommand : IRequest
    {
        public StopOfferingGameCommand(Guid gameID)
        {
            this.GameID = gameID;
        }

        public Guid GameID { get; }
    }
}
