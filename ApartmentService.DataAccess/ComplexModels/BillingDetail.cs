using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.ComplexModels
{
    public class BillingDetail
    {
        public string? BillingId { get; set; }
        public int? Floor { get; set; }
        public string? RoomNumber { get; set; }
        public float TotalElectricityBill { get; set; }
        public float TotalWaterBill { get; set; }
        public int Rent { get; set; }
        public float TotalRent { get; set; }
        public bool Paid { get; set; }
    }
}
