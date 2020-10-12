using Core.Interfaces;
using GraphQL.Types;
using Services.Interfaces;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL.Queries
{
    public class MyNoteQuery : ObjectGraphType
    {
        public MyNoteQuery(INoteService noteService, IAuthenticatedUserService authenticatedUserService)
        {
            Field<ListGraphType<NoteType>>(
                "my_all_notes",
                resolve: context => noteService.GetAllMyNotes(authenticatedUserService.UserEmail));

            Field<NoteType>(
                "note_by_id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    int noteId = context.GetArgument<int>("id");
                    return noteService.GetNoteById(noteId);
                });
        }
    }
}
