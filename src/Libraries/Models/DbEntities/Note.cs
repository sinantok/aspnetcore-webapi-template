using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DbEntities
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}
