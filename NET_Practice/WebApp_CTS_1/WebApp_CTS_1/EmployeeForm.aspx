<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="WebApp_CTS_1.EmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function Validation()
        {
            //if (document.getElementById('txtname').value == "") {
            //    alert('Please enter your name !! ');
            //    return false;
            //}
            //var p = document.getElementById('txtname');
            //if (p.value=="") {
            //    alert('please enter your name !!');
            //    return false;
            //}
             var tb = "";
             tb +=  checkname();
             tb +=  checkage();
             tb += checkcity();
             tb += checkcountry();
             tb += checkdob();
             tb += checkmobileno();
            if (tb == "") {
                return true;
            }
            else {
                alert(tb);
                return false;
            }
        }

        function checkname() {
            var p = document.getElementById('txtname');
            if (p.value == "") {
                return 'Please enter your name !!  \n';

            }
            else {
                return "";
            }
        }
        function checkage() {
            var p = document.getElementById('txtage');
            if (p.value == "") {
                return 'Please enter your age !! \n';

            }
            else {
                return "";
            }
        }
        function checkcity() {
            var p = document.getElementById('txtcity');
            if (p.value == "") {
                return 'Please enter your city  !!\n';

            }
            else {
                return "";
            }
        }
        function checkcountry() {
            var p = document.getElementById('txtcountry');
            if (p.value == "") {
                return  'Please enter your country  !!\n';

            }
            else {
                return "";
            }
        }
        function checkdob() {
            var p = document.getElementById('txtdob');
            if (p.value == "") {
                return 'Please enter your dob  !!\n';

            }
            else {
                return "";
            }
        }
        function checkmobileno() {
            var p = document.getElementById('txtmobile');
            if (p.value == "") {
                return 'Please enter your mobileno  !!\n';
                
            }
            else {
                return "";
            }
        }
    </script>
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
                    <td>Country :</td>
                    <td><asp:TextBox ID="txtcountry" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>DOB :</td>
                    <td><asp:TextBox ID="txtdob" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Mobileno :</td>
                    <td><asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Submit" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" OnClientClick="return Validation()" /></td>  <%--OnClientClick event will fire first and use lang JS--%>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" >
                        <Columns>
                            <asp:TemplateField HeaderText="EMp Name">
                                <ItemTemplate>
                                    <%# Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="EMp Age">
                                <ItemTemplate>
                                    <%# Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="EMp City">
                                <ItemTemplate>
                                    <%# Eval("city") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="EMp Country">
                                <ItemTemplate>
                                    <%# Eval("country") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="EMp DOB">
                                <ItemTemplate>
                                    <%# Eval("dob") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="EMp MObileNo">
                                <ItemTemplate>
                                    <%# Eval("mobileno") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%# Eval("empid") %>' ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <Columns>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                     <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%# Eval("empid") %>' ></asp:LinkButton>
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
