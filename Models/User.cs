using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebJdr.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Nickname { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
    }
}