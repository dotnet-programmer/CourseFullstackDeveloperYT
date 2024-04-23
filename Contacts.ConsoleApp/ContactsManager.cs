using System.Text.Json;

namespace Contacts.ConsoleApp;

internal class ContactsManager
{
	private readonly string _filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%"), "ContactsApp", "Contacts.json");

	private List<Contact> _contacts;

	public ContactsManager()
		=> ReadContacts();

	public void AddContact(string name, string phoneNumber)
	{
		_contacts.Add(new Contact(name, GetRawNumber(phoneNumber)));
		SaveContacts();
	}

	public string GetContactByNumber(string phoneNumber)
	{
		Contact contact = _contacts.Find(x => x.PhoneNumber == GetRawNumber(phoneNumber));
		if (contact != null)
		{
			return contact.ToString();
		}
		return "There is no such contact for the given number!";
	}

	public string GetAllContacts()
		=> GetElementsFromList(_contacts, "Empty list.");

	public string GetContactsByName(string name)
		=> GetElementsFromList(_contacts.FindAll(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)), "There is no such contact for the given name!");

	public string DeleteContact(string phoneNumber)
	{
		Contact contact = _contacts.Find(x => x.PhoneNumber == GetRawNumber(phoneNumber));
		if (contact != null)
		{
			_contacts.Remove(contact);
			SaveContacts();
			return "The contact has been removed.";
		}
		return "There is no such contact for the given number!";
	}

	private string GetRawNumber(string phoneNumber)
		=> phoneNumber.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\\", "");

	private string GetElementsFromList(List<Contact> collection, string emptyListMessage)
		=> collection.Count != 0 
			? string.Join(Environment.NewLine, collection) 
			: emptyListMessage;

	private void ReadContacts()
		=> _contacts = File.Exists(_filePath)
			? JsonSerializer.Deserialize<List<Contact>>(File.ReadAllText(_filePath))
			: [];

	private void SaveContacts()
	{
		var directoryName = Path.GetDirectoryName(_filePath);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllText(_filePath, JsonSerializer.Serialize(_contacts, new JsonSerializerOptions() { WriteIndented = true }));
	}
}