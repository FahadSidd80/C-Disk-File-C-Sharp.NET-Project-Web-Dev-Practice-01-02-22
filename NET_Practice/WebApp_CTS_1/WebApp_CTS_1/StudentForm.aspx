<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="WebApp_CTS_1.StudentForm" %>

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
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>City :</td>
                    <td><asp:TextBox ID="txtcity" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Mobile No :</td>
                    <td><asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Country :</td>
                    <td><asp:TextBox ID="txtcountry" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>DOB :</td>
                    <td><asp:TextBox ID="txtdob" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Roll No : </td>
                    <td><asp:TextBox ID="txtrollno" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Submit"  ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" /></td>
                </tr>
                  <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Studnt Name">
                                <ItemTemplate>
                                    <%# Eval("name")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Studnt age">
                                <ItemTemplate>
                                    <%# Eval("age")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Studnt City">
                                <ItemTemplate>
                                    <%# Eval("city")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Studnt Mobile">
                                <ItemTemplate>
                                    <%# Eval("mobileno")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Studnt Country">
                                <ItemTemplate>
                                    <%# Eval("country")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Studnt Dob">
                                <ItemTemplate>
                                    <%# Eval("dob")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Studnt Rollno">
                                <ItemTemplate>
                                    <%# Eval("rollno")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
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
