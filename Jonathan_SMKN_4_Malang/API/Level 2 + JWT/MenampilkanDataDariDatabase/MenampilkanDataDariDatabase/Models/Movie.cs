using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenampilkanDataDariDatabase.Models;

public partial class Movie
{
    
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public double TicketPrice { get; set; }

    public string Genre { get; set; } = null!;
}
