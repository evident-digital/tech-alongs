using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.StopQueueingForGame
{
    public class FinishMatchCommandHandler : IRequestHandler<FinishMatchCommand>
    {
        private readonly MatchContext matchContext;

        public FinishMatchCommandHandler(MatchContext matchContext)
        {
            this.matchContext = matchContext;
        }

        public async Task<Unit> Handle(FinishMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await this.matchContext.Matches.FirstOrDefaultAsync(x => x.Id == request.MatchID);
            if (match == null)
            {
                throw new Exception("No match was found");
            }

            var result = match.Finish(request.PrincipalID);

            if (!result.IsSucceeded)
            {
                throw new Exception(result.Error);
            }
            await this.matchContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
