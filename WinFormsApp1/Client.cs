using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Client
{
    public int ClientId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string ClientSurname { get; set; } = null!;

    public string? ClientMiddleName { get; set; }

    public virtual ICollection<Zaselenie> Zaselenies { get; } = new List<Zaselenie>();
}
