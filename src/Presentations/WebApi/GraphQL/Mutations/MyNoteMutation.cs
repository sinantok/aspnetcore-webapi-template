using GraphQL.Types;
using Models.DbEntities;
using Services.Interfaces;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL.Mutations
{
    public class MyNoteMutation : ObjectGraphType
    {
        public MyNoteMutation(INoteService _noteService)
        {
            Field<NoteType>(
                "addNote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<NoteInputType>> { Name = "note" }),
                resolve: context =>
                {
                    Note note = context.GetArgument<Note>("note");
                    return _noteService.InsertNote(note);
                });
        }
    }
}
