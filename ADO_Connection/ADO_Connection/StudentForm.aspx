<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="ADO_Connection.StudentForm" %>

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
                    <td><asp:TextBox ID="txtcity" runat="server"></asp:TextBox></td>

              </tr>
              <tr>
                  
                    <td>Gender :</td>
                    <td><asp:TextBox ID="txtgender" runat="server"><</asp:TextBox></td>
              </tr>
              <tr>

                    <td>Roll no :</td>
                    <td><asp:TextBox ID="txtrollno" runat="server"></asp:TextBox></td>
              </tr>

                    <tr>

                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" ForeColor="White" BackColor="Gray" /></td>
                        </tr>
               
            </table>
        </div>
    </form>
</body>
</html>
