using System.Collections;
using System.Collections.Generic;
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
		[Test]
		public void HandleSaveChanges_delegate_saving_to_the_ListManager()
		{
			const int userListId = 1;
			const string newTitle = "new title";
			const string newDescription = "description";

			Mock<ISingleListView> viewMock = new Mock<ISingleListView>();
			Mock<IListManager> listManagerMock = new Mock<IListManager>();
			SingleListPresenter presenter = new SingleListPresenter(viewMock.Object, listManagerMock.Object);

			viewMock.Setup(x => x.UserListId).Returns(userListId);
			viewMock.Setup(x => x.ListTitle).Returns(newTitle);
			viewMock.Setup(x => x.ListDescription).Returns(newDescription);

			presenter.HandleSaveChanges();

			listManagerMock.Verify(x => x.SaveChanges(userListId, newTitle, newDescription));
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

	class ViewStub : ISingleListView
	{
		public int UserListId { get; set; }
		public string ListTitle { get; set; }
		public string ListDescription { get; set; }
		public string NewItemTitle { get; set; }
		public void DisplayItems(IEnumerable<ItemViewModel> listItems)
		{
			throw new System.NotImplementedException();
		}
	}

	class ListManagerMock : IListManager
	{
		private int userListId;
		private string newTitle;
		private string newDescription;

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

		public IEnumerable<Item> GetListItems(int listId)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<UserList> GetUserLists(string userName)
		{
			throw new System.NotImplementedException();
		}

		public void AddNewList(string userName, string newListName)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteList(int userListId)
		{
			throw new System.NotImplementedException();
		}

		public void AddItemToList(int userListId, string listItem)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteItem(int itemId)
		{
			throw new System.NotImplementedException();
		}

		public UserList GetList(int userListId)
		{
			throw new System.NotImplementedException();
		}

		public void SaveChanges(int userListId, string newTitle, string newDescription)
		{
			this.userListId = userListId;
			this.newTitle = newTitle;
			this.newDescription = newDescription;
		}
	}
}