namespace Entities.Dtos.User
{
    public record UserDtoForCreation : UserDto
    {
        public string? Password { get; init; }
    }
}
