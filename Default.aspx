<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Student Loans Calculator</title>

    <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
    <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>

    

    <link rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="/favicon.ico" type="image/x-icon" />

    <script src="myScript.js"></script>
    
    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <div class="jumbotron">

        <div>
        <h1>Student Loans Calculator</h1>
        <p>Enter your information into the form below to receive information on paying back your student loan. This form assumes you paid the highest possible amount as an undergraduate.</p>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <h2>Loan Information</h2>
                    <br />
                    <h4>What year did you begin your course?</h4>
                    <asp:TextBox ID="YearInput" runat="server" Placeholder="The year you began"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Year is required field" ControlToValidate="YearInput" ForeColor="Red"> </asp:RequiredFieldValidator>

                    <br /><br />
                    <h4>How many years was your course?</h4>
                    <asp:DropDownList ID="LengthList" runat="server">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                    <br /><br />
                    <h4>Did you take out a maintenance loan?If so, input how much per year you borrowed.</h4>
                    <asp:TextBox ID="MaintenanceInput" runat="server" Placeholder="The amount you borrowed"></asp:TextBox>
            
                    <br /><br />
                    <h2>Earning Information</h2>
                    <h4>How much do you earn currently or expect to earn?</h4>
                    <asp:TextBox ID="Salary" runat="server" Placeholder="Amount"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Salary is required field" ControlToValidate="Salary" ForeColor="Red" > </asp:RequiredFieldValidator>
                    <br />
                
                    <h4>Do you think your salary will increase?If so, input how much do you think your salary will increase</h4>
                    <asp:TextBox ID="increaseRate" runat="server" Placeholder="%"></asp:TextBox>
                    <h4>After how many years do you think your salary will increase?</h4>
                    <asp:TextBox ID="increaseYear" runat="server" Placeholder="No. of Year"></asp:TextBox>
                    <br />
                    <br />
                
                    <asp:Button ID="Calculate" runat="server" Text="Calculate" OnClick="Calculate_Click"/>
                    <asp:Button ID="Reset" runat="server" Text="Reset" OnClick="Reset_Click" />
                    
                    <br /><br /><br /><br />
                </div>
               
                <div class="col-md-6">
                    <h2>Your Result</h2>
                    <asp:Label ID="Result" runat="server" Text="" Font-Bold="True" Font-Size="Medium" Font-Italic="True">             
                    </asp:Label>
                    <br /><br />
                     <asp:Label ID="IncreasedResult" runat="server" Text="" Font-Bold="True" Font-Size="Medium" Font-Italic="True">             
                    </asp:Label>
                    <br /><br />
                    <div id="chartContainer"></div>   
                </div>
                </div>
                 </ContentTemplate>
        </asp:UpdatePanel>
            
            
    </div>

    </form>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>
