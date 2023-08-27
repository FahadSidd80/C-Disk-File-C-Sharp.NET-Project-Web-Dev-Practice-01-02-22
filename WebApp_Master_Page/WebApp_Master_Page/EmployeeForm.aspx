<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="WebApp_Master_Page.EmployeeForm" %>
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
                    <td>Roll No : :</td>
                     <td><asp:TextBox ID="txtrollno" runat="server"></asp:TextBox></td>
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
                    <td>Subject :</td>
                    <td><asp:DropDownList ID="ddlsubject" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Department :</td>
                    <td><asp:DropDownList ID="ddldepartment" runat="server"></asp:DropDownList></td>
                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" BackColor="Gray" ForeColor="White" OnClick="btnsave_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" >
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
                             <asp:TemplateField HeaderText="Rollno">
                                <ItemTemplate>
                                    <%#Eval("rollno") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <%#Eval("gender").ToString() == "1" ? "Male" : Eval("gender").ToString() == "2" ? "Female" : "Other" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <%#Eval("sname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <%#Eval("dname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                   <asp:LinkButton ID="btndelete" Text="Delete" runat="server" CommandName="Del" CommandArgument='<%#Eval("lid") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                     <asp:LinkButton ID="btnedit" Text="Edit" runat="server" CommandName="Edt" CommandArgument='<%#Eval("lid") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView></td>
                </tr>
               
            </table>
</asp:Content>
