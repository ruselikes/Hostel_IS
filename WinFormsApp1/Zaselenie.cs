using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Zaselenie
{
    public int ZaselenieId { get; set; }

    public int ClientId { get; set; }

    public int RoomId { get; set; }

    public DateTime DataZasel { get; set; }

    public DateTime DataVisel { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
