using System.Reflection;
using ReflectionAndAttributes.ConsoleApp;

static void Display(object obj)
{
	Type objType = obj.GetType();
	var properties = objType.GetProperties();

	foreach (var property in properties)
	{
		var propValue = property.GetValue(obj);
		var propType = propValue.GetType();
		if (propType.IsPrimitive || propType == typeof(string))
		{
			var displayPropertyAttribute = property.GetCustomAttribute<DisplayPropertyAttribute>();
			//Console.WriteLine($"{(displayPropertyAttribute != null ? displayPropertyAttribute.DisplayName : property.Name)}: {propValue}");
			Console.WriteLine($"{displayPropertyAttribute?.DisplayName ?? property.Name}: {propValue}");
		}
	}
}

Address address = new()
{
	City = "Krakow",
	PostalCode = "31-556",
	Street = "Grodzka 5"
};

Person person = new()
{
	FirstName = "John",
	LastName = "Doe",
	Address = address
};

Console.WriteLine("Person:");
Display(person);

Console.WriteLine("Address:");
Display(address);

// ********************************************************************

// zmiana wartości właściwości poprzez refleksje - podanie w konsoli nazwy właściwości i jej nowej wartości

Console.WriteLine("Insert person property to update");
var propertyToUpdate = Console.ReadLine();
Console.WriteLine("Insert value");
var value = Console.ReadLine();
SetValue(person, propertyToUpdate, value);
Console.WriteLine("Person:");
Display(person);

static void SetValue<T>(T obj, string propName, string value)
{
	Type objType = typeof(T);
	var propertyToUpdate = objType.GetProperty(propName);
	propertyToUpdate?.SetValue(obj, value);
}