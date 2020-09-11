using Domain;
using HotChocolate.Types;

namespace EviMatch.Types
{
    public class GamePlayerType : ObjectType<GamePlayer>
    {
        protected override void Configure(IObjectTypeDescriptor<GamePlayer> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(g => g.Game).Type<GameType>();
            descriptor.Field(g => g.Player).Type<PlayerType>();
        }
    }
}