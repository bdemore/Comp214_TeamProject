<%@ Page Title="Reserve Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReserveDetails.aspx.cs" Inherits="Comp214_TeamProject.ReserveDetails" %>

<asp:Content ID="ReserveDetailsContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ub-container">
        <div class="col-sm-12">
            <div class="col-sm-12 ub-book-reserve-number">
                <span>Reservation: <b># <%= reserveNumber %></b></span>
            </div>
            <div class="col-sm-12 ub-book-reserve-details">
                <div class="col-sm-12 ub-book-reserve-item-header">
                    <div class="col-sm-2"><span>Photo</span></div>
                    <div class="col-sm-6"><span>Title</span></div>
                    <div class="col-sm-2"><span>Rent Date</span></div>
                    <div class="col-sm-2"><span>Rent Due Date</span></div>
                </div>
                <asp:Repeater ID="ReserveItemRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-12 ub-book-reserve-item">
                            <div class="col-sm-2 ub-book-reserve-item-photo">
                                <asp:Image ID="BookImage"
                                    AlternateText='<%# Eval("Title") %>'
                                    ImageUrl='<%# Eval("ImageUrl01") %>'
                                    CssClass="ub-book-image-small"
                                    runat="server" />
                            </div>
                            <div class="col-sm-6 ub-book-reserve-text-special">
                                <asp:Label ID="ReserveBookTitleLabel" Text='<%# Eval("Title") %>' runat="server" />
                            </div>
                            <div class="col-sm-2 ub-book-reserve-text">
                                <span><%= reserveDate %></span>
                            </div>
                            <div class="col-sm-2 ub-book-reserve-text">
                                <span><%= reserveDueDate %></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
