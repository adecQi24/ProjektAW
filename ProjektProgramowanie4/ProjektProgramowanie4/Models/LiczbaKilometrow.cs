using System;
using System.Collections.Generic;

namespace ProjektProgramowanie4.Models;

public partial class LiczbaKilometrow
{
    public int IdLiczby { get; set; }

    public int LiczbaKmKoncowa { get; set; }

    public virtual ICollection<Ewidencje> Ewidencje { get; set; } = new List<Ewidencje>();

    public virtual ICollection<Wpisy> Wpisy { get; set; } = new List<Wpisy>();
}
