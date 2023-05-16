using System.ComponentModel.DataAnnotations;

namespace User.Microservice.ViewModel.Authorization
{
    public class AuthorizationViewModel
    {
    }

    public class AuthorizationCreateViewModel
    {
        [Display(Name = "Role")]
        [Required]
        public string Role { get; set; }
    }
}
