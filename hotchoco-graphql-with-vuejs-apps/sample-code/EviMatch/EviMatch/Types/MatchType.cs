using Domain;
using HotChocolate.Types;

namespace EviMatch.Types
{
    public class MatchType : ObjectType<Match>
    {
        protected override void Configure(IObjectTypeDescriptor<Match> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(m => m.Id);
            descriptor.Field(m => m.MatchStatus);
            descriptor.Field(m => m.Players).UseFiltering().Type<ListType<MatchPlayerType>>();
            descriptor.Field(m => m.Game).Type<GameType>();
        }
    }
}
