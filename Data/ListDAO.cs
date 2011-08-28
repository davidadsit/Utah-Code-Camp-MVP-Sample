using System.Collections.Generic;
using System.Linq;
using Common;

namespace Data
{
	public class ListDAO
	{
		private static readonly List<Item> listItems = new List<Item>();
		private static readonly List<UserList> userLists = new List<UserList>();

		static ListDAO()
		{
			userLists.Add(new UserList {UserListId = 1, Owner = "Dave", Title = "Books to Read", Description = "Learning is fun. Keep the WIP low so you don't get overwhelmed."});
			listItems.Add(new Item {ItemId = 1, Title = "Pragmatic Thinking and Learning", UserListId = 1});
			listItems.Add(new Item {ItemId = 2, Title = "Seven Languages in Seven Weeks", UserListId = 1});
		
			userLists.Add(new UserList {UserListId = 2, Owner = "Dave", Title = "Nikki's Grocery List", Description = "Pick this stuff up on the way home tonight, please."});
			listItems.Add(new Item {ItemId = 3, Title = "Milk", UserListId = 2});
			listItems.Add(new Item {ItemId = 4, Title = "Cheese", UserListId = 2});
			listItems.Add(new Item {ItemId = 5, Title = "Ham", UserListId = 2});
		}

		public void AddItemToList(int userListId, string listItem)
		{
			int itemId = listItems.Max(x => x.ItemId) + 1;
			Item item = new Item
			            	{
			            		ItemId = itemId,
			            		Title = listItem,
			            		UserListId = userListId
			            	};
			listItems.Add(item);
		}

		public void AddNewList(string userName, string newListName)
		{
			int userListId = userLists.Max(x => x.UserListId) + 1;
			UserList userList = new UserList
			                    	{
			                    		Owner = userName,
			                    		Title = newListName,
			                    		UserListId = userListId
			                    	};
			userLists.Add(userList);
		}

		public void DeleteList(int userListId)
		{
			listItems.RemoveAll(x => x.UserListId == userListId);
			userLists.RemoveAll(x => x.UserListId == userListId);
		}

		public IEnumerable<Item> GetListItems(int listId)
		{
			return listItems.Where(x => x.UserListId == listId);
		}

		public IEnumerable<UserList> GetUserLists(string userName)
		{
			return userLists.Where(x => x.Owner == userName);
		}

		public void DeleteItem(int itemId)
		{
			listItems.RemoveAll(x => x.ItemId == itemId);
		}

		public UserList GetList(int userListId)
		{
			return userLists.Single(x => x.UserListId == userListId);
		}

		public void SaveChanges(int userListId, string newTitle, string newDescription)
		{
			UserList userList = GetList(userListId);
			userList.Title = newTitle;
			userList.Description = newDescription;
		}
	}
}