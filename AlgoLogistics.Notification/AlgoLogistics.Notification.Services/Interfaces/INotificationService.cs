using AlgoLogistics.Notification.Services.Models;
using System.Threading.Tasks;

namespace AlgoLogistics.Notification.Services.Interfaces
{
	public interface INotificationService
	{
		void SendEmailNotification(EmailNotification emailNotification);
	}
}
