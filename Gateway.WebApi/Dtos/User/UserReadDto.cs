
namespace Gateway.WebApi.Dtos.User
{
  public class UserReadDto
{
        public string Id { get; set; } = null!;
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }



}
}
