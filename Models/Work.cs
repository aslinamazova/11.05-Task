using System;
using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz.Models
{
	public class Work
	{
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

