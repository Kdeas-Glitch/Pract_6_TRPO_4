using System;
using System.Collections.Generic;

namespace Pract_6_Demin.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string InventoryNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public bool IsOperational { get; set; }
}
