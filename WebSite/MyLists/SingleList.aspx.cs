using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Common;
using WebSite.Logic.Presenters;
using WebSite.Logic.ViewModels;
using WebSite.Logic.Views;

namespace WebSite.MyLists
{
	public partial class SingleList : Page, ISingleListView
	{
		private SingleListPresenter presenter;

		public int UserListId
		{
			get { return int.Parse(Request.QueryString["UserListId"]); }
		}

		public string ListTitle
		{
			get { return ListTitleTextbox.Text; }
		}

		public string ListDescription
		{
			get { return ListDescriptionTextbox.Text; }
		}

		public string NewItemTitle
		{
			get { return NewItemTitleTextBox.Text; }
		}

		public void DisplayListItems(IEnumerable<ListItemViewModel> listItems)
		{
			ListItemsRepeater.DataSource = listItems;
			ListItemsRepeater.DataBind();
		}

		protected void AddNewItemButton_Click(object sender, EventArgs e)
		{
			presenter.HandleAddNewItem();
		}

		protected void ListItemsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "Delete":
					ListManager listManager = new ListManager();
					listManager.DeleteItem(int.Parse(e.CommandArgument.ToString()));
					string listId = Request.QueryString["UserListId"];
					ListItemsRepeater.DataSource = listManager.GetListItems(int.Parse(listId));
					ListItemsRepeater.DataBind();
					break;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			presenter = new SingleListPresenter(this, new ListManager());
			string listId = Request.QueryString["UserListId"];
			if (string.IsNullOrEmpty(listId))
			{
				Response.Redirect("AllLists.aspx");
				return;
			}
			ListManager listManager = new ListManager();
			IEnumerable<Item> listItems = listManager.GetListItems(int.Parse(listId));
			ListItemsRepeater.DataSource = listItems;
			ListItemsRepeater.DataBind();
			if (IsPostBack)
			{
				return;
			}
			UserList userList = listManager.GetList(int.Parse(listId));
			ListTitleTextbox.Text = userList.Title;
			ListDescriptionTextbox.Text = userList.Description;
		}

		protected void SaveChangesLinkButton_Click(object sender, EventArgs e)
		{
			presenter.HandleSaveChanges();
		}
	}
}