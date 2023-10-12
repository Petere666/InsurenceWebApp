using System.ComponentModel.DataAnnotations;

namespace InsurenceWebApp.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vyplňte popisek")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popisek")]
        public string SurName { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popisek")]
        public int BirthDate { get; set; }
        [Required(ErrorMessage = "Vyplňte popisek")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Vyplňte popisek")]
        public string City { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popisek")]
        public string Street { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popisek")]
        public string ReferenceNumber { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popisek")]
        public int TelephoneNumber { get; set; }
        

        public string Email { get; set; } = "";

        public ICollection<Insurances>? MyInsurances { get; set; }
    }
}
