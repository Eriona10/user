using System;
using System.Collections.Generic;

namespace User.Microservice.Data.Entieties;

public partial class Submenu
{
    public int SubmenuId { get; set; }

    public int MenuId { get; set; }

    public string? ParentSubId { get; set; }

    public string Name { get; set; } = null!;

    public string? Claim { get; set; }

    public string? ClaimType { get; set; }

    public bool IsActive { get; set; }

    public string? Area { get; set; }

    public string? Controller { get; set; }

    public string Action { get; set; } = null!;

    public int OrdinalNumber { get; set; }

    public string Icon { get; set; } = null!;

    public bool IsBlazor { get; set; }

    public string? Roles { get; set; }

    public string? StaysOpenFor { get; set; }

    public string? InsertedFrom { get; set; }

    public DateTime InsertedDate { get; set; }

    public string? UpdatedFrom { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
