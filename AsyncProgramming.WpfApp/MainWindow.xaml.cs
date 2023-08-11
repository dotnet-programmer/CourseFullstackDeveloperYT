using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncProgramming.WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	// opóźnienie wykonania
	private async void Delay_Handler(object sender, RoutedEventArgs e)
	{
		ResultLabel.Content = "Start";

		// synchroniczne opóźnienie - blokuje wątek główny
		// Thread.Sleep(3000);

		// asynchroniczne wstrzymanie wykonania - nie blokuje wątku głównego
		await Task.Delay(3000);

		ResultLabel.Content = "Stop";
	}

	#region synchronous version

	private void Read_Files_Handler(object sender, RoutedEventArgs e)
	{
		ResultLabel.Content = "Reading started:";
		var stopwatch = Stopwatch.StartNew();
		ProcessFiles();
		stopwatch.Stop();
		ResultLabel.Content = $"Finished in: {stopwatch.ElapsedMilliseconds} ms";
	}

	private void ProcessFiles()
	{
		var filesPath = "D:/files/";
		for (int i = 1; i <= 5; i++)
		{
			var filePath = filesPath + $"{i}.txt";
			using (var reader = new StreamReader(filePath, Encoding.UTF8))
			{
				ResultLabel.Content = $"Reading {filePath}..";
				var fileContent = reader.ReadToEnd();
				// processing file content..
			}
		}
	}

	#endregion synchronous version

	#region asynchronous 1 - no return value

	private async void Read_Files_Async_Handler1(object sender, RoutedEventArgs e)
	{
		ResultLabel.Content = "Reading started:";
		var stopwatch = Stopwatch.StartNew();
		await ProcessFilesAsync1();
		stopwatch.Stop();
		ResultLabel.Content = $"Finished in: {stopwatch.ElapsedMilliseconds} ms";
	}

	private async Task ProcessFilesAsync1()
	{
		var filesPath = "D:/files/";
		for (int i = 1; i <= 5; i++)
		{
			var filePath = filesPath + $"{i}.txt";
			using (var reader = new StreamReader(filePath, Encoding.UTF8))
			{
				ResultLabel.Content = $"Reading {filePath}..";

				// Jeżeli metoda zwraca wartość:
				// - trzeba ją wywołać jako lambda w Task.Run()
				// - użyć await żeby oczekiwać na wartość zwróconą z tej metody
				var fileContent = await Task.Run(() => reader.ReadToEnd());

				// processing file content..
			}
		}
	}

	#endregion asynchronous 1 - no return value

	#region asynchronous 2 - with return value

	private async void Read_Files_Async_Handler2(object sender, RoutedEventArgs e)
	{
		ResultLabel.Content = "Reading started:";
		var stopwatch = Stopwatch.StartNew();
		var result = await ProcessFilesAsync2();
		stopwatch.Stop();
		ResultLabel.Content = $"Finished in: {stopwatch.ElapsedMilliseconds} ms. Result: {result}";
	}

	private async Task<int> ProcessFilesAsync2()
	{
		var totalLength = 0;
		var filesPath = "D:/files/";
		for (int i = 1; i <= 5; i++)
		{
			var filePath = filesPath + $"{i}.txt";
			using (var reader = new StreamReader(filePath, Encoding.UTF8))
			{
				ResultLabel.Content = $"Reading {filePath}..";
				var fileContent = await Task.Run(() => reader.ReadToEnd());
				totalLength += fileContent.Length;
				// processing file content..
			}
		}
		return totalLength;
	}

	#endregion asynchronous 2 - with return value

	#region asynchronous 3 - with parallel tasks

	private async void Read_Files_Async_Handler3(object sender, RoutedEventArgs e)
	{
		ResultLabel.Content = "Reading started:";
		var stopwatch = Stopwatch.StartNew();
		var result = await ProcessFilesAsync3();
		stopwatch.Stop();
		ResultLabel.Content = $"Finished in: {stopwatch.ElapsedMilliseconds} ms. Result: {result}";
	}

	private async Task<int> ProcessFilesAsync3()
	{
		var filesPath = "D:/files/";
		var totalLength = 0;
		List<Task> tasks = new();
		for (int i = 1; i <= 5; i++)
		{
			var filePath = filesPath + $"{i}.txt";

			// wywołanie Task.Run() bez await opowoduje że wykonanie zostaje opóźnione do czasu wywołania z await
			var task = Task.Run(() =>
			{
				using (var reader = new StreamReader(filePath, Encoding.UTF8))
				{
					var fileContent = reader.ReadToEnd();
					totalLength += fileContent.Length;
					// processing file content..
				}
			});
			tasks.Add(task);
		}
		await Task.WhenAll(tasks);
		return totalLength;
	}

	#endregion asynchronous 3 - with parallel tasks
}