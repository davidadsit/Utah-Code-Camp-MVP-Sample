using System;

namespace Common
{
	public class Item
	{
		public int ItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public int UserListId { get; set; }
	}
}