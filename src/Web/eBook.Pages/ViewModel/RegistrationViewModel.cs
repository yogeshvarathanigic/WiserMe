﻿using System.ComponentModel.DataAnnotations;

namespace eBook.Pages.ViewModel
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserAvatar { get; set; }


    }
}
