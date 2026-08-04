namespace rental_system.Models.Dtos
{
    public class TotalBillDto
    {
        public int TenantMapId { get; set; }
        public double PrevUnit { get; set; }
        public double CurrentUnit { get; set; }
        public double Rate { get; set; }
        public double CommonMeter { get; set; }
        public double Utilities { get; set; }
        public DateOnly BillMonth { get; set; }
    }
}
