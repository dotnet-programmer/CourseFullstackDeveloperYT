﻿namespace PhoneBook.ConsoleApp;

internal class Contact(string name, string number)
{
	public string Name { get; set; } = name;
	public string Number { get; set; } = number;
}