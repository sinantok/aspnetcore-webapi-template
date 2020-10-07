using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
