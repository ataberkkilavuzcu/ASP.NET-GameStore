using System;
using GameStore.api.Dtos;
using GameStore.api.Entities;

namespace GameStore.api.Mapping;

public static class GameMapping
{
    public static Game toEntity(this CreateGameDto dto)
    {
        return new Game
        {
            Name = dto.Name,
            GenreId = dto.GenreId,
            Price = dto.Price,
            ReleaseDate = dto.ReleaseDate
        };
    }

    public static Game toEntity(this UpdateGameDto dto, int id)
    {
        return new Game
        {
            Id = id,
            Name = dto.Name,
            GenreId = dto.GenreId,
            Price = dto.Price,
            ReleaseDate = dto.ReleaseDate
        };
    }

    public static GameSummaryDto toGameSummaryDto(this Game game)
    {
        return new 
        (
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }
    public static GameDetailsDto toGameDetailsDto(this Game game)
    {
        return new 
        (
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }
}
