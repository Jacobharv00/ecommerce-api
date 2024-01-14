using System.ComponentModel.DataAnnotations;


namespace EcommerceAPI.Models
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "The Address should be at least 5 characters")]
        [MaxLength(1000, ErrorMessage = "The Address should be less than 1000 characters")]
        public string Address { get; set; } = string.Empty;

    }
}
