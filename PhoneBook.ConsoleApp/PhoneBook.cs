namespace PhoneBook.ConsoleApp;

internal class PhoneBook
{
	public List<Contact> Contacts { get; set; } = new();

	public void AddContact(Contact contact) => Contacts.Add(contact);

	public void DisplayContact(string number)
	{
		var contact = Contacts.FirstOrDefault(x => x.Number == number);

		if (contact == null)
		{
			Console.WriteLine("Contact not fount");
		}
		else
		{
			DisplayContactDetails(contact);
		}
	}

	public void DisplayAllContacts() => DisplayContactsDetails(Contacts);

	public void DisplayMatchingContacts(string searchPhrase)
	{
		var matchingContacts = Contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();
		DisplayContactsDetails(matchingContacts);
	}

	public void DeleteContact(string number)
	{
		Contact contact = Contacts.Find(x => x.Number == number);
		if (contact != null)
		{
			Contacts.Remove(contact);
			Console.WriteLine("The contact has been removed.");
		}
		Console.WriteLine("There is no such contact for the given number!");
	}

	private void DisplayContactDetails(Contact contact) => Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");

	private void DisplayContactsDetails(List<Contact> contacts)
	{
		foreach (var contact in contacts)
		{
			DisplayContactDetails(contact);
		}
	}
}