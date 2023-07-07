namespace Contacts.ConsoleApp;

internal class Contact
{
	public Contact(string name, string phoneNumber)
	{
		Name = name;
		PhoneNumber = phoneNumber;
	}

	public string Name { get; private set; }
	public string PhoneNumber { get; private set; }

	public override string ToString() => Name + " " + PhoneNumber;
}