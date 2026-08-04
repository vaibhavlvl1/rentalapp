using System.ComponentModel.DataAnnotations;

namespace rental_system.Models.Entities
{
    public class TotalBillEntity
    {
        [Key]
        public int Id { get; set; }
        public int TenantMapId { get; set; }
        public double PrevUnit { get; set; }
        public double CurrentUnit { get; set; }
        public double Rate { get; set; }
        public double CommonMeter { get; set; }
        public double Utilities { get; set; }
        public double RoomRent { get; set; }
        public double Ebill { get; set; }
        public double Total { get; set; }
        public DateOnly BillForMonth { get; set; }

        public bool RentPaid { get; set; }
        public bool EbillPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
