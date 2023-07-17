namespace ReflectionAndAttributes.ConsoleApp;

//[DisplayProperty("Test")]
public class Person
{
	// przy nazwie klasy która dziedziczy po Attribute dopisek Attribute jesto domyślny i można go pominąć
	// dlatego dla klasy DisplayPropertyAttribute nazwa w nawiasach to DisplayProperty
	[DisplayProperty("First Name")]
	public string FirstName { get; set; }

	[DisplayProperty("Last Name")]
	public string LastName { get; set; }

	public Address Address { get; set; }

	//public void Work([DisplayProperty("value")] string value)
	//{

	//}
}