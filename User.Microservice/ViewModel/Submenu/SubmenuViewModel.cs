using System.ComponentModel.DataAnnotations;

namespace User.Microservice.ViewModel.Submenu
{
    public class SubmenuViewModel
    {
        public int MId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }
    }

    public class SubmenuCreateViewModel
    {
        public int MId { get; set; }

        [Display(Name = "Parent submenu")]
        public string? ParentID { get; set; }

        public string? Menu { get; set; }

        [Display(Name = "Name albanian")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Area")]
        public string? Area { get; set; }

        [Display(Name = "Controller")]
        [Required]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        [Required]
        public string Action { get; set; }

        [Display(Name = "OrdinalNumber")]
        public int OrdinalNumber { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [Display(Name = "Policy")]
        [Required]
        public string Policy { get; set; }

        [Display(Name = "Icon")]
        [Required]
        public string Icon { get; set; }

        [Display(Name = "SubStaysOpenFor")]
        [Required]
        public string StaysOpenFor { get; set; }
    }
    public class SubmenuEditViewModel : SubmenuCreateViewModel
    {
        public int Id { get; set; }
    }
}
