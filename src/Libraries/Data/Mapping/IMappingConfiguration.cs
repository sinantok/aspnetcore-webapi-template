using Microsoft.EntityFrameworkCore;

namespace Data.Mapping
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
