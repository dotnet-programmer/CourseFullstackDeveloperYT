using GenericTypes.ConsoleApp;

List<Restaurant> restaurants = [];
PaginatedResult<Restaurant> restaurantsResults = new()
{
	Results = restaurants
};

List<User> users = [];
PaginatedResult<User> userResults = new()
{
	Results = users
};

//************************************************************************************

//Repository<string> stringRepository = new();
//stringRepository.AddElement("some value");
//string firstElement = stringRepository.GetElement(0);

Repository<User> userRepository2 = new();

Repository<string, User> userRepository = new();
userRepository.AddElement("Bill", new User() { Name = "Bill" });
User user = userRepository.GetElement("Bill");

//************************************************************************************

int[] intArray = [1, 3, 5];
Utils.Swap(ref intArray[0], ref intArray[2]);
Console.WriteLine(string.Join(' ', intArray));

//************************************************************************************

//Display display = Console.WriteLine;

Display display = WriteWithComma;
void WriteWithComma(string value)
	=> Console.Write(value + ", ");

Display display2 = (string value) => Console.Write(value + ", ");

display("Test"); // uruchomienie Console.WriteLine z argumentem "Test"

int[] numbers = [10, 20, 30];
DisplayNumbers(numbers, display);

int count = Count(numbers, (int value) => value > 15);
Console.WriteLine(count);

string[] strings = ["Generic", "Delegate", "Test"];
int countStrings = Count(strings, value => value.Length > 4);
Console.WriteLine(countStrings);

void DisplayNumbers(IEnumerable<int> numbers, Display display)
{
	foreach (int number in numbers)
	{
		//Console.WriteLine(number);
		display(number.ToString());
	}
}

int Count<T>(IEnumerable<T> elements, GenericPredicate<T> predicate)
{
	int count = 0;
	foreach (T element in elements)
	{
		//if (element > greaterThanValue)
		if (predicate(element))
		{
			count++;
		}
	}
	return count;
}

public delegate void Display(string value);

public delegate bool GenericPredicate<T>(T value);

// wbudowane generyczne delegaty:
// public delegate void Action<in T>(T obj); - przyjmuje od 0 do 16 parametrów, nie zwraca wartości
// public delegate TResult Func<in T1, out TResult>(); - przyjmuje od 0 do 16 parametrów, zwraca wartość TResult (zawsze przekazywana jako ostatni parametr generyczny)
// public delegate bool Predicate<in T>(T obj); - 