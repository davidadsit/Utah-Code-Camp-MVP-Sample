using System.Collections.Generic;
using System.Linq;
using Business;
using Common;
using WebSite.Logic.ViewModels;
using WebSite.Logic.Views;

namespace WebSite.Logic.Presenters
{
	public class SingleListPresenter
	{
		private readonly IListManager listManager;
		private readonly ISingleListView view;

		public SingleListPresenter(ISingleListView view, IListManager listManager)
		{
			this.view = view;
			this.listManager = listManager;
		}

		public void HandleAddNewItem()
		{
			int userListId = view.UserListId;
			listManager.AddItemToList(userListId, view.NewItemTitle);
			IEnumerable<Item> listItems = listManager.GetListItems(userListId);
			view.DisplayListItems(listItems.Select(GetListItemViewModel));
		}

		public void HandleSaveChanges()
		{
			listManager.SaveChanges(view.UserListId, view.ListTitle, view.ListDescription);
		}

		private static ListItemViewModel GetListItemViewModel(Item item)
		{
			return new ListItemViewModel {ItemId = item.ItemId, Title = item.Title};
		}
	}
}