using PhoneBook.ConsoleApp;

Console.WriteLine("Hello from the PhoneBook app");
Console.WriteLine("1 Add contact");
Console.WriteLine("2 Display contact by number");
Console.WriteLine("3 Display all contacts");
Console.WriteLine("4 Search contacts");
Console.WriteLine("5 Delete contact");
Console.WriteLine("To exit insert 'x'");
string userInput = Console.ReadLine();

PhoneBook.ConsoleApp.PhoneBook phoneBook = new();

while (true)
{
	switch (userInput)
	{
		case "1":
			Console.WriteLine("Insert number:");
			string number = Console.ReadLine();
			Console.WriteLine("Insert name:");
			string name = Console.ReadLine();
			Contact newContact = new(name, number);
			phoneBook.AddContact(newContact);
			break;
		case "2":
			Console.WriteLine("Insert number:");
			string numberToSearch = Console.ReadLine();
			phoneBook.DisplayContact(numberToSearch);
			break;
		case "3":
			phoneBook.DisplayAllContacts();
			break;
		case "4":
			Console.WriteLine("Insert search phrase:");
			string searchPhrase = Console.ReadLine();
			phoneBook.DisplayMatchingContacts(searchPhrase);
			break;
		case "5":
			Console.WriteLine("Insert number:");
			string numberToDelete = Console.ReadLine();
			phoneBook.DeleteContact(numberToDelete);
			break;
		case "x":
			return;
		default:
			Console.WriteLine("Invalid operation");
			break;
	}
    Console.Write("Select operation: ");
    userInput = Console.ReadLine();
}