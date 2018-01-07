<%@ Page Title="Update Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="Comp214_TeamProject.UpdateBook" %>
<asp:Content ID="UpdateBookContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container body-content">
        <%-- Success Panel --%>
        <asp:Panel ID="SuccessPanel" runat="server" CssClass="register-error-message-hidden">
            <div><%= message %></div>
        </asp:Panel>
    </div>

    <div class="col-sm-12">
        <div class="col-sm-12 register-input-container">
            <div class="col-sm-12 register-panel-title">
                <asp:Label ID="TitleLabel" Text="Book Update" runat="server" />
            </div>
            <div class="col-sm-6">
                <asp:TextBox ID="BookIsbnTextBox"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    MaxLength="13"
                    Enabled="false"
                    ReadOnly="true"
                    placeholder="First Name" />
            </div>
            <div class="col-sm-6">
                <asp:TextBox ID="BookTitleTextBox"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    MaxLength="128"
                    placeholder="Book Title" />
            </div>
            <div class="col-sm-6 register-validator-message-container">
                <asp:RequiredFieldValidator ID="BookIsbnTextBox_RFV"
                    ControlToValidate="BookIsbnTextBox"
                    Display="Dynamic"
                    ErrorMessage="Book ISBN is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-6 register-validator-message-container">
                <asp:RequiredFieldValidator ID="BookTitleTextBox_RFV"
                    ControlToValidate="BookTitleTextBox"
                    Display="Dynamic"
                    ErrorMessage="Book Title is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-12" style="overflow: hidden;">
                <asp:TextBox ID="BookDescriptionTextBox"
                    TextMode="MultiLine"
                    CssClass="register-input"
                    MaxLength="2048"
                    Rows="3"
                    runat="server"
                    placeholder="Book Description" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="BookDescriptionTextBox_RFV"
                    ControlToValidate="BookDescriptionTextBox"
                    Display="Dynamic"
                    ErrorMessage="Book Description is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-6">
                <asp:TextBox ID="BookPublicatinDateTextBox"
                    TextMode="Date"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Book Publication Date" />
            </div>
            <div class="col-sm-6">
                <asp:TextBox ID="BookEditionTextBox"
                    TextMode="Number"
                    CssClass="register-input"
                    runat="server"
                    MaxLength="2"
                    placeholder="Book Edition" />
            </div>
            <div class="col-sm-6 register-validator-message-container">
                <asp:RequiredFieldValidator ID="BookPublicatinDateTextBox_RFV"
                    ControlToValidate="BookPublicatinDateTextBox"
                    Display="Dynamic"
                    ErrorMessage="Book Publication Date is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-6 register-validator-message-container">
                <asp:RangeValidator ID="BookEditionTextBox_RV"
                    ControlToValidate="BookEditionTextBox"
                    Display="Dynamic"
                    MinimumValue="1"
                    MaximumValue="99"
                    ErrorMessage="Book Edition must be greater than zero."
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-6">
                <asp:DropDownList ID="BookAvailableDropDownList" runat="server" CssClass="register-input">
                    <asp:ListItem Selected="False" Text="Not Available" Value="0" />
                    <asp:ListItem Selected="True" Text="Available" Value="1" />
                </asp:DropDownList>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="BookQuantityAvailableTextBox"
                    TextMode="Number"
                    CssClass="register-input"
                    runat="server"
                    MaxLength="5"
                    placeholder="Book Quantity Available" />
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="BookPagesTextBox"
                    TextMode="Number"
                    CssClass="register-input"
                    runat="server"
                    MaxLength="5"
                    placeholder="Book Number of Pages" />
            </div>
            <div class="col-sm-6 register-validator-message-container">
                <asp:RequiredFieldValidator ID="BookAvailableDropDownList_RFV"
                    ControlToValidate="BookAvailableDropDownList"
                    Display="Dynamic"
                    ErrorMessage="Book Availability is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-3 register-validator-message-container">
                <asp:RangeValidator ID="BookQuantityAvailableTextBox_RV"
                    ControlToValidate="BookQuantityAvailableTextBox"
                    Display="Dynamic"
                    MinimumValue="1"
                    MaximumValue="999"
                    ErrorMessage="Book Quantity Available must be greater than zero."
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-3 register-validator-message-container">
                <asp:RangeValidator ID="BookPagesTextBox_RV"
                    ControlToValidate="BookPagesTextBox"
                    Display="Dynamic"
                    MinimumValue="1"
                    MaximumValue="99999"
                    ErrorMessage="Book Number of Pages must be greater than zero."
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-12" style="overflow: hidden">
                <asp:TextBox ID="BookImageUrl01"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    MaxLength="256"
                    runat="server"
                    placeholder="Book Image URL 01" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="BookImageUrl01_RFV"
                    ControlToValidate="BookImageUrl01"
                    Display="Dynamic"
                    ErrorMessage="Book Image URL 01 is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="BookImageUrl02"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    MaxLength="256"
                    runat="server"
                    placeholder="Book Image URL 02" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="BookImageUrl03"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    MaxLength="256"
                    runat="server"
                    placeholder="Book Image URL 03" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="BookImageUrl04"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    MaxLength="256"
                    runat="server"
                    placeholder="Book Image URL 04" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="BookImageUrl05"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    MaxLength="256"
                    runat="server"
                    placeholder="Book Image URL 05" />
            </div>
            <div class="col-sm-12 register-button-container">
                <div class="col-sm-6" style="padding-top: 50px;">
                    <asp:Button ID="UpdateButton" Text="Updte Book" CssClass="ub-book-button" runat="server" OnClick="UpdateButton_Click" />
                </div>
                <div class="col-sm-6" style="padding-top: 50px;">
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="ub-book-button" runat="server" OnClick="CancelButton_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
