﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="WebAppWithProcedure.StudentForm" %>

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
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Roll No :</td>
                    <td><asp:TextBox ID="txtrollno" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Submit" ForeColor="White" BackColor="Gray" OnClick="tbtnsave_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Student ID">
                                <ItemTemplate>
                                    <%#Eval("id") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student City">
                                <ItemTemplate>
                                    <%#Eval("city") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Age">
                                <ItemTemplate>
                                    <%#Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Roll NO">
                                <ItemTemplate>
                                    <%#Eval("rollno") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
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
