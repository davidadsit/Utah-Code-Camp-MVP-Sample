namespace WebSiteLogic.Views
{
	public interface ISingleListView
	{
		int UserListId { get; }
		string ListTitle { get; }
		string ListDescription { get; }
	}
}