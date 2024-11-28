using DateOverlap.ConsoleApp;

var bookedReservations = GetBookedReservations();
DisplayReservations(bookedReservations);

Console.WriteLine("Insert new booking start date: (yyyy-MM-dd)");

string startDateString = Console.ReadLine();
DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", null);

Console.WriteLine("Insert new booking end date: (yyyy-MM-dd)");
string endDateString = Console.ReadLine();
DateTime endDate = DateTime.ParseExact(endDateString, "yyyy-MM-dd", null);

bool isNewReservationPossible = IsNewReservationPossible(startDate, endDate, bookedReservations);

Console.WriteLine(isNewReservationPossible ? "Reservation booked" : "Select other booking dates");

static bool IsNewReservationPossible(DateTime startDate, DateTime endDate, List<Reservation> bookedReservations)
{
	foreach (Reservation reservation in bookedReservations)
	{
		if (reservation.From.Date >= startDate.Date && reservation.To.Date <= endDate.Date
			|| (startDate.Date >= reservation.From.Date && startDate.Date <= reservation.To.Date)
			|| (endDate.Date >= reservation.From.Date && endDate.Date <= reservation.To.Date))
		{
			return false;
		}
	}
	return true;
}

static void DisplayReservations(List<Reservation> bookedReservations)
{
	Console.WriteLine("Booked reservations:");
	foreach (var bookedReservation in bookedReservations)
	{
		Console.WriteLine($"From: {bookedReservation.From:yyyy-MM-dd}, To: {bookedReservation.To:yyyy-MM-dd}");
	}
}

static List<Reservation> GetBookedReservations()
	=> [
		new Reservation(new DateTime(2021, 6, 10), new DateTime(2021, 6, 12)),
		new Reservation(new DateTime(2021, 6, 19), new DateTime(2021, 6, 20)),
		new Reservation(new DateTime(2021, 6, 24), new DateTime(2021, 6, 26)),
		new Reservation(new DateTime(2021, 7, 24), new DateTime(2021, 7, 25)),
	];