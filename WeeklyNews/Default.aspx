<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeeklyNews._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Category/Categorys.aspx">Category</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/View/News/News.aspx">News</asp:HyperLink>
    </div>
    <div>
        <asp:GridView ID="gvTopFive" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="CategoryTitle" HeaderText="CategoryTitle" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField HeaderText="Image">
                     <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# GetImage(Eval("Image")) %>' Height="150px" Width="150px" />
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
