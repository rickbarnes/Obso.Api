using Engine;
using Engine.Board;
using IRepository;
using IRepository.Boards;
using IServices;
using IServices.Board;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Board;
using Services;
using Services.Board;

namespace Obso.Api;

public sealed class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();

        app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

        app.UseSwaggerUI();

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddCors();

        this.ConfigureSwagger(services);

        this.ConfigureDependencyInjection(services);
    }


    private void ConfigureDependencyInjection(IServiceCollection services)
    {
        this.ConfigureTest(services);
        this.ConfigureBoard(services);
    }

    private void ConfigureTest(IServiceCollection services)
    {
        services.AddSingleton<ITestService, TestService>();
        services.AddSingleton<ITestEngine, TestEngine>();
        services.AddSingleton<ITestRepository, TestRepository>();
    }

    private void ConfigureBoard(IServiceCollection services)
    {
        services.AddSingleton<IBoardService, BoardService>();
        services.AddSingleton<IBoardEngine, BoardEngine>();
        services.AddSingleton<IBoardRepository, BoardRepository>();
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Obso API",
                Description = "Obso API",
            });
        });
    }
}