using System;
using System.ComponentModel.DataAnnotations;
using Carsales.Core.Domain;

namespace Carsales.Web.ViewModels
{
    public class EnquiryAddViewModel
    {
        [Required]        
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
