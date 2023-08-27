﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="WebApplication1.RegistrationForm" %>

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
                    <td>Course :</td>
                    <td><asp:TextBox ID="txtcourse" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Course">
                                <ItemTemplate>
                                    <%#Eval("course") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <%#Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                   <asp:LinkButton ID="btndelete" runat="server" Text="Delete" ForeColor="Red" BackColor="White" OnClientClick="return confirm('Are you sure you want to delete....?')" CommandName="Del" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                   <asp:LinkButton ID="btnedit" runat="server" Text="Edit" ForeColor="Blue" BackColor="White" CommandName="Edt" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
