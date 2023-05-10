using System;
using System.Collections.Generic;

namespace ApartmentService.DataAccess.Models;

public partial class Billing
{
    public string BillingId { get; set; } = null!;

    public string RoomId { get; set; } = null!;

    public float? ElectricityCost { get; set; }

    public float? WaterCost { get; set; }

    public int Monthly { get; set; }

    public int Yearly { get; set; }

    public bool Paid { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
