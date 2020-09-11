using Application.Dtos;
using MediatR;

namespace Application.Commands.RegisterPlayer
{
    public class RegisterPlayerCommand : IRequest<PlayerDto>
    {
        public RegisterPlayerCommand(string principalID, string name)
        {
            this.PrincipalID = principalID;
            this.Name = name;
        }

        public string PrincipalID { get; }
        public string Name { get; }
    }
}
