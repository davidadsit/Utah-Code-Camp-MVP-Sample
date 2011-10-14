using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebSiteLogic.Presenters;
using WebSiteLogic.ViewModel;
using WebSiteLogic.Views;

namespace WebSite.MyLists
{
	public partial class SingleList : Page, ISingleListView
	{
		private string itemCommandId;
		private SingleListPresenter presenter;

		public int UserListId
		{
			get
			{
				int userListId;
				int.TryParse(Request.QueryString["UserListId"], out userListId);
				return userListId;
			}
		}

		public string ListTitle
		{
			get { return ListTitleTextbox.Text; }
			set { ListDescriptionTextbox.Text = value; }
		}

		public string ListDescription
		{
			get { return ListDescriptionTextbox.Text; }
			set { ListDescriptionTextbox.Text = value; }
		}

		public string NewItemTitle
		{
			get { return NewItemTitleTextBox.Text; }
		}

		public int ItemIdToDelete
		{
			get { return int.Parse(itemCommandId); }
		}

		public void DisplayItems(IEnumerable<ItemViewModel> listItems)
		{
			ListItemsRepeater.DataSource = listItems;
			ListItemsRepeater.DataBind();
		}

		public void SendUserToListsPage()
		{
			Response.Redirect("AllLists.aspx");
		}

		protected void AddNewItemButton_Click(object sender, EventArgs e)
		{
			presenter.HandleAddNewItem();
		}

		protected void ListItemsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			itemCommandId = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Delete":
					presenter.HandleDeleteItem();
					break;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			presenter = new SingleListPresenter(this, new ListManager());
			presenter.HandlePageLoad();
		}

		protected void SaveChangesLinkButton_Click(object sender, EventArgs e)
		{
			presenter.HandleSaveChanges();
		}
	}
}