using Business;
using Moq;
using NUnit.Framework;
using WebSite.Logic.Presenters;
using WebSite.Logic.Views;

namespace Tests.PresenterTests
{
	[TestFixture]
	public class SingleListPresenterTests
	{
		[Test]
		public void HandleSaveChanges_delegates_to_ListManager()
		{
			//Arrange
			Mock<ISingleListView> viewMock = new Mock<ISingleListView>();
			Mock<IListManager> listManagerMock = new Mock<IListManager>();
			SingleListPresenter presenter = new SingleListPresenter(viewMock.Object, listManagerMock.Object);

			//Act
			presenter.HandleSaveChanges();

			//Assert
			listManagerMock.Verify(x => x.SaveChanges(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
		}
	}
}