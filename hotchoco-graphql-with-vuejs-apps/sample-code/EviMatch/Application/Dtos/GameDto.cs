using System;

namespace Application.Dtos
{
    public class GameDto
    {
        public GameDto(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}