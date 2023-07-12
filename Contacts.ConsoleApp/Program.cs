using Contacts.ConsoleApp;

ContactsManager contactsManager = new();

while (true)
{
	ShowMainMenu();
	Console.WriteLine();
	Console.Write("Your choice: ");
	string input = Console.ReadLine();
	switch (input)
	{
		case "1":
			AddContact();
			break;
		case "2":
			DisplayContactByNumber();
			break;
		case "3":
			DisplayAllContacts();
			break;
		case "4":
			FindContactsByName();
			break;
		case "5":
			DeleteContactByNumber();
			break;
		default:
			Environment.Exit(0);
			break;
	}
	Console.WriteLine();
	Console.Write("Press Enter to return to main menu...");
	Console.ReadLine();
}

static void ShowMainMenu()
{
	Console.Clear();
	Console.WriteLine("Contacts application.");
	Console.WriteLine();
	Console.WriteLine("1) Add new contact");
	Console.WriteLine("2) Display contact by number");
	Console.WriteLine("3) Display all contacts");
	Console.WriteLine("4) Find contacts by name");
	Console.WriteLine("5) Delete contact by number");
	Console.WriteLine();
	Console.WriteLine("Any other key to exit");
}

void AddContact()
{
	Console.Clear();
	Console.WriteLine("Add a new contact:");
	Console.WriteLine();
	string name = GetName();
	Console.Write("Phone number: ");
	string phoneNumber = Console.ReadLine();
	contactsManager.AddContact(name, phoneNumber);
}

string GetName()
{
	while (true)
	{
		Console.Write("Name: ");
		string input = Console.ReadLine();
		if (input.Length > 3)
		{
			return input;
		}
		Console.WriteLine("Name is too short!");
	}
}

void DisplayContactByNumber()
{
	Console.Clear();
	Console.WriteLine("Display contact by number:");
	Console.WriteLine();
	Console.Write("Write number: ");
	string phoneNumber = Console.ReadLine();
	Console.WriteLine();
	Console.WriteLine($"Contact with given number: {contactsManager.GetContactByNumber(phoneNumber)}");
}

void DisplayAllContacts()
{
	Console.Clear();
	Console.WriteLine("Display all contacts:");
	Console.WriteLine();
	Console.WriteLine(contactsManager.GetAllContacts());
}

void FindContactsByName()
{
	Console.Clear();
	Console.WriteLine("Display contacts by name:");
	Console.WriteLine();
	Console.Write("Write name: ");
	string name = Console.ReadLine();
	Console.WriteLine();
	Console.WriteLine($"Contacts with given name:");
	Console.WriteLine();
	Console.WriteLine(contactsManager.GetContactsByName(name));
}

void DeleteContactByNumber()
{
	Console.Clear();
	Console.WriteLine("Delete contact by number:");
	Console.WriteLine();
	Console.Write("Write number: ");
	string phoneNumber = Console.ReadLine();
	Console.WriteLine(contactsManager.DeleteContact(phoneNumber));
}