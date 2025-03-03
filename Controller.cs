using HotelApp;

namespace BL_HotelApp
{
	class Controller
	{
		public void SetRoom(string numberroom, string firstname, string lastname, DateTime datecheckin, DateTime datecheckout)
		{
			#region getAllRooms
			//List<Room> rooms;

			//using (ApplicationContext context = new ApplicationContext())
			//{
			//	rooms = context.Rooms.ToList();

			//	foreach (var room in rooms)
			//	{
			//		Console.WriteLine($"Кімната {room.number}: {room.firstName} {room.lastName}");
			//	}
			//}
			#endregion


			using (ApplicationContext db = new ApplicationContext())
			{
				var room = db.Rooms.FirstOrDefault(r => r.number == numberroom);

				if (room != null)
				{
					room.firstName = firstname;
					room.lastName = lastname;
					room.dateCheckIn = datecheckin;
					room.dateCheckOut = datecheckout;

					db.SaveChanges();
				}
			}

		}
	}
}
