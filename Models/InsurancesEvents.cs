namespace InsurenceWebApp.Models
{
    public class InsurancesEvents
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public int EventNumber { get; set; }
        public int DamageAmount { get; set; }
        public string DamageDescription { get; set; } = "";

    }
}
