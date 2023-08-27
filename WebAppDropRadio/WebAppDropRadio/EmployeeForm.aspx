<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="WebAppDropRadio.EmployeeForm" %>

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
                   <td>Gender :</td>
                   <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                       <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                       <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                       <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                       </asp:RadioButtonList></td>
               </tr>
               <tr>
                   <td>Course :</td>
                   <td><asp:DropDownList ID="ddlcourse" runat="server"></asp:DropDownList></td>
               </tr>
               <tr>
                   <td>Country :</td>
                   <td><asp:DropDownList ID="ddlcountry" runat="server"></asp:DropDownList></td>
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
                           <asp:TemplateField HeaderText="Gender">
                               <ItemTemplate>
                                   <%#Eval("gender").ToString()=="1" ? "Male" : Eval("gender").ToString()=="2" ? "Female" : "Other"  %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Course">
                               <ItemTemplate>
                                   <%#Eval("cname") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Country">
                               <ItemTemplate>
                                   <%#Eval("cnname") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action">
                               <ItemTemplate>
                                  <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="D" CommandArgument='<%#Eval("empid") %>' />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Action">
                               <ItemTemplate>
                                  <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="E" CommandArgument='<%#Eval("empid") %>' />
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
