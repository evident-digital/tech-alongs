using MediatR;
using System;

namespace Application.Commands.StopQueueingForGame
{
    public class StopQueueingForGameCommand : IRequest
    {
        public StopQueueingForGameCommand(Guid gameID, string principalID)
        {
            this.GameID = gameID;
            this.PrincipalID = principalID;
        }

        public Guid GameID { get; }
        public string PrincipalID { get; }
    }
}
