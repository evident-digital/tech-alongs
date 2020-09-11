using System;

namespace Application.Dtos
{
    public class PlayerDto
    {
        public PlayerDto(Guid id, string principalId, string name)
        {
            this.Id = id;
            this.PrincipalId = principalId;
            this.Name = name;
        }

        public Guid Id { get; }
        public string PrincipalId { get; }
        public string Name { get; }
    }
}