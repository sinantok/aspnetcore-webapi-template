using AutoMapper;
using Data.Mongo.Collections;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Log;
using Models.ResponseModels;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILoginLogService _loginLogService;
        private readonly IMapper _mapper;
        public LogController( ILoginLogService loginLogService, IMapper mapper)
        {
            _loginLogService = loginLogService;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUserAuthLogs(string email)
        {
            var userList = await _loginLogService.Get(email);
            var data = _mapper
                .Map<IReadOnlyList<LoginLog>, IReadOnlyList<LogDto>>(userList);

            return Ok(new BaseResponse<IReadOnlyList<LogDto>>(data, $"User Log List"));
        }
    }
}
