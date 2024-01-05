using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmkMovies.Models;

public partial class Movie
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Ticket price must be greater than 0")]
    public double TicketPrice { get; set; }

    [Required]
    public string Genre { get; set; }
}
