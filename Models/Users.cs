namespace InsurenceWebApp.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string SurName { get; set; } = "";
        public int BirthDate { get; set; }
        public int Age { get; set; }
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public string ReferenceNumber { get; set; } = "";
        public int TelephoneNumber { get; set; } 
        public string Email { get; set; } = "";
    }
}
