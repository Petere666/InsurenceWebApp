namespace InsurenceWebApp.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string ContractType { get; set; } = "";
        public int ContractNumber { get; set; }
        public int MonthPayment {  get; set; }
        public int Principal {  get; set; }
        public int Validity { get; set; }

        public MyUser? MyUser { get; set; }

        public Insurance()
        {
            MyEvents = new List<InsurancesEvents>();
        }

        public ICollection<InsurancesEvents> MyEvents { get; set; }
    }
}
