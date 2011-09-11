using Business;
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
	}
}