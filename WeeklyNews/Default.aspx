<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeeklyNews._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Category/Categorys.aspx">Category</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/View/News/News.aspx">News</asp:HyperLink>
</asp:Content>
