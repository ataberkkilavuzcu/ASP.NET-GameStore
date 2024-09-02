using System;
using GameStore.api.Dtos;
using GameStore.api.Entities;

namespace GameStore.api.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre){
        if(genre == null) throw new ArgumentNullException(nameof(genre));
        return new GenreDto(genre.Id, genre.Name);
    }


}
