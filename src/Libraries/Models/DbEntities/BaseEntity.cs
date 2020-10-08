using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DbEntities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateUTC { get; set; }
    }
}
