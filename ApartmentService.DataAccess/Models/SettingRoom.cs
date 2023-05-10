using System;
using System.Collections.Generic;

namespace ApartmentService.DataAccess.Models;

public partial class SettingRoom
{
    public string RoomId { get; set; } = null!;

    public string? Location { get; set; }

    public int? Floor { get; set; }

    public string? RoomNumber { get; set; }

    public bool Availability { get; set; }

    public float ElectricityBill { get; set; }

    public float WaterBill { get; set; }

    public int Rent { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
