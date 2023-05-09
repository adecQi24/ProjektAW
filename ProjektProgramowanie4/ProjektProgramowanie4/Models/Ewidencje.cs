using System;
using System.Collections.Generic;

namespace ProjektProgramowanie4.Models;

public partial class Ewidencje
{
    public int IdEwidencji { get; set; }

    public int IdWpisu { get; set; }

    public int IdLiczby { get; set; }

    public DateTime DataRozpoczecia { get; set; }

    public DateTime DataZakonczenia { get; set; }

    public int StanLicznikaPoczatkowy { get; set; }

    public int StanLicznikaKoncowy { get; set; }

    public virtual LiczbaKilometrow IdLiczbyNavigation { get; set; } = null!;

    public virtual Wpisy IdWpisuNavigation { get; set; } = null!;

    public virtual ICollection<Pojazdy> Pojazdy { get; set; } = new List<Pojazdy>();
}
