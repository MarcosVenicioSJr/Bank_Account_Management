using System.ComponentModel.DataAnnotations;

namespace Authentication.API.DTO;

public class CreateUserRequest
{
    [Required(ErrorMessage = "The field Name is required.")]
    [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "Name field only accepts letters and spaces")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The field Email is required.")]
    [EmailAddress(ErrorMessage = "Email field must contain a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The Password field is required.")]
    [MinLength(4, ErrorMessage = "The password field must contain at least 4 characters.")]
    [MaxLength(6, ErrorMessage = "The password field must contain a maximum of 6 characters.")]
    public string Password { get; set; }
}