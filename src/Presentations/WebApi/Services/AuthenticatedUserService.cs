using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserEmail = httpContextAccessor.HttpContext?.User?.FindFirstValue("email");
        }

        public string UserEmail { get; }
    }
}
