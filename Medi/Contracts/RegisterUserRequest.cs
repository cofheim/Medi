using System.ComponentModel.DataAnnotations;
using Medi.Core.Models;

namespace Medi.API.Contracts
{
    public record RegisterUserRequest([Required] string UserName, [Required] string Password, [Required] string Email);

}
