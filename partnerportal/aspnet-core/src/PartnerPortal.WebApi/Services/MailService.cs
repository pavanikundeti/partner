

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PartnerPortal.Domain.Model;
using PartnerPortal.WebApi.Settings;

namespace PartnerPortal.WebApi.Services
{
   
    
        public class MailService : IMailService
        {
            private readonly MailSettings _mailSettings;
            public MailService(MailSettings mailSettings)
            {
                _mailSettings = mailSettings;
            }
            public async Task SendEmailAsync(MailRequest mailRequest)
            {
                var email = new MimeMessage();
                //MailMessage email=new MailMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                //email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

                string[] multiEmail = mailRequest.ToEmail.Split(',');

                foreach (string emailid in multiEmail)
                {
                    email.To.Add(MailboxAddress.Parse(emailid));
                }
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                //builder.HtmlBody = mailRequest.Body;
                //email.Body = builder.ToMessageBody();
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = @" <html>
<head>
    <title></title>
</head>
<body>
    <img src=""https://cdn.flatworldsolutions.com/images/flatworld-logo.png"" width=""150"" height=""120"" style=""display: block; border: 0px;"" /><br />
    <br />
    <div style=""border-top: 3px solid  #000000"">
        &nbsp;</div>
    <span style=""font-family: Arial; font-size: 10pt"">Hello <b>{Rakshith}</b>,<br />
        <br />
        <p style=""margin: 0;"">We’re elated to have you join our team. On behalf of the entire organization, we would like to heartily congratulate you.</p><br />
		<p style=""margin: 0;"">You'r login details are following below.</p>
<br />
        <br />
        <a href=""https://www.flatworldsolutions.com/"">  
                    Click here to Login  <br />
         </a>  <br />
		<p style=""margin: 0;"">If you have any questions, just reply to this email&mdash;we're always happy to help out.</p>

        <br />
        <br />
        Thanks,<br />
        Flatworld Team </span>
</body>
</html>";

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = _mailSettings.Host;
                // smtp.Port = _mailSettings.Port;
                // smtp.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                //smtp.EnableSsl = true;
                //smtp.Send(email);
                email.Body = bodyBuilder.ToMessageBody();
                using var smtp = new SmtpClient();
            
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);

                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            
            }


        }
    }


