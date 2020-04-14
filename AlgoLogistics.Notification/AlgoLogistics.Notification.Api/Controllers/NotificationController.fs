namespace AlgoLogistics.Notification.Api.Controllers

open Microsoft.AspNetCore.Mvc
open System.Net.Mail
open System.Net

[<ApiController>]
[<Route("api/[controller]")>]
type NotificationController () =
    inherit ControllerBase()

    [<HttpPost("email")>]
    member _.SendEmailNotification() =
        use mail = new MailMessage("noreply@example.com", "to@example.com", "F# Test", "Hello")
        use client = new SmtpClient("smtp.mailtrap.io", 587)
        client.EnableSsl <- true
        client.Credentials <- new NetworkCredential("4508285bd5c13d", "dd1c6048800cb9")
        client.Send mail
        ActionResult<bool>(true)