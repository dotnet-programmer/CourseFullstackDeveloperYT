namespace SolidPrinciples.ConsoleApp.DependencyInversion;

internal class SmsNotification : INotificationSender
{
	public void SendNotification(User user) => Console.WriteLine($"Sending sms notification to user: {user.Name}");
}