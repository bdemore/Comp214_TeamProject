<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Comp214_TeamProject.Register" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:Label ID="TitleLabel" Text="User Registration" runat="server" />
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
            <div class="col-sm-12">
                <asp:TextBox ID="EmailTextBox"
                    ToolTip="Enter your email here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Email" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="EmailTextBox_RFV"
                    ControlToValidate="EmailTextBox"
                    Display="Dynamic"
                    ErrorMessage="Email is required"
                    CssClass="register-input-error"
                    runat="server" />
                <asp:RegularExpressionValidator ID="EmailTextBoxRegex_RFV"
                    ControlToValidate="EmailTextBox"
                    Display="Dynamic"
                    ErrorMessage="Invalid email. You must use the pattern email@email.ca"
                    CssClass="register-input-error"
                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                    runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="PasswordTextBox"
                    ToolTip="Enter a password here"
                    TextMode="Password"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Password" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="PasswordTextBox_RFV"
                    ControlToValidate="PasswordTextBox"
                    Display="Dynamic"
                    ErrorMessage="Password is required"
                    CssClass="register-input-error"
                    runat="server" />
                <asp:RegularExpressionValidator ID="PasswordTextBoxRegex_RFV"
                    ControlToValidate="PasswordTextBox"
                    Display="Dynamic"
                    ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number"
                    CssClass="register-input-error"
                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"
                    runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="ConfirmPasswordTextBox"
                    ToolTip="Confirm your password here"
                    TextMode="Password"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Confirm Password" />
            </div>
            <div class="col-sm-12 register-validator-message-container">
                <asp:RequiredFieldValidator ID="ConfirmPasswordTextBox_RFV"
                    ControlToValidate="ConfirmPasswordTextBox"
                    Display="Dynamic"
                    ErrorMessage="Confirm Password is required"
                    CssClass="register-input-error"
                    runat="server" />
                <asp:CompareValidator ID="ConfirmPasswordTextBoxCompare_RFV"
                    ControlToValidate="ConfirmPasswordTextBox"
                    ControlToCompare="PasswordTextBox"
                    ErrorMessage="No Match. Passwords must match."
                    CssClass="register-input-error"
                    runat="server" />
            </div>
            <div class="col-sm-12 register-button-container">
                <div class="col-sm-6">
                    <asp:Button ID="RegisterButton" Text="Register" CssClass="ub-book-button" runat="server" OnClick="RegisterButton_Click" />
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="ub-book-button" runat="server" OnClick="CancelButton_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
        <div class="col-sm-3">&nbsp</div>
    </div>
</asp:Content>
