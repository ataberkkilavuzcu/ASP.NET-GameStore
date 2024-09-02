using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data;

public static class DataExtensions
{
    public static async Task MigrateDBAsync(this WebApplication web){
        using var scope = web.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

}
