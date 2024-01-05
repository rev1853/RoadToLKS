using System;
using System.Collections.Generic;

namespace CRUD_File.Models;

public partial class CrudImage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePath { get; set; } = null!;
}
