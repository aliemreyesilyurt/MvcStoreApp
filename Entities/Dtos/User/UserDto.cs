namespace Entities.Dtos.User
{
    public record UserDto
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
