using Business;
using Moq;
using NUnit.Framework;
using WebSiteLogic.Presenters;
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
	}
}