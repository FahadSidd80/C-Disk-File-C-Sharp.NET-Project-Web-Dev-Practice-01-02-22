﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="WebApp_ADO_CRUD_29_02_22.StudentForm" %>

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
                    <td><asp:TextBox ID="txtname" runat="server" ></asp:TextBox></td>
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
                    <td>Mobile No :</td>
                    <td><asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" >
                        <Columns>
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
                             <asp:TemplateField HeaderText="Student Mobile No">
                                <ItemTemplate>
                                    <%#Eval("mobileno") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" Text="Delete"  BackColor="Red" ForeColor="Black" CommandName="Del" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" Text="Edit"   BackColor="Green" ForeColor="White" CommandName="Edt" CommandArgument='<%#Eval("id") %>'  ></asp:LinkButton>
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
