namespace CodingSolutions.API.Mappings;

public static class GenericMappings
{
    public static TEntity ToEntity<TDto, TEntity>(this TDto dto)
        where TDto : class, TEntity
        where TEntity : class
    {
        return dto;
    }

    public static TDto ToDTO<TDto, TEntity>(this TEntity entity)
        where TDto : class, TEntity
        where TEntity : class
    {
        return entity as TDto;
    }
}