namespace AsyncProgramming.ConsoleApp;

internal class Program
{
	// można obsługiwać wyjątki jeżeli metoda jest async Task a nie async Void
	//static async Task FooAsync()
	//{
	//	Console.WriteLine("Foo start");
	//	await Task.Delay(2000);
	//	throw new Exception();
	//	Console.WriteLine("Foo end");
	//}

	//static async Task Main(string[] args)
	//{
	//	Console.WriteLine("Main started");
	//	try
	//	{
	//		await FooAsync();
	//	}
	//	catch (Exception e)
	//	{
	//		Console.WriteLine("Exception");
	//	}
	//}



	private static string userAnswer;

	static async Task Main(string[] args)
	{
		Console.WriteLine("Main started");
		var tokenSource = new CancellationTokenSource(1000);
		CancellationToken token = tokenSource.Token;

		var userAnswer = GetAnswer();
		var delay = Task.Delay(5000, token);
		var returnedTask = await Task.WhenAny(userAnswer, delay);

		if (delay.IsCompleted)
		{
			Console.WriteLine($"Your anwser is incorret");
		}
		Console.ReadKey();
	}

	static Task<string> GetAnswer()
	{
		Console.WriteLine("Your answer:");
		userAnswer = Console.ReadLine();
		return Task.FromResult(userAnswer);
	}
}