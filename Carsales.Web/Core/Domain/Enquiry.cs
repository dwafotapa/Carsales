using System.ComponentModel.DataAnnotations;

namespace Carsales.Core.Domain
{
    public class Enquiry
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Car Car { get; set; }
    }
}