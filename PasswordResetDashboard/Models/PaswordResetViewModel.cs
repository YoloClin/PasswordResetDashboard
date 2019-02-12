using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PasswordResetDashboard.Models
{
    public class PaswordResetViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}