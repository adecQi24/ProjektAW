using System;
using System.Collections.Generic;

namespace ProjektProgramowanie4.Models;

public partial class Pojazdy
{
    public string NrRejestracyjny { get; set; } = null!;

    public int? IdEwidencji { get; set; }

    public string MarkaPojazdu { get; set; } = null!;

    public string RodzajPojazdu { get; set; } = null!;

    public virtual Ewidencje? IdEwidencjiNavigation { get; set; }
}
