using Core.Interfaces;
using GraphQL.Types;
using Models.DbEntities;
using Services.Interfaces;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL.Mutations
{
    public class MyNoteMutation : ObjectGraphType
    {
        public MyNoteMutation(INoteService noteService, IAuthenticatedUserService authenticatedUserService)
        {
            Field<NoteType>(
                "addNote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<NoteInputType>> { Name = "note" }),
                resolve: context =>
                {
                    Note note = context.GetArgument<Note>("note");
                    note.OwnerEmail = authenticatedUserService.UserEmail;
                    return noteService.InsertNote(note);
                });
        }
    }
}
