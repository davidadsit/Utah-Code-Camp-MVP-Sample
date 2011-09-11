using WebSite.Logic.Views;

namespace WebSite.Logic.Presenters
{
	public class SingleListPresenter
	{
		private readonly ISingleListView view;

		public SingleListPresenter(ISingleListView view)
		{
			this.view = view;
		}
	}
}