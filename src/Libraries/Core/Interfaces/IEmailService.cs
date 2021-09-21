using Models.DTOs.Email;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
