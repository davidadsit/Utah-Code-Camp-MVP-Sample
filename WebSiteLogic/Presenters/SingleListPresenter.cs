using System.Collections.Generic;
using System.Linq;
using Business;
using Common;
using WebSiteLogic.ViewModel;
using WebSiteLogic.Views;

namespace WebSiteLogic.Presenters
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
			DisplayListItems(userListId);
		}

		public void HandleDeleteItem()
		{
			int itemIdToDelete = view.ItemIdToDelete;
			listManager.DeleteItem(itemIdToDelete);
			DisplayListItems(view.UserListId);
		}

		public void HandlePageLoad()
		{
			if (view.UserListId == 0)
			{
				view.SendUserToListsPage();
				return;
			}
			DisplayListItems(view.UserListId);
			if (view.IsPostBack)
			{
				return;
			}
			UserList userList = listManager.GetList(view.UserListId);
			view.ListTitle = userList.Title;
			view.ListDescription = userList.Description;
		}

		public void HandleSaveChanges()
		{
			listManager.SaveChanges(view.UserListId, view.ListTitle, view.ListDescription);
		}

		private static ItemViewModel ProjectItemToViewModel(Item x)
		{
			ItemViewModel projectItemToViewModel =
				new ItemViewModel
					{
						Title = x.Title,
						ItemId = x.ItemId.ToString(),
					};
			return projectItemToViewModel;
		}

		private void DisplayListItems(int userListId)
		{
			IEnumerable<Item> listItems = listManager.GetListItems(userListId);
			IEnumerable<ItemViewModel> itemViewModels = listItems.Select(ProjectItemToViewModel);
			view.DisplayItems(itemViewModels);
		}
	}
}