<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="Comp214_TeamProject.BookDetail" %>

<%@ Import Namespace="Comp214_TeamProject.Database.Models" %>

<asp:Content ID="BookDetailContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Error Panel --%>
    <asp:Panel ID="ErrorPanel" runat="server" CssClass="register-error-message-hidden">
        <div><%= message %></div>
    </asp:Panel>

    <div class="col-sm-12 ub-book-detail-container">
        <div class="col-sm-5 ub-book-image-container">
            <div class="ub-book-image-large-container">
                <asp:Image ID="BookImage" CssClass="ub-book-image-large" runat="server" />
            </div>
            <div class="ub-book-image-all-thumbnails">
                <%if (!string.IsNullOrEmpty(book.ImageUrl01)) { %>
                <div class="ub-book-image-thumbnail-container">
                    <asp:ImageButton ID="BookUrl01ImageButton" CssClass="ub-book-image-thumbnail" runat="server" OnClick="BookUrl02ImageButton_Click" CommandArgument="1" />
                </div>
                <% } %>

                <% if (!string.IsNullOrEmpty(book.ImageUrl02)) { %>
                <div class="ub-book-image-thumbnail-container">
                    <asp:ImageButton ID="BookUrl02ImageButton" CssClass="ub-book-image-thumbnail" runat="server" OnClick="BookUrl02ImageButton_Click" CommandArgument="2" />
                </div>
                <% } %>

                <% if (!string.IsNullOrEmpty(book.ImageUrl03)) { %>
                <div class="ub-book-image-thumbnail-container">
                    <asp:ImageButton ID="BookUrl03ImageButton" CssClass="ub-book-image-thumbnail" runat="server" OnClick="BookUrl02ImageButton_Click" CommandArgument="3" />
                </div>
                <% } %>

                <% if (!string.IsNullOrEmpty(book.ImageUrl04)) { %>
                <div class="ub-book-image-thumbnail-container">
                    <asp:ImageButton ID="BookUrl04ImageButton" CssClass="ub-book-image-thumbnail" runat="server" OnClick="BookUrl02ImageButton_Click" CommandArgument="4" />
                </div>
                <% } %>

                <% if (!string.IsNullOrEmpty(book.ImageUrl05)) { %>
                <div class="ub-book-image-thumbnail-container">
                    <asp:ImageButton ID="BookUrl05ImageButton" CssClass="ub-book-image-thumbnail" runat="server" OnClick="BookUrl02ImageButton_Click" CommandArgument="5" />
                </div>
                <% } %>
            </div>
            <% if ((null != Session["LoggedUser"]) && book.IsAvailable) { %>
                <div class="ub-book-button-holder">
                    <asp:Button
                        ID="BookReserveButton"
                        Text="Reserve"
                        CssClass="ub-book-button"
                        OnClick="ReserveButton_Click"
                        runat="server" />
                </div>

                <% if ((Session["LoggedUser"] as User).Role == "ADMIN") { %>
                    <div class="ub-book-button-holder">
                        <asp:Button
                            ID="BookUpdateButton"
                            Text="Update Book"
                            CssClass="ub-book-button"
                            OnClick="BookUpdateButton_Click"
                            runat="server" />
                    </div>
                <% } %>
            <% } %>
        </div>
        <div class="col-sm-7 ub-book-details-text">
            <div class="ub-book-details-text-title">
                <span><%= book.Title %></span>
            </div>
            <div class="ub-book-details-text-description">
                <span><%= book.Description %></span>
            </div>
            <div class="ub-book-detail-text-details">
                Product Details
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Pages: </span>
                </div>
                <div class="col-sm-9">
                    <span><%= book.Pages %></span>
                </div>
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Publisher: </span>
                </div>
                <div class="col-sm-9">
                    <span><%= book.Publisher.Name %></span>
                </div>
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">ISBN-13: </span>
                </div>
                <div class="col-sm-9">
                    <span><%= book.PrimaryKey.Key %></span>
                </div>
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Edition: </span>
                </div>
                <div class="col-sm-9">
                    <span><%= book.EditionStr %></span>
                </div>
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Availability: </span>
                </div>
                <% if (book.IsAvailable) { %>
                    <div class="col-sm-9">
                        <span style="color: #00cc00">Available</span>
                    </div>
                <% } else { %>
                    <div class="col-sm-9">
                        <span style="color: #cc0000">Not Available</span>
                    </div>
                <% } %>
            </div>
            <% if (book.IsAvailable) { %>
                <div class="ub-book-details-text-description">
                    <div class="col-sm-3">
                        <span class="ub-book-details-text-description-bold"># Available: </span>
                    </div>
                    <div class="col-sm-9">
                        <span><%= book.QuantityAvailable %></span>
                    </div>
                </div>
            <% } %>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Publication: </span>
                </div>
                <div class="col-sm-9">
                    <span><%= book.PublicationDate.Value.ToString(@"MM\/dd\/yyyy") %></span>
                </div>
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Authors: </span>
                </div>
                <div class="col-sm-9">&nbsp;</div>
                <asp:Repeater ID="BookAuthorRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-12 ub-book-details-text-description-idented">
                            <span><%# Eval("Name") %></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="ub-book-details-text-description">
                <div class="col-sm-3">
                    <span class="ub-book-details-text-description-bold">Categories: </span>
                </div>
                <div class="col-sm-9">&nbsp;</div>
                <asp:Repeater ID="BookCategoryRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-12 ub-book-details-text-description-idented">
                            <span><%# Eval("Name") %></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
