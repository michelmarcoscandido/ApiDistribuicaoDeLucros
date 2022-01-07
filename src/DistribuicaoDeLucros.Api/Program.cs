using Serilog;
using DistribuicaoDeLucros.Services;
using DistribuicaoDeLucros.Infra;
using DistribuicaoDeLucros.Infra.Context;
using System.Reflection;
using DistribuicaoDeLucros.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
     c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Distribuição de Lucros",
                        Version = "v1",
                        Description = "Api Rest"
                    });

                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                .Union(new AssemblyName[] { currentAssembly.GetName() })
                .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                .Where(f => File.Exists(f)).ToArray();

                Array.ForEach(xmlDocs, (d) => {
                    c.IncludeXmlComments(d);
                });
});

builder.Services.LoadServiceDependencyLoader();
builder.Services.LoadInfraDependencyLoader();
builder.Services.LoadApplicationDependencyLoader();
builder.Services.BuildServiceProvider().GetService<SqlContext>().Initialize();

var app = builder.Build();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
