using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Persistence;
using System.Linq;

namespace EviMatch.Types
{
    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("games")
                .Type<ListType<GameType>>()
                .UseFiltering()
                .Resolver((context) =>
                {
                    return context.Service<MatchContext>().Games;
                }).Authorize();

            descriptor.Field("me")
                .Type<PlayerType>()
                .Resolver((context) =>
                {
                    var user = context.Service<IHttpContextAccessor>().HttpContext.User;
                    var sub = user.FindFirst("sub")?.Value;
                    return context.Service<MatchContext>().Players.First(x => x.PrincipalId == sub);
                }).Authorize();
        }
    }
}
