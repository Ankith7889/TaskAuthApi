﻿using System.ComponentModel.DataAnnotations;

namespace TaskAuthApi.Models.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
