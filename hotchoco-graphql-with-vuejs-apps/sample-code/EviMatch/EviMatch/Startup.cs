using Application.Commands.RegisterPlayer;
using EviMatch.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using HotChocolate.Execution.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.IdentityModel.Tokens.Jwt;
using Domain;

namespace EviMatch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string AzureADScheme = "AzureAD";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddAuthorization();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Audience = Configuration.GetValue<string>("Authentication:AzureAD:Audience");
                    options.Authority = "https://login.microsoftonline.com/f927e0d2-5ac9-4d98-b514-df7b4d776ac3/v2.0";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidIssuer = "https://sts.windows.net/f927e0d2-5ac9-4d98-b514-df7b4d776ac3/",
                        ValidateAudience = false,
                        RoleClaimType = "roles"
                    };
                });

            services.AddCors();
            services.AddMediatR(typeof(RegisterPlayerCommandHandler).Assembly);

            services.AddInMemorySubscriptionProvider();
            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddAuthorizeDirectiveType()
                    .AddQueryType<QueryType>()
                    .AddMutationType<MutationType>()
                    .Create(),
                new QueryExecutionOptions { IncludeExceptionDetails = true, ForceSerialExecution = true });

            services.AddDbContext<MatchContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlServer(Configuration.GetConnectionString("EviMatchDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            MigrateDatabase(app);

            app.UseCors(options =>
                options.SetIsOriginAllowed(x => _ = true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials())
                .UseAuthorization()
                .UseAuthentication()
                .UseWebSockets()
                .UseGraphQL()
                .UsePlayground();
        }

        private static void MigrateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<MatchContext>();
            context.Database.Migrate();
        }
    }
}
