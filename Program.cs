using BL_HotelApp;
using HotelApp;

internal class Program
{
	private static void Main(string[] args)
	{
		#region createRooms
		//using (var context = new ApplicationContext())
		//{
		//	if (!context.Rooms.Any()) // Перевіряємо, чи немає вже даних
		//	{
		//		var rooms = Enumerable.Range(1, 50)
		//			.Select(i => new Room { number = i.ToString() }) // Генеруємо 50 кімнат
		//			.ToList();

		//		context.Rooms.AddRange(rooms);
		//		context.SaveChanges();
		//	}
		//}
		#endregion

		Console.WriteLine("Змінити кімнату? (0 - Ні | 1 - так)");
		int answer = Convert.ToInt16(Console.ReadLine());
		if (answer == 1)
		{
			EditRoom();
		}

		using (ApplicationContext db = new ApplicationContext())
		{
			var users = db.Rooms.ToList();
			Console.WriteLine("Objects:");
			foreach (Room r in users)
			{
				string name = r.firstName;
				if (name != null)
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}
				DateOnly dateOnlyIn = DateOnly.FromDateTime(r.dateCheckIn);
				DateOnly dateOnlyOut = DateOnly.FromDateTime(r.dateCheckOut);
				Console.WriteLine($"ID:{r.Id}|{r.firstName} {r.lastName}| Room:{r.number} | {dateOnlyIn}-{dateOnlyOut}");
			}
		}
	}

	private static void EditRoom()
	{
		try
		{
			DateTime dateCheckIn;
			DateTime dateCheckOut;
			Console.Write("Номер кімнати:");
			string numberRoom = Console.ReadLine();
			Console.Write("Ім'я клієнта:");
			string firstName = Console.ReadLine();
			Console.Write("Прізвіще клієнта:");
			string lastName = Console.ReadLine();
			Console.Write("Дата в'єзда:");
			dateCheckIn = Convert.ToDateTime(Console.ReadLine());
			Console.Write("Дата виєзда:");
			dateCheckOut = Convert.ToDateTime(Console.ReadLine());

			Controller controller = new Controller();
			controller.SetRoom(numberRoom, firstName, lastName, dateCheckIn, dateCheckOut);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Помилка {ex.Message}");
		}

	}
}