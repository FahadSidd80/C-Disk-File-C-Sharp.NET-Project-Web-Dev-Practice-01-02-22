<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="Web_App_L13_JS_Validtn.StudentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function Validation() {
            var msg = "";
            msg = checkName();
            msg += checkCity();
            msg += checkAge();
            msg += checkMobile();
            msg += checkpassword();
            msg += checkcpassword();

            if (msg == "") {
                return true;
            }
            else {
                alert(msg);
                return false;
            }
        }
        function checkName() {
            var Tb = document.getElementById('txtname');
            var exp = /^[a-zA-Z ]*$/;
            if (Tb.value == "") {
                return 'Please enter you name !! \n';
                
            }
            else if (exp.test(Tb.value)) {
                return "";
            }
            else {
                return 'please enter name from a to z, or A to Z !! \n';
            }
        }
        function checkCity() {
            var Tb = document.getElementById('txtcity');
            var exp = /^[a-zA-Z ]*$/;
            if (Tb.value == "") {
                return 'Please enter you city name !! \n';

            }
            else if (exp.test(Tb.value)) {
                return "";
            }
            else {
                return  'please enter city name only in character !! \n';
            }
        }
        function checkAge() {
            var Tb = document.getElementById('txtage');
            var exp = /^[0-9]*$/;
            if (Tb.value == "") {
                return 'Please enter you age !! \n';

            }
            else if (exp.test(Tb.value)) {
                return "";
            }
            else {
                return 'please enter age only in integer value !! \n';
            }
        }
        function checkMobile() {
            var Tb = document.getElementById('txtmobile');
            var exp = /^\d{10}$/;
            if (Tb.value == "") {
                return 'Please enter your mobile no !! \n';

            }
            else if (exp.test(Tb.value)) {
                return "";
            }
            else {
                return 'Please enter  only 10 digit mobileno !! \n';
            }
        }
        function checkpassword() {
            var Tb = document.getElementById('txtpassword');
            if (Tb.value == "") {
                return 'Please enter your password !! \n';

            }
            else {
                return "";
            }
        }
        function checkcpassword() {
            var Tb = document.getElementById('txtcpassword');
            var Tb1 = document.getElementById('txtpassword');
            var exp = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
            if (Tb.value == "") {
                return 'Please enter your confirm password !! \n';
            }
            else if (Tb.value == Tb1.value && (exp.test(Tb.value))) {
                return "";
            }
            else if (Tb.value != Tb1.value) {
                return 'password do not match !! \n';
            }
            else {
                return 'Please enter password contain atleast 1 digit\n 1 lower case, 1 upper case\n 1 special character & atleast 8 character..!! \n';
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
                    <td>Password :</td>
                    <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Confirm Password :</td>
                    <td><asp:TextBox ID="txtcpassword" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClick="btnsave_Click" OnClientClick="return Validation()" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Std Name">
                                <ItemTemplate>
                                    <%# Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                          <Columns>
                            <asp:TemplateField HeaderText="Std City">
                                <ItemTemplate>
                                    <%# Eval("city") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                          <Columns>
                            <asp:TemplateField HeaderText="Std Age">
                                <ItemTemplate>
                                    <%# Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                          <Columns>
                            <asp:TemplateField HeaderText="Std Mobileno">
                                <ItemTemplate>
                                    <%# Eval("mobileno") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                          <Columns>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%#Eval("sid") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                          <Columns>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%#Eval("sid") %>'></asp:LinkButton>
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
