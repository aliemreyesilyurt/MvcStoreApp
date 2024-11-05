using Entities.ValidateAttributes;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.User
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required!")]
        public string? Username { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; init; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }

        [MinCount(1, ErrorMessage = "Roles collection must contain at least one item.")]
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
