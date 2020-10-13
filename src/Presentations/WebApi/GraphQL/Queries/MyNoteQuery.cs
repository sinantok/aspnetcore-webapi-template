using Core.Interfaces;
using GraphQL.Types;
using Services.Interfaces;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL.Queries
{
    public class MyNoteQuery : ObjectGraphType
    {
        public MyNoteQuery(INoteService noteService)
        {
            Field<ListGraphType<NoteType>>(
                "my_all_notes",
                resolve: context => noteService.GetAllMyNotes());

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
