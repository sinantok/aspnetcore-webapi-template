using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
