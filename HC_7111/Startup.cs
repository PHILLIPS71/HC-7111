using HotChocolate.AspNetCore;

namespace HC_7111;

public class Startup
{
    private readonly IHostEnvironment _environment;

    public Startup(IConfiguration configuration, IHostEnvironment env)
    {
        _environment = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .ModifyOptions(opt => opt.DefaultFieldBindingFlags = FieldBindingFlags.Default)
            .AddMutationConventions()
            .AddHC_7111Types()
            .AddProjections()
            .AddFiltering()
            .AddSorting();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (!_environment.IsDevelopment())
            app.UseHttpsRedirection();

        app
            .UseRouting()
            .UseWebSockets()
            .UseEndpoints(endpoint =>
                endpoint
                    .MapGraphQL()
                    .WithOptions(new GraphQLServerOptions
                    {
                        Tool = { Enable = _environment.IsDevelopment() }
                    })
            );
    }
}