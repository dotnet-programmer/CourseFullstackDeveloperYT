Console.Write("Write date of birth: ");
string input = Console.ReadLine();
Console.WriteLine(DateTime.TryParse(input, out DateTime date) ? $"You live {(DateTime.Now - date).Days} days" : "Wrong data format!");