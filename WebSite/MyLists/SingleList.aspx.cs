using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Common;

namespace WebSite.MyLists
{
	public partial class Personal : Page
	{
		protected void AddNewItemButton_Click(object sender, EventArgs e)
		{
			ListManager listManager = new ListManager();
			string listId = Request.QueryString["UserListId"];
			listManager.AddItemToList(int.Parse(listId), NewItemTitleTextBox.Text);
			IEnumerable<Item> listItems = listManager.GetListItems(int.Parse(listId));
			ListItemsRepeater.DataSource = listItems;
			ListItemsRepeater.DataBind();
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
			ListManager listManager = new ListManager();
			string listId = Request.QueryString["UserListId"];
			listManager.SaveChanges(int.Parse(listId), ListTitleTextbox.Text, ListDescriptionTextbox.Text);
		}
	}
}