using Contract.API;
using Entities;
using Repository;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<PetShopDbContext>(); // DbContext registration in order to inject it to UnitOfWork.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // UnitOfWork registration in order to inject it to controllers.
builder.Services.AddMvc().AddNewtonsoftJson(option => 
option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); //Setting up serialization to avoid an infinite loop.
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();

