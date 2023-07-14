namespace SolidPrinciples.ConsoleApp.DependencyInversion;

// moduł wysokopoziomowy
internal class AuthenticationManagerBad
{
	// ten kod uzależnia klasę AuthenticationManager od niskopoziomowego modułu EmailNotification, czyli naruszenie zasady inwersji zależności
	// w przypadku dodania innego sposobu wysyłki powiadomienia np. SMS, ta klasa będzie wymagała zmiany i zaimplementowania tego nowego sposobu
	public void Authenticate(User user, string email, string password)
	{
		if (user.Email == email && user.Password == password)
		{
			EmailNotification emailNotification = new();
			emailNotification.SendNotification(user);
		}
	}
}

// moduł wysokopoziomowy
internal class AuthenticationManager
{
	// rozwiązanie problemu - wprowadzenie abstrakcji w postaci interfejsu INotificationSender
	// teraz klasa AuthenticationManager nie jest zależna od konkretnej implementacji wysyłki powiadomienia
	private readonly INotificationSender _notificationSender;

	public void Authenticate(User user, string email, string password)
	{
		if (user.Email == email && user.Password == password)
		{
			_notificationSender.SendNotification(user);
		}
	}

	// Dependency injection - wstrzykiwanie zależności:
	// wstrzyknięcie zależności to mechanizm pozwalający dostarczyć jakąś konkretną klasę modułu niskopoziomowgo do klasy wysokopoziomowego modułu
	// można to zrobić na kilka sposobów:
	// można wstrzyknąć tą klasę przez konstruktor, przez metodę lub przez właściwość
	// najpopularniejszym mechanizmem jest wstrzyknięcie przez konstruktor:
	// tworząc obiekt klasy AuthenticationManager do konstruktora przekazuje się obiekt konkretnej klasy implementującej wymagany interfejs
	public AuthenticationManager(INotificationSender notificationSender) => _notificationSender = notificationSender;
}