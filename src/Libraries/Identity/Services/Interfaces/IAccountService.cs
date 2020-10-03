using Models.DTOs.Account;
using Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<BaseResponse<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string code);
    }
}
