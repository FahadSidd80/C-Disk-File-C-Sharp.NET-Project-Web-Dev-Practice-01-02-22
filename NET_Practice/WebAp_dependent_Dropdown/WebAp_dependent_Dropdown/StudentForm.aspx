<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="WebAp_dependent_Dropdown.StudentForm" %>

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
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Age :</td>
            <td>
                <asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Gender :</td>
            <td>
                <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                    <asp:ListItem Text="male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="other" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>

        <tr>
            <td>Country :</td>
            <td>
                <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>State :</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClientClick="return Validation()" OnClick="btnsave_Click"  /></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:GridView ID="gvregistration" runat="server" OnRowCommand="gvregistration_RowCommand"  AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="RegID">
                            <ItemTemplate>
                                <%#Eval("id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reg Name">
                            <ItemTemplate>
                                <%#Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reg Age">
                            <ItemTemplate>
                                <%#Eval("age") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Reg Gender">
                            <ItemTemplate>
                                <%#Eval("gender").ToString()=="1" ? "male" :Eval("gender").ToString()=="2" ? "female" : "other"  %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reg Country">
                            <ItemTemplate>
                                <%#Eval("cname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btndelete" runat="server" Text="Delete" OnClientClick="return confirm('are you sure you want to delete?')" CommandName="A" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
        </tr>
    </table>
        </div>
    </form>
</body>
</html>
