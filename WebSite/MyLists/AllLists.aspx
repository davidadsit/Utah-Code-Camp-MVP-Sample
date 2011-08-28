<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="AllLists.aspx.cs" Inherits="WebSite.MyLists.AllLists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h3>
		<asp:Label ID="UserNameLabel" runat="server" />, here are your current lists:</h3>
	<asp:Repeater runat="server" ID="UserListsRepeater" OnItemCommand="UserListsRepeater_ItemCommand">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
		<ItemTemplate>
			<li><a href='SingleList.aspx?UserListId=<%# Eval("UserListId") %>'>
				<%# Eval("Title") %></a>
				<asp:LinkButton runat="server" ID="DeleteList" ToolTip="Delete List" CssClass="small red undecorated"
					CommandName="Delete" CommandArgument='<%# Eval("UserListId") %>'>X</asp:LinkButton></li>
		</ItemTemplate>
	</asp:Repeater>
	Add a new list:
	<asp:TextBox runat="server" ID="NewListNameTextBox">New List</asp:TextBox>
	<asp:LinkButton runat="server" ID="AddNewListButton" OnClick="AddNewListButton_Click">Add</asp:LinkButton>
</asp:Content>
