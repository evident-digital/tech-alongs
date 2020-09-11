using MediatR;
using System;

namespace Application.Commands.QueueForGame
{
    public class QueueForGameCommand : IRequest
    {
        public QueueForGameCommand(Guid gameID, string principalID)
        {
            this.GameID = gameID;
            this.PrincipalID = principalID;
        }

        public Guid GameID { get; }
        public string PrincipalID { get; }
    }
}
