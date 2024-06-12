using Core.Entities;
using Core.Entities.Abstract;

namespace Tasinmaz.API.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
