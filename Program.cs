using BikeComp.API.DbContexts;
using BikeComp.API.Services;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvcCore(options =>
{
    options.ReturnHttpNotAcceptable = true;
    
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<IBikeCompRepository, BikeCompRepository>();
builder.Services.AddDbContext<BikeCompContext>(options =>
{
<<<<<<< HEAD
    options.UseSqlServer(@"data source=DESKTOP-8UDDTCQ\SQLEXPRESS22;initial catalog=BikeComp;trusted_connection=true; TrustServerCertificate=true;");

=======
    options.UseSqlServer(
        @"data source=DESKTOP-8UDDTCQ\SQLEXPRESS22;initial catalog=BikeComp;trusted_connection=true; TrustServerCertificate=true;");
        ;
>>>>>>> Controllers
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

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();