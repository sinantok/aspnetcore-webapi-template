using GraphQL;
using GraphQL.Types;
using WebApi.GraphQL.Mutations;
using WebApi.GraphQL.Queries;

namespace WebApi.GraphQL
{
    public class MyNoteSchema : Schema
    {
        public MyNoteSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MyNoteQuery>();
            Mutation = resolver.Resolve<MyNoteMutation>();
        }
    }
}
