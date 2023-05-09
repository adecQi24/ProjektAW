using System;
using System.Collections.Generic;

namespace ProjektProgramowanie4.Models;

public partial class Wpisy
{
    public int IdWpisu { get; set; }

    public int IdOsoby { get; set; }

    public int IdLiczby { get; set; }

    public string? OpisTrasy { get; set; }

    public DateTime DataWyjazdu { get; set; }

    public int KolejnyNrWpisu { get; set; }

    public int LiczbaPrzejechanychKm { get; set; }

    public virtual ICollection<Ewidencje> Ewidencje { get; set; } = new List<Ewidencje>();

    public virtual LiczbaKilometrow IdLiczbyNavigation { get; set; } = null!;

    public virtual OsobyKierujace IdOsobyNavigation { get; set; } = null!;
}
