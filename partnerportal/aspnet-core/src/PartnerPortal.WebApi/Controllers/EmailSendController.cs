using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Domain.Model;


namespace PartnerPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
       
       

            private readonly Services.IMailService mailService;
            public EmailSendController(Services.IMailService mailService)
            {
                this.mailService = mailService;
            }

            [HttpPost("Send")]
            public async Task<IActionResult> Send([FromForm] Services.MailRequest request)
            {
                try
                {
                    await mailService.SendEmailAsync(request);
                    return Ok();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


        }
    }

