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
                name: "createNote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<NoteInputType>> { Name = "note" }),
                resolve: context =>
                {
                    Note note = context.GetArgument<Note>("note");
                    note.OwnerEmail = authenticatedUserService.UserEmail;
                    return noteService.InsertNote(note);
                });

            Field<StringGraphType>(
                name: "deleteNote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    int id = context.GetArgument<int>("id");
                    bool res = noteService.DeleteNote(id);
                    if (res)
                        return "Note deleted";
                    return "Try to delete again";
                });
        }
    }
}
