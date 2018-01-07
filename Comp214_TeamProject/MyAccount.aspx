<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="Comp214_TeamProject.MyAccount" %>
<asp:Content ID="MyAccountContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <%-- Error Panel --%>
        <asp:Panel ID="ErrorPanel" runat="server" CssClass="register-error-message-hidden">
            <div><%= message %></div>
        </asp:Panel>
    </div>

    <div class="col-sm-12">
        <div class="col-sm-3">&nbsp</div>
        <div class="col-sm-6 register-input-container">
            <div class="col-sm-12 register-panel-title">
                <asp:Label ID="TitleLabel" Text="Profile Update" runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="EmailTextBox"
                    ToolTip="Enter your email here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    Enabled="false"
                    ReadOnly="true"
                    runat="server"
                    placeholder="Email" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="FirstNameTextBox"
                    ToolTip="Enter your first name here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="First Name" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="FirstNameTextBox_RFV"
                    ControlToValidate="FirstNameTextBox"
                    Display="Dynamic"
                    ErrorMessage="First Name is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="LastNameTextBox"
                    ToolTip="Enter your last name here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Last Name" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="LastNameTextBox_RFV"
                    ControlToValidate="LastNameTextBox"
                    Display="Dynamic"
                    ErrorMessage="Last Name is required"
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-12 register-button-container" style="margin-top: 40px;">
                <div class="col-sm-6">
                    <asp:Button ID="UpdateProfileButton" Text="Update" CssClass="ub-book-button" runat="server" OnClick="UpdateProfileButton_Click" />
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="ub-book-button" runat="server" OnClick="CancelButton_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
        <div class="col-sm-3">&nbsp</div>
    </div>
</asp:Content>
