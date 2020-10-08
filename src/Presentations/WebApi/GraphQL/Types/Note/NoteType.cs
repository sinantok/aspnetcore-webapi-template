using GraphQL.Types;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.GraphQL.Types.Note
{
    public class NoteType : ObjectGraphType<Models.DbEntities.Note>
    {
        public NoteType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Category);
            Field(x => x.Description);
        }
    }
}
