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
        Task<BaseResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<BaseResponse<string>> RegisterAsync(RegisterRequest request, string uri);
        Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPasswordAsync(ForgotPasswordRequest request, string uri);
        Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordRequest request);
        Task<BaseResponse<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
