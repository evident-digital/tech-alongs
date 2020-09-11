using System;

namespace Application.Dtos
{
    public class MatchDto
    {
        public MatchDto(Guid id, string matchStatus)
        {
            this.Id = id;
            this.MatchStatus = matchStatus;
        }

        public Guid Id { get; }
        public string MatchStatus { get; }
    }
}
