using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Index("Email", Name = "UQ__SignUpRe__A9D105349BAE5C47", IsUnique = true)]
public partial class SignUpRequest
{
    [Key]
    public Guid SignInId { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    public SignUpRequestStatus Status { get; set; } = SignUpRequestStatus.Pending;
}
