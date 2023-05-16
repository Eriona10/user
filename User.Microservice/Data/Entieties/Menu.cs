using System;
using System.Collections.Generic;

namespace User.Microservice.Data.Entieties;

public partial class Menu
{
    public int MenuId { get; set; }

    public string? Name { get; set; }

    public bool? HasSubMenu { get; set; }

    public string? Claim { get; set; }

    public string? ClaimType { get; set; }

    public string? Icon { get; set; }

    public bool IsActive { get; set; }

    public string? Area { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public int OrdinalNumber { get; set; }

    public string? Roles { get; set; }

    public string? StaysOpenFor { get; set; }

    public string? InsertedFrom { get; set; }

    public DateTime InsertedDate { get; set; }

    public string? UpdatedFrom { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
