using System.Collections.Generic;
using Common;
using WebSiteLogic.Presenters;
using WebSiteLogic.ViewModel;

namespace WebSiteLogic.Views
{
	public interface ISingleListView
	{
		int UserListId { get; }
		string ListTitle { get; }
		string ListDescription { get; }
		string NewItemTitle { get; }
		void DisplayItems(IEnumerable<ItemViewModel> listItems);
	}
}