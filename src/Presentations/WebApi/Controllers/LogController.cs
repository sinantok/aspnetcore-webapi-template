using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Log;
using Models.ResponseModels;
using Services.Interfaces;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILoginLogService _loginLogService;
        public LogController( ILoginLogService loginLogService)
        {
            _loginLogService = loginLogService;
        }
        [HttpGet("get")]
        public IActionResult GetUserAuthLogs(string email)
        {
            return Ok(new BaseResponse<IReadOnlyList<LogDto>>(null, $"User Log List"));
        }
        public IActionResult Index()
        {
            return Content("");
        }
    }
}
