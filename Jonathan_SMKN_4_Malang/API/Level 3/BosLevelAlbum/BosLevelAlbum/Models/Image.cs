using System;
using System.Collections.Generic;

namespace BosLevelAlbum.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePath { get; set; } = null!;
}
