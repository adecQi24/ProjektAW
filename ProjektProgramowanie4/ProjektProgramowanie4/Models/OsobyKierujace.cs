using System;
using System.Collections.Generic;

namespace ProjektProgramowanie4.Models;

public partial class OsobyKierujace
{
    public int IdOsoby { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string? Adres { get; set; }

    public virtual ICollection<Wpisy> Wpisy { get; set; } = new List<Wpisy>();
}
