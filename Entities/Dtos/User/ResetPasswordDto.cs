namespace Entities.Dtos.User
{
    public record ResetPasswordDto
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
        public string? ConfirmPassword { get; init; }
    }
}
