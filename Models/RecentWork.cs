using System;
using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz.Models
{
	public class RecentWork
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş ola bilməz"), MaxLength(50, ErrorMessage = "Uzunluq maximum 50 simvol olmalıdır")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}

