using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.GraphQL.Mutations;
using WebApi.GraphQL.Queries;
using WebApi.GraphQL.Types.Note;

namespace WebApi.GraphQL
{
    public static class ServiceExtensions
    {
        public static void AddGraphQLServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<MyNoteQuery>();
            services.AddScoped<MyNoteMutation>();
            services.AddScoped<NoteType>();
            services.AddScoped<NoteInputType>();
            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddScoped<ISchema, MyNoteSchema>();
        }
    }
}
