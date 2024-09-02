using System;
using GameStore.api.Data;
using GameStore.api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (GameStoreContext dbContext) =>
        
            await dbContext.Genres.Select(genre => genre.ToDto())
                .AsNoTracking()
                .ToListAsync());

            return group;
        }

}



