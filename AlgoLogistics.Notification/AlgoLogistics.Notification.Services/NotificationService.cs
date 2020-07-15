using AlgoLogistics.Notification.Services.Interfaces;
using AlgoLogistics.Notification.Services.Models;
using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace AlgoLogistics.Notification.Services
{
	public class NotificationService : INotificationService
	{
		public void SendEmailNotification(EmailNotification emailNotification)
		{
			var mail = new MailMessage(
				"noreply@algologistics.com",
				emailNotification.ToEmail,
				emailNotification.Subject,
				emailNotification.Message);
			var client = new SmtpClient("smtp.mailtrap.io", 587)
			{
				EnableSsl = true,
				Credentials = new NetworkCredential("4508285bd5c13d", "dd1c6048800cb9")
			};

			client.Send(mail);
		}
	}
}
