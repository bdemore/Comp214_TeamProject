<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp214_TeamProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ub-container">
        <%-- Error Panel --%>
        <asp:Panel ID="ErrorPanel" runat="server" CssClass="register-error-message-hidden">
            <div><%= message %></div>
        </asp:Panel>

        <%-- Model list --%>
        <asp:Repeater ID="BookRepeater" runat="server">
            <ItemTemplate>
                <div class="col-sm-4">
                    <div class="ub-book-outer-border">
                        <div class="ub-book-content">
                            <div class="ub-book-image">
                                <a href="BookDetail.aspx?isbn=<%# Eval("PrimaryKey.Key") %>">
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
                            <% if (null != Session["LoggedUser"]) { %>
                                <div class="ub-book-button-holder">
                                    <asp:Button 
                                        ID="ReserveButton"
                                        Text="Reserve"
                                        CommandArgument='<%# Eval("PrimaryKey.Key") %>'
                                        CssClass="ub-book-button"
                                        OnClick="ReserveButton_Click"
                                        runat="server" />
                                </div>
                            <% } %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
