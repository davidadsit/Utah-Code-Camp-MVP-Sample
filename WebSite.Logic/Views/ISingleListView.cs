using System.Collections.Generic;
using Common;

namespace WebSite.Logic.Views
{
	public interface ISingleListView
	{
		int UserListId { get; }
		string ListTitle { get; }
		string ListDescription { get; }
		string NewItemTitle { get; }
		void DisplayListItems(IEnumerable<Item> listItems);
	}
}