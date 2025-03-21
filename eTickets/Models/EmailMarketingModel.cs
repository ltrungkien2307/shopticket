using System.ComponentModel.DataAnnotations;
namespace eTickets.Models;

public class EmailMarketingModel
{
    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email")]

    public string Email { get; set; }
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }
}
