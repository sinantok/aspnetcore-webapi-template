using System;

namespace Models.DbEntities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateUTC { get; set; }
    }
}
