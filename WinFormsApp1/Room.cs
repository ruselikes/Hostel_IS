using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Room
{
    public int RoomId { get; set; }

    public int BedQty { get; set; }

    public int FreeBedQty { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Zaselenie> Zaselenies { get; } = new List<Zaselenie>();
}
