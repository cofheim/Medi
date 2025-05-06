using System.ComponentModel.DataAnnotations;

namespace Medi.API.Contracts
{
    public record LoginUserRequest([Required] string email, [Required] string password);
}
