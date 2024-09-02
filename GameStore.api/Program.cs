using GameStore.api.Data;
using GameStore.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

//An API endpoint is a digital location where an API receives requests about a specific resource on its server
app.MapGamesEndpoints();
app.MapGenresEndpoints();

await app.MigrateDBAsync();

app.Run();
