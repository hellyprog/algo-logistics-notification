namespace AlgoLogistics.Notification.Services.Models
{
	public class EmailNotification : Notification
	{
		public string FromEmail { get; set; }
		public string ToEmail { get; set; }
		public string Subject { get; set; }
	}
}
