<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="SingleList.aspx.cs" Inherits="WebSite.MyLists.Personal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	Title:<br />
	<asp:TextBox runat="server" ID="ListTitleTextbox" /><br />
	Description:<br />
	<asp:TextBox runat="server" ID="ListDescriptionTextbox" TextMode="MultiLine" Columns="60" Rows="5" /><br />
	<asp:LinkButton runat="server" ID="SaveChangesLinkButton" OnClick="SaveChangesLinkButton_Click">Save</asp:LinkButton>
	<hr />
	<asp:Repeater runat="server" ID="ListItemsRepeater" OnItemCommand="ListItemsRepeater_ItemCommand">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
		<ItemTemplate>
			<li><%# Eval("Title") %>
				<asp:LinkButton runat="server" ID="DeleteList" ToolTip="Delete List" CssClass="small red undecorated"
					CommandName="Delete" CommandArgument='<%# Eval("ItemId") %>'>X</asp:LinkButton></li>
		</ItemTemplate>
	</asp:Repeater>
	Add a new item:
	<asp:TextBox runat="server" ID="NewItemTitleTextBox">New Item</asp:TextBox>
	<asp:LinkButton runat="server" ID="AddNewItemButton" OnClick="AddNewItemButton_Click">Add</asp:LinkButton>
</asp:Content>
