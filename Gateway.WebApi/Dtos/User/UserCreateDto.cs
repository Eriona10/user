namespace Gateway.WebApi.Dtos.User
{
    public class UserCreateDto
    {
        public string Id { get; set; } = null!;

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? RoleId { get; set; }


    }
}
