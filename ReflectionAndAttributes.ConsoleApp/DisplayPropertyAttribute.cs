namespace ReflectionAndAttributes.ConsoleApp;

// Atrybut ograniczający klasę atrybutu do możliwości nałożenia tylko na właściwości
// dodatkowo umożliwienie nałożenia danego atrybutu więcej niż 1 raz jeden pod drugim
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class DisplayPropertyAttribute(string displayName) : Attribute
{
	public string DisplayName { get; set; } = displayName;
}