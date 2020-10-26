using Core.Exceptions;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApi.GraphQL;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        //[Cached(300)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new Exception(nameof(query));
            }
            try
            {
                var inputs = query.Variables.ToInputs();
                var executionOptions = new ExecutionOptions
                {
                    Schema = _schema,
                    Query = query.Query,
                    Inputs = inputs
                };
                var result = await _documentExecuter
                    .ExecuteAsync(executionOptions);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }
                return Ok(new BaseResponse<object>(result.Data, "Graph result"));
            }
            catch (Exception ex)
            {
                throw new ApiException($"{ex.Message}") { StatusCode = (int)HttpStatusCode.InternalServerError };
            }   
        }
    }
}
