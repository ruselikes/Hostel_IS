using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string Mphone { get; set; } = null!;

    public string Mname { get; set; } = null!;

    public string Msurname { get; set; } = null!;

   public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;


    public string? MmiddleName { get; set; }
}
