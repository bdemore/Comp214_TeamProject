<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Comp214_TeamProject.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
    <fieldset style="width: 600px; margin: 0 auto; background-color: lightgoldenrodyellow;">
        <h2>Member Registration<asp:Image ID="Image1" runat="server" Width="80px" style="width: 80px; float: right;" ImageUrl="~/centenniallogo.jpg" /></h2>
        <p>Please complete the following fields:</p>
        <p>First Name*:
            <asp:TextBox ID="Fname" runat="server"></asp:TextBox>
        </p>
        <p>Last Name*:
            <asp:TextBox ID="Lname" runat="server"></asp:TextBox>
        </p>
        <p>Address*:
            <asp:TextBox ID="Address" runat="server"></asp:TextBox>
        </p>
        <p>City*:
            <asp:TextBox ID="City" runat="server"></asp:TextBox>
        </p>
        <p>Province*:
            <asp:TextBox ID="Province" runat="server" placeholder="e.g. ON" Style="text-transform:uppercase"></asp:TextBox>
        </p>
        <p>Postal Code*:
            <asp:TextBox ID="Pcode" runat="server"></asp:TextBox>
        </p>
        <p>Password*:
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        </p>
        <p>Confirm Password*:
            <asp:TextBox ID="Cpassword" runat="server"></asp:TextBox>
        </p>
        <p>Email*:
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        </p>
        <p>Phone:
            <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
        </p>
        <p>Enter another number? <asp:CheckBox ID="CheckBox1" runat="server" /></p>
        <asp:Button ID="register" runat="server" Text="Register" OnClick="ButtonReg_Click" />
        <asp:Button ID="clear" runat="server" Text="clear" OnClick="clear_Click" />

</fieldset>
    </div>
</asp:Content>
