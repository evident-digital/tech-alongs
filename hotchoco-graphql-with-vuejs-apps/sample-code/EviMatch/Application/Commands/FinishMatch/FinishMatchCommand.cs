using MediatR;
using System;

namespace Application.Commands.StopQueueingForGame
{
    public class FinishMatchCommand : IRequest
    {
        public FinishMatchCommand(Guid matchId, string principalID)
        {
            this.MatchID = matchId;
            this.PrincipalID = principalID;
        }

        public Guid MatchID { get; }
        public string PrincipalID { get; }
    }
}
