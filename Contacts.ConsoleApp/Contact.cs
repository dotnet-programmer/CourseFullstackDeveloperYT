namespace Contacts.ConsoleApp;

internal class Contact(string name, string phoneNumber)
{
	public string Name { get; private set; } = name;
	public string PhoneNumber { get; private set; } = phoneNumber;

	public override string ToString()
		=> Name + " " + PhoneNumber;
}