using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Common;

namespace WebSite.MyLists
{
	public partial class AllLists : Page
	{
		private readonly ListManager listManager = new ListManager();

		protected void AddNewListButton_Click(object sender, EventArgs e)
		{
			listManager.AddNewList(User.Identity.Name, NewListNameTextBox.Text);
			NewListNameTextBox.Text = "New List";
			DisplayLists();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			UserNameLabel.Text = User.Identity.Name;
			DisplayLists();
		}

		protected void UserListsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "Delete":
					new ListManager().DeleteList(int.Parse(e.CommandArgument.ToString()));
					DisplayLists();
					break;
			}
		}

		private void DisplayLists()
		{
			IEnumerable<UserList> userLists = listManager.GetUserLists(User.Identity.Name);
			UserListsRepeater.DataSource = userLists;
			UserListsRepeater.DataBind();
		}
	}
}