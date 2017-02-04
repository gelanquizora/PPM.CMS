<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="CoverGrid.aspx.cs" Inherits="Master_CoverGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" width="80%" runat="server" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" DataKeyNames="CoverID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"><Columns>
<asp:CommandField ShowSelectButton="True" /><asp:BoundField DataField="CoverID" HeaderText="CoverID" InsertVisible="False" SortExpression="CoverID" />
<asp:BoundField DataField="CoverTitle" HeaderText="CoverTitle" InsertVisible="False" SortExpression="CoverTitle" />
<asp:BoundField DataField="CoverPage" HeaderText="CoverPage" InsertVisible="False" SortExpression="CoverPage" />
<asp:BoundField DataField="CoverFileName" HeaderText="CoverFileName" InsertVisible="False" SortExpression="CoverFileName" />
<asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" InsertVisible="False" SortExpression="CreatedBy" />
<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" InsertVisible="False" SortExpression="CreatedDate" />
<asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" InsertVisible="False" SortExpression="ModifiedBy" />
<asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" InsertVisible="False" SortExpression="ModifiedDate" />
</Columns>
</asp:GridView>
<br/><br/><asp:LinkButton ID="lbCreate" Text="New" runat="server" PostBackUrl="~/Create_Cover.aspx">New</asp:LinkButton><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" SelectCommand="SELECT [CoverID],[CoverTitle],[CoverPage],[CoverFileName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate] FROM Cover"></asp:SqlDataSource>
</asp:Content>

