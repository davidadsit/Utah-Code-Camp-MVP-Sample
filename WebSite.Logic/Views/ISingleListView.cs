using System.Collections.Generic;
using Common;
using WebSite.Logic.Presenters;
using WebSite.Logic.ViewModels;

namespace WebSite.Logic.Views
{
	public interface ISingleListView
	{
		int UserListId { get; }
		string ListTitle { get; }
		string ListDescription { get; }
		string NewItemTitle { get; }
		void DisplayListItems(IEnumerable<ListItemViewModel> listItems);
	}
}