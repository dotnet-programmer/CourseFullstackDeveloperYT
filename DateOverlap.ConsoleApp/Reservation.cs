namespace DateOverlap.ConsoleApp;

public class Reservation(DateTime @from, DateTime to)
{
	public DateTime From { get; set; } = @from;
	public DateTime To { get; set; } = to;
}