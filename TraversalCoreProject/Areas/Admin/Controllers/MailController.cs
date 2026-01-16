using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProject.Models;
using MailKit.Net.Smtp;

namespace TraversalCoreProject.Areas.Admin.Controllers;

[Area("Admin")]
public class MailController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(MailRequest mailRequest)
    {
        // Formdan gelen veri boş mu kontrolü
        if (string.IsNullOrEmpty(mailRequest.ReceiverMail))
        {
            ModelState.AddModelError("", "Alıcı adresi boş olamaz.");
            return View(mailRequest);
        }

        MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ismetkeremprojedeneme@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        // Artık ReceiverMail null olmayacağı için bu satır hata vermeyecektir
        MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);
    
        // Mesaj gövdesini de eklemeyi unutmayın
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = mailRequest.Body; 
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = mailRequest.Subject;

        using (SmtpClient smtpClient = new SmtpClient())
        {
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("ismetkeremprojedeneme@gmail.com", "gnni hyse mwkp gcbq");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }

        return RedirectToAction("Index"); // İşlem bitince sayfayı yenile
    }
}
// ismetkeremprojedeneme@gmail.com