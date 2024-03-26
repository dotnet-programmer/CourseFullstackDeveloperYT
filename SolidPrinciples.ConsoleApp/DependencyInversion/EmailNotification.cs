namespace SolidPrinciples.ConsoleApp.DependencyInversion;

// moduł niskopoziomowy

// wersja bez interfejsu
internal class EmailNotificationBad
{
	internal void SendNotification(User user)
		=> Console.WriteLine($"Sending email notification to user: {user.Name}");
}

// wersja z interfejsem
internal class EmailNotification : INotificationSender
{
	public void SendNotification(User user)
		=> Console.WriteLine($"Sending email notification to user: {user.Name}");
}