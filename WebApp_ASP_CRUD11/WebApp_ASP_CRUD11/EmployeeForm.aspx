<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="WebApp_ASP_CRUD11.EmployeeForm" %>

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
                    <td>Blood group :</td>
                    <td><asp:RadioButtonList ID="rblbg" runat="server" RepeatColumns="9">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>Country :</td>
                    <td><asp:DropDownList ID="ddlcountry" runat="server">
                        </asp:DropDownList></td>
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
                               <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <%#Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="BloodGroup">
                                <ItemTemplate>
                                    <%#Eval("bloodgroup") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <%#Eval("country") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <%#Eval("state") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <%#Eval("city") %>
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
