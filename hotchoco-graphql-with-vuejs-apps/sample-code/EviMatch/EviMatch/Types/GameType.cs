using Domain;
using HotChocolate.Types;

namespace EviMatch.Types
{
    public class GameType : ObjectType<Game>
    {
        protected override void Configure(IObjectTypeDescriptor<Game> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(g => g.Id);
            descriptor.Field(g => g.IsOffered);
            descriptor.Field(g => g.Matches).UseFiltering().Type<ListType<MatchType>>();
            descriptor.Field(g => g.QueuedPlayers).UseFiltering().Type<ListType<GamePlayerType>>();
            descriptor.Field(g => g.Name);
            descriptor.Field(g => g.PlayerCount);
        }
    }
}
