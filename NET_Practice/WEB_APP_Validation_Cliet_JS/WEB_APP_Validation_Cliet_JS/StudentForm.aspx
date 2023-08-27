<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="WEB_APP_Validation_Cliet_JS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function validation()
        {
            var container = "";
            container = checkname();
            container += checkemail();
            container += checkpassowrd();
            container += checkcpassword();
            container += checksalary();
            container += checkage();
            container += checkmobileno();

            if (container == "") {
                return true
            }
            else {
                alert(container);
                return false
            }
           
        }
        function checkname()
        {
            var tb = document.getElementById('txtname')
            var exp = /^[a-zA-Z]*$/
            if (tb.value == "") {
                return 'Please enter your name.\n';

            }
            else if (exp.test(tb.value))
            {
                return true
            }
            else {
                return 'please enter only alphabets..\n';
            }
        }
        function checkemail()
        {
            var tb = document.getElementById('txtemail')
            var exp = /\S+@\S+\.\S+/
            if (tb.value == "") {
                return 'Please enter your email id.\n';

            }
            else if (exp.test(tb.value))
            {
                return true
            }
            else {
                return 'please enter valid email id...\n';
            }
        }
        function checkpassowrd() {
            var tb = document.getElementById('txtpassword')
            var exp = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W)(?!.* ).{8,16}$/
            if (tb.value == "") {
                return 'Please enter your password.\n';

            }
            else if (exp.test(tb.value))
            {
                return true // here true means no message
            }
            else {
                return 'please eneter password that must be contain one digit from 1 to 9, one lowercase letter,  one uppercase letter, one special character,  no space, and it must be 8-16 characters long...\n ';
            }
        }
        function checkcpassword() {
            var tb = document.getElementById('txtcpassword')
            var tb1 = document.getElementById('txtpassword')
            if (tb.value == "") {
                return 'Please enter your confirm password.\n';

            }
            else if (tb.value == tb1.value)
            {
                return "";
            }
            else {
                return 'password do not match..please enter correct password..\n';
            }
        }
        function checksalary() {
            var tb = document.getElementById('txtsalary')
            var salary = 10000;
            var exp = /^[0-9]*$/
            if (tb.value == "") {
                return 'Please enter your salary.\n';

            }
            else if (10000 <= salary & salary <= 20000) {
                return "";
            }
            else if (salary.test(tb.value))
            {
                return "";
            }
            else if (exp.test(tb.value)) {
                return 'please enter only digit between 0-9';
            }
            else {
                return 'please insert salary between 10000 and 20000';
            }
        }
        function checkage() {
            var tb = document.getElementById('txtage')
            var exp = /^[0-9]*$/
            var age = 18;
            var tbs = tb.value;
            if (tb.value == "") {
                return 'Please enter your age.\n';

            }
            else if (exp.test(tb.value))
            {
                return true
            }
            else if (age <= tbs)
            {
                return 'please enter value above 18';
            }
            else if (age <= tbs)
            {
                return "";
            }
            else {
                return 'please enter only integer value from 0-9..\n';
            }
        }
        function checkmobileno() {
            var tb = document.getElementById('txtmobile')
            var exp = /^\d{10}$/
            if (tb.value == "") {
                return 'Please enter your mobile.\n';

            }
            else if (exp.test(tb.value))
            {
                return true
            }
            else {
                return 'please enter only 10 digit mobile number..\n';
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
                    <td><asp:TextBox ID="txtname" runat="server" Width="322px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Email :</td>
                    <td><asp:TextBox ID="txtemail" runat="server" Width="322px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Password :</td>
                    <td><asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="319px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Confirm Password :</td>
                    <td><asp:TextBox ID="txtcpassword" runat="server" TextMode="Password" Width="318px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Salary :</td>
                    <td><asp:TextBox ID="txtsalary" runat="server" Width="314px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Age :</td>
                    <td><asp:TextBox ID="txtage" runat="server" Width="312px"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Mobile No :</td>
                    <td><asp:TextBox ID="txtmobile" runat="server" Width="316px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" ForeColor="White" BackColor="Gray" OnClientClick="return validation()" OnClick="btnsave_Click" Height="32px" Width="101px" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false" Height="76px" Width="814px">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email ID">
                                <ItemTemplate>
                                    <%#Eval("email") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password">
                                <ItemTemplate>
                                    <%#Eval("password") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Confrm Password">
                                <ItemTemplate>
                                    <%#Eval("cpassword") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary">
                                <ItemTemplate>
                                    <%#Eval("salary") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <%#Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile No">
                                <ItemTemplate>
                                    <%#Eval("mobileno") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%#Eval("sid") %>'></asp:LinkButton>
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
