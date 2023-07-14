namespace SolidPrinciples.ConsoleApp.DependencyInversion;

internal interface INotificationSender
{
	void SendNotification(User user);
}