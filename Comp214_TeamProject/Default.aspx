<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp214_TeamProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ub-container">
        <%-- Model list --%>
        <asp:Repeater ID="BookRepeater" runat="server">
            <ItemTemplate>
                <div class="col-sm-4">
                    <div class="ub-book-outer-border">
                        <div class="ub-book-content">
                            <div class="ub-book-image">
                                <a href="BookDetail.aspx?model=<%# Eval("PrimaryKey.Key") %>">
                                    <asp:Image ID="BookImage"
                                        AlternateText='<%# Eval("Title") %>'
                                        ImageUrl='<%# Eval("ImageUrl01") %>'
                                        CssClass="ub-book-image-small"
                                        runat="server"
                                        ToolTip="Click on the image to see the book details." />
                                </a>
                            </div>
                            <div class="ub-boook-name">
                                <a href="BookDetail.aspx?isbn=<%# Eval("PrimaryKey.Key") %>">
                                    <asp:Label ID="BookLabel" Text='<%# Eval("Title") %>' runat="server" /></span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
