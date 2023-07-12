namespace GenericTypes.ConsoleApp;

internal class Utils
{
	// można nakładać ograniczenia na metody generyczne tak samo jak na klasy
	public static void Swap<T>(ref T first, ref T second) // where T : IEntity, new()
	{
		T temp = first;
		first = second;
		second = temp;
	}
}