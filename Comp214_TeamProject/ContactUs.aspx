﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Comp214_TeamProject.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div>
            
        <p>Name: <asp:TextBox ID="name" runat="server"></asp:TextBox></p>
             <p>Email: <asp:TextBox ID="email" runat="server"></asp:TextBox></p>
             <p>Message: <textarea id="message" cols="20" rows="3"></textarea></p>
            <asp:Button ID="SentMessage" runat="server" Text="Sent" OnClick="SentMessage_Click" />

        </div>
</asp:Content>
