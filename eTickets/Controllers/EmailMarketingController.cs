using System.IO;
using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; 
    
namespace eTickets.Controllers
{
    public class EmailMarketingController : Controller
    {
        private readonly EmailService _emailService;
        public IActionResult Index()
        {
            return View();
        }
        public EmailMarketingController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult SendMarketingEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMarketingEmail(EmailMarketingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Templates/EmailTemplate.html");
            string link = "https://localhost:44300/EmailMarketing/Unsubscribe";

            string emailContent = await _emailService.LoadEmailTemplateAsync(templatePath, model.Name, link);
            await _emailService.SendEmailAsync(model.Email, "uu dai dac biet cho ban", emailContent);

            ViewBag.Message = "Email sent successfully";
            return View();

        }
    }
}
