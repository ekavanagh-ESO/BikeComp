using BikeComp.API.DbContexts;
using BikeComp.API.Services;
using Microsoft.EntityFrameworkCore;
using BikeComp.API.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(BikeProfile).Assembly);
builder.Services.AddMvcCore(options =>
{
    options.ReturnHttpNotAcceptable = true;
    
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<IBikeCompRepository, BikeCompRepository>();
builder.Services.AddDbContext<BikeCompContext>(options =>
{
    options.UseSqlServer(@"data source=DESKTOP-8UDDTCQ\SQLEXPRESS22;initial catalog=BikeComp;trusted_connection=true; TrustServerCertificate=true;");
});

var app = builder.Build();

//!manually add db - not ideal but for learnings its grand -- this will wipe and re enter the the data to ^^ sql each runtime 
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<BikeCompContext>();
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(app =>
        app.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Unexpected error. Try again later.");
        }));
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();