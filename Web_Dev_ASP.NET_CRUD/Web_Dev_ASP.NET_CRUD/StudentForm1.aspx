<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm1.aspx.cs" Inherits="Web_Dev_ASP.NET_CRUD.StudentForm1" %>

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
                    <td>Name :</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>City :</td>
                    <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
                </tr>
                 <tr>
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Rollno :</td>
                    <td><asp:TextBox ID="txtrollno" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>gender :</td>
                    <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                 <tr>
                    <td>Hobbies :</td>
                    <td><asp:CheckBoxList ID="cblhobbies" runat="server" RepeatColumns="10"></asp:CheckBoxList></td>
                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Submit" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" /></td>
                </tr>
            
            </table>
        </div>
    </form>
</body>
</html>
