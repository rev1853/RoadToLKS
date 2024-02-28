using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JWTAuthentication.Database;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    [JsonIgnore]
    public virtual ICollection<Mutation> Mutations { get; set; } = new List<Mutation>();

    [JsonIgnore]
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    [JsonIgnore]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
