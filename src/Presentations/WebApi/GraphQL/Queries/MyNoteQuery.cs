using GraphQL.Types;
using Services.Interfaces;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL.Queries
{
    public class MyNoteQuery : ObjectGraphType
    {
        public MyNoteQuery(INoteService _noteService)
        {
            Field<ListGraphType<NoteType>>(
                "my_all_notes",
                resolve: context => _noteService.GetAllMyNotes());

            Field<NoteType>(
                "note_by_id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    int noteId = context.GetArgument<int>("id");
                    return _noteService.GetNoteById(noteId);
                });
        }
    }
}
