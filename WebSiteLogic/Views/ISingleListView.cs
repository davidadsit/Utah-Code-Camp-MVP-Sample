using System.Collections.Generic;
using WebSiteLogic.ViewModel;

namespace WebSiteLogic.Views
{
	public interface ISingleListView
	{
		int UserListId { get; }
		string ListTitle { get; set; }
		string ListDescription { get; set; }
		string NewItemTitle { get; }
		int ItemIdToDelete { get; }
		bool IsPostBack { get; }
		void DisplayItems(IEnumerable<ItemViewModel> listItems);
		void SendUserToListsPage();
	}
}