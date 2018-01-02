<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact us.aspx.cs" Inherits="Comp214_TeamProject.Contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div>
            
        <p>Name: <asp:TextBox ID="name" runat="server"></asp:TextBox></p>
             <p>Email: <asp:TextBox ID="email" runat="server"></asp:TextBox></p>
             <p>Message: <textarea id="message" cols="20" rows="3"></textarea></p>
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Save_Click" />

        </div>
</asp:Content>
