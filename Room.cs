namespace HotelApp
{
	class Room
	{
		public int Id { get; set; }
		public string number { get; set; }
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		public DateTime dateCheckIn { get; set; } // дата в'їзду
		public DateTime dateCheckOut { get; set; } // дата виїзду 

	}
}
