using Domain;
using HotChocolate.Types;

namespace EviMatch.Types
{
    public class PlayerType : ObjectType<Player>
    {
        protected override void Configure(IObjectTypeDescriptor<Player> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(g => g.Id);
            descriptor.Field(g => g.Name);
            descriptor.Field(g => g.PrincipalId);
            descriptor.Field(g => g.InQueueForGames).UseFiltering().Type<ListType<GamePlayerType>>(); ;
            descriptor.Field(g => g.InMatches).UseFiltering().Type<ListType<MatchPlayerType>>(); ;
        }
    }
}
