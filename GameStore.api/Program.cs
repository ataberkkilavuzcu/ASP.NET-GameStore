using GameStore.api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDtos> games = [
    new (1, "Super Mario Bros", "Platformer", 59.99m, new DateOnly(1985, 9, 13)),
    new (2, "The Legend of Zelda", "Action-adventure", 59.99m, new DateOnly(1986, 2, 21)),
    new (3, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18)),
    new (4, "Among Us", "Social deduction", 4.99m, new DateOnly(2018, 6, 15)),
    new (5, "Cyberpunk 2077", "Action role-playing", 59.99m, new DateOnly(2020, 12, 10))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) => {

    GameDtos game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );    

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

// PUT /games
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) => {

    var index = games.FindIndex(game => game.Id == id);

    games[index] = new GameDtos(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

// DELETE /games/{id}
app.MapDelete("/games/{id}", (int id) => {

    var index = games.FindIndex(game => game.Id == id);

    games.RemoveAt(index);
    return Results.NoContent();
});

app.Run();
