using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.GraphQL.Types.Note
{
    public class NoteInputType : InputObjectGraphType
    {
        public NoteInputType()
        {
            Field<StringGraphType>("title");
            Field<NonNullGraphType<StringGraphType>>("category");
            Field<NonNullGraphType<StringGraphType>>("description");
        }
    }
}
