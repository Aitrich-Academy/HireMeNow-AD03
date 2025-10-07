using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("Location")]
public partial class Location
{
    [Key]
    public Guid LocationId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(150)]
    public string State { get; set; } = null!;

    [StringLength(150)]
    public string Country { get; set; } = null!;

    [StringLength(20)]
    public string? PostalCode { get; set; }
}
