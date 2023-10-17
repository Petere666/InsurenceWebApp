using System.ComponentModel.DataAnnotations;

namespace InsurenceWebApp.Models
{
    public class MyUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vyplňte popisek")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Vyplňte popisek")]
        public string SurName { get; set; } = "";

        [Required(ErrorMessage = "Vyplňte popisek")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Vyplňte popisek")]
        [Range(18, 150)]
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

        public ICollection<Insurance>? MyInsurances { get; set; }
        }
}
