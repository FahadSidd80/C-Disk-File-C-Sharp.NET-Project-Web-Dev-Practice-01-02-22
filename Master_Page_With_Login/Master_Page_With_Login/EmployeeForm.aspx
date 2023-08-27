<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="Master_Page_With_Login.EmployeeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Age :</td>
            <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Gender :</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>Bloodgroup :</td>
            <td><asp:RadioButtonList ID="rblbg" runat="server" RepeatColumns="8">

                </asp:RadioButtonList></td>
        </tr>

        <tr>
            <td>Country :</td>
            <td><asp:DropDownList ID="ddlcountry" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>State :</td>
            <td><asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>City :</td>
            <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Email :</td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Mobile No:</td>
            <td><asp:TextBox id="txtmobile" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Register" ForeColor="White" BackColor="Black" OnClick="btnsave_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:GridView ID="grd" runat="server"></asp:GridView></td>
        </tr>
    </table>
</asp:Content>
