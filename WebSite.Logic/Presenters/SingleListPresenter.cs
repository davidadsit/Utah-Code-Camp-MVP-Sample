using System.Collections.Generic;
using Business;
using Common;
using WebSite.Logic.Views;

namespace WebSite.Logic.Presenters
{
	public class SingleListPresenter
	{
		private readonly ISingleListView view;
		private readonly IListManager listManager;

		public SingleListPresenter(ISingleListView view, IListManager listManager)
		{
			this.view = view;
			this.listManager = listManager;
		}

		public void HandleSaveChanges()
		{
			listManager.SaveChanges(view.UserListId, view.ListTitle, view.ListDescription);
		}

		public void HandleAddNewItem()
		{
			int userListId = view.UserListId;
			listManager.AddItemToList(userListId, view.NewItemTitle);
			IEnumerable<Item> listItems = listManager.GetListItems(userListId);
			view.DisplayListItems(listItems);
		}
	}
}