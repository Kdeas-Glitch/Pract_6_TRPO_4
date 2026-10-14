using System;
using System.Collections.Generic;

namespace Pract_6_Demin.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public decimal TicketPrice { get; set; }

    public bool IsActive { get; set; }
}
