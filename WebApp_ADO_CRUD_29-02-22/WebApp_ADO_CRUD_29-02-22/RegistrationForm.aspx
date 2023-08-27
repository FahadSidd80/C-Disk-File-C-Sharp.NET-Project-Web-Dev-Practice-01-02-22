<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="WebApp_ADO_CRUD_29_02_22.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Nmae :</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Blood Group :</td>
                    <td><asp:RadioButtonList ID="rblbg" runat="server" RepeatColumns="10">
                        <%--<asp:ListItem Text="A+" Value="1"></asp:ListItem> // this is static binding
                        <asp:ListItem Text="B+" Value="2"></asp:ListItem>
                        <asp:ListItem Text="AB+" Value="3"></asp:ListItem>
                        <asp:ListItem Text="O+" Value="4"></asp:ListItem>
                        <asp:ListItem Text="AB-" Value="5"></asp:ListItem>
                        <asp:ListItem Text="B-" Value="6"></asp:ListItem>
                        <asp:ListItem Text="O-" Value="7"></asp:ListItem>--%> 
                        </asp:RadioButtonList></td>
                </tr>
                 <tr>
                    <td>Course :</td>
                    <td><asp:DropDownList ID="ddlcourse" runat="server">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <%--<asp:ListItem Text="MCA" Value="1"></asp:ListItem>
                        <asp:ListItem Text="BCA" Value="2"></asp:ListItem>
                        <asp:ListItem Text="CA" Value="3"></asp:ListItem>
                        <asp:ListItem Text="B.Tech" Value="4"></asp:ListItem>
                        <asp:ListItem Text="M.tech" Value="5"></asp:ListItem>
                        <asp:ListItem Text="BBA" Value="6"></asp:ListItem>
                        <asp:ListItem Text="MBA" Value="7"></asp:ListItem>--%>
                        </asp:DropDownList></td>
                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" ></asp:GridView></td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
