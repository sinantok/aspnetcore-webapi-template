using Caching;
using GraphQL.Types;
using Services.Interfaces;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL.Queries
{
    public class MyNoteQuery : ObjectGraphType
    {
        public MyNoteQuery(INoteService noteService, ICacheManager cacheManager, IAuthenticatedUserService authenticatedUserService)
        {
            Field<ListGraphType<NoteType>>(
                "my_all_notes",
                resolve: context =>
                {
                    string cacheKey = $"my_all_notes_{authenticatedUserService.UserEmail}";
                    var data = cacheManager.Get(cacheKey, () => { return noteService.GetAllMyNotes(); });
                    return data;
                });

            Field<NoteType>(
                "note_by_id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    int noteId = context.GetArgument<int>("id");
                    return noteService.GetNoteById(noteId);
                });
            Field<ListGraphType<NoteType>>(
                "my_all_notes_by_category",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "category" }),
                resolve: context =>
                {
                    string category = context.GetArgument<string>("category");
                    return noteService.GetNotesByCategory(category);
                });
        }
    }
}
