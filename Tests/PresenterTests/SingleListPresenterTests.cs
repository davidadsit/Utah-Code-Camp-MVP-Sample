using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Common;
using Moq;
using NUnit.Framework;
using WebSiteLogic.Presenters;
using WebSiteLogic.ViewModel;
using WebSiteLogic.Views;

namespace Tests.PresenterTests
{
	[TestFixture]
	public class SingleListPresenterTests
	{
		private const string NEW_TITLE = "new title";
		private const string NEW_DESCRIPTION = "description";
		private const int USER_LIST_ID = 1;
		private const string NEW_LIST_ITEM = "new list item";

		private Mock<IListManager> listManagerMock;
		private SingleListPresenter presenter;
		private Mock<ISingleListView> viewMock;

		[SetUp]
		public void SetUp()
		{
			viewMock = new Mock<ISingleListView>();
			listManagerMock = new Mock<IListManager>();
			presenter = new SingleListPresenter(viewMock.Object, listManagerMock.Object);
		}

		[Test]
		public void HandleAddNewItem_delegates_adding_to_the_ListManager()
		{
			viewMock.Setup(x => x.UserListId).Returns(USER_LIST_ID);
			viewMock.Setup(x => x.NewItemTitle).Returns(NEW_LIST_ITEM);

			presenter.HandleAddNewItem();

			listManagerMock.Verify(x => x.AddItemToList(USER_LIST_ID, NEW_LIST_ITEM));
		}

		[Test]
		public void HandleAddNewItem_diplays_the_list_of_itemviewmodels_including_the_new_item()
		{
			ViewStub viewMock = new ViewStub();
			ListManagerMock listManagerMock = new ListManagerMock();
			SingleListPresenter presenter = new SingleListPresenter(viewMock, listManagerMock);
			viewMock.UserListId = USER_LIST_ID;
			viewMock.NewItemTitle = NEW_LIST_ITEM;

			presenter.HandleAddNewItem();

			viewMock.DisplayedListItems.Single(x => x.Title == NEW_LIST_ITEM);
		}

		[Test]
		public void HandleSaveChanges_delegate_saving_to_the_ListManager()
		{
			viewMock.Setup(x => x.UserListId).Returns(USER_LIST_ID);
			viewMock.Setup(x => x.ListTitle).Returns(NEW_TITLE);
			viewMock.Setup(x => x.ListDescription).Returns(NEW_DESCRIPTION);

			presenter.HandleSaveChanges();

			listManagerMock.Verify(x => x.SaveChanges(USER_LIST_ID, NEW_TITLE, NEW_DESCRIPTION));
		}

		[Test]
		public void HandleSaveChanges_delegate_saving_to_the_ListManager_using_hand_rolled_test_doubles()
		{
			const int userListId = 1;
			const string newTitle = "new title";
			const string newDescription = "description";

			ViewStub viewMock = new ViewStub();
			ListManagerMock listManagerMock = new ListManagerMock();
			SingleListPresenter presenter = new SingleListPresenter(viewMock, listManagerMock);

			viewMock.UserListId = userListId;
			viewMock.ListTitle = newTitle;
			viewMock.ListDescription = newDescription;

			presenter.HandleSaveChanges();

			Assert.AreEqual(userListId, listManagerMock.UserListId);
			Assert.AreEqual(newTitle, listManagerMock.NewTitle);
			Assert.AreEqual(newDescription, listManagerMock.NewDescription);
		}
	}

	internal class ViewStub : ISingleListView
	{
		public int UserListId { get; set; }
		public string ListTitle { get; set; }
		public string ListDescription { get; set; }
		public string NewItemTitle { get; set; }

		public void DisplayItems(IEnumerable<ItemViewModel> listItems)
		{
			DisplayedListItems = listItems;
		}

		public IEnumerable<ItemViewModel> DisplayedListItems { get; set; }
	}

	internal class ListManagerMock : IListManager
	{
		private string newDescription;
		private string newTitle;
		private int userListId;
		private List<Item> listItems = new List<Item>();

		public string NewDescription
		{
			get { return newDescription; }
		}

		public string NewTitle
		{
			get { return newTitle; }
		}

		public int UserListId
		{
			get { return userListId; }
		}

		public void AddItemToList(int userListId, string listItem)
		{
			listItems.Add(new Item(){Title = listItem});
		}

		public void AddNewList(string userName, string newListName)
		{
			throw new NotImplementedException();
		}

		public void DeleteItem(int itemId)
		{
			throw new NotImplementedException();
		}

		public void DeleteList(int userListId)
		{
			throw new NotImplementedException();
		}

		public UserList GetList(int userListId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Item> GetListItems(int listId)
		{
			return listItems;
		}

		public IEnumerable<UserList> GetUserLists(string userName)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges(int userListId, string newTitle, string newDescription)
		{
			this.userListId = userListId;
			this.newTitle = newTitle;
			this.newDescription = newDescription;
		}
	}
}