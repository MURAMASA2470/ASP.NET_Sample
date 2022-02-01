<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    	<style type="text/css">
		
		tr.Header th {
			padding: 2px 18px 2px 18px;
		}

		tr.Header th a {
			color: #000;
			text-decoration: none;
			font-weight: normal;
		}

		tr.Header th a:hover {
			color: #f00;
			text-decoration: underline;
			font-weight: normal;
		}

		th.sortedAscHeader,
		th.sortedDscHeader {
			background-repeat: no-repeat;
			background-position: right;
			padding-right:18px;
		}

		th.sortedAscHeader {
			content: '▼';
		}

		th.sortedDscHeader {
			content: '▲';
		}
	</style>

    <asp:Label runat="server" Text="部門" />
    <asp:DropDownList ID="DropDown" runat="server" OnSelectedIndexChanged="DropDown_SelectedIndexChanged" />

    <asp:GridView ID="GridList" runat="server" AutoGenerateColumns="false" AllowSorting="true" OnSorting="GridList_Sorting" AllowPaging="true" PageSize="3">
	    <SortedAscendingHeaderStyle CssClass="sortedAscHeader"/>
	    <SortedDescendingHeaderStyle CssClass="sortedDscHeader" />
	    <HeaderStyle CssClass="Header" />
        <Columns>
            <asp:BoundField DataField="DATE" HeaderText="年月" DataFormatString="{0:yyyy/MM}"
                SortExpression="DATE" AccessibleHeaderText="aaa" />
            <asp:BoundField DataField="BMCD" HeaderText="部門コード"
                SortExpression="BMCD" />
            <asp:BoundField DataField="ORNM" HeaderText="発注先名"
                SortExpression="ORNM" />
            <%--<asp:TemplateField SortExpression="DATE">
                <HeaderTemplate>年月</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "DATE")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>--%>
<%--            <asp:TemplateField SortExpression="BMCD">
                <HeaderTemplate>部門コード</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "BMCD")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="ORNM">
                <HeaderTemplate>発注先名</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "ORNM")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>

</asp:Content>
