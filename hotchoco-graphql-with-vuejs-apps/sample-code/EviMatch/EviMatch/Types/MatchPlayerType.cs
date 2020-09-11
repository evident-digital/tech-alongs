using Domain;
using HotChocolate.Types;

namespace EviMatch.Types
{
    public class MatchPlayerType : ObjectType<MatchPlayer>
    {
        protected override void Configure(IObjectTypeDescriptor<MatchPlayer> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(g => g.Match).Type<MatchType>();
            descriptor.Field(g => g.Player).Type<PlayerType>();
        }
    }
}