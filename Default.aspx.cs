using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Calculate_Click(object sender, EventArgs e)
    {
        int yearStarted = Convert.ToInt32(YearInput.Text);
        int courseLength = Convert.ToInt32(LengthList.SelectedValue);
        int maintenanceLoan = MaintenanceInput.Text == "" ? 0 : Convert.ToInt32(MaintenanceInput.Text);
        int salary = Convert.ToInt32(Salary.Text);
        int loanAmount = 0;
        int payBackSalary = 0;
        int year = 0;

        double payBackTimeInYears = 0;
        double payBackMonths = 0;
        double payBackPerYear = 0;

        double payBackTimeInYears2 = 0;
        double payBackMonths2 = 0;
        double payBackPerYear2 = 0;

        double rateIncrement = increaseRate.Text == "" ? 0 : Convert.ToDouble(increaseRate.Text);
        int NoOfIncrementYear = increaseYear.Text == "" ? 0 : Convert.ToInt32(increaseYear.Text);


        if (yearStarted <= 2011 && yearStarted >= 2004)
        {
            loanAmount = 3465;
            payBackSalary = 15000;
        }

        else
        {
            loanAmount = 9000;
            payBackSalary = 21000;
        }

        int totalLoan = (loanAmount * courseLength) + (maintenanceLoan * courseLength);

        if (yearStarted >= 2004)
        {
            if (rateIncrement != 0 && NoOfIncrementYear != 0)
            {
                do
                {
                    if (salary < payBackSalary)
                    {
                        Result.Text = "You are earning under the payback threshold and so do not repay any loan on your current salary.";
                    }
                    else
                    {
                        payBackPerYear = Convert.ToDouble((salary - payBackSalary) * 0.09);
                        payBackPerYear = Math.Round(payBackPerYear,2);
                        
                        payBackTimeInYears = Math.Floor(totalLoan / payBackPerYear);
                        if (payBackTimeInYears > 25)
                        {
                            Result.Text = "Your total loan is £" + totalLoan + ". There is a cut-off of 25 years on paying back a student loan. So if you stay on your current salary, you will pay £"
                                + payBackPerYear + " per year. You will have paid off £" + 25 * payBackPerYear + " before your debt is wiped.";


                        }
                        else
                        {
                            double payBackMonthsRounded = Math.Floor(totalLoan / payBackPerYear);
                            payBackMonths = Math.Ceiling((totalLoan - (payBackMonthsRounded * payBackPerYear)) / (payBackPerYear / 12));
                            Result.Text = "Your total loan is £" + totalLoan + ". On a salary of £" + salary + ", you will pay back £" + payBackPerYear + " per year. Therefore it will take you "
                                + payBackTimeInYears + " years, " + payBackMonths + " month(s) to pay off your loan.";


                        }
                    }

                    year = year + NoOfIncrementYear;

                } while (year != NoOfIncrementYear);


                if (year == NoOfIncrementYear)
                {
                    double rateIncreased = rateIncrement / 100.00;
                    int IncerasedSalary = salary + Convert.ToInt32(salary * rateIncreased);

                    if (IncerasedSalary < payBackSalary)
                    {
                        IncreasedResult.Text = "You will earn " + IncerasedSalary + " after " + increaseYear + " years which is under the payback threshold and so do not repay any loan on your increased salary.";
                    }
                    else
                    {
                        payBackPerYear2 = Convert.ToDouble((IncerasedSalary - payBackSalary) * 0.09);
                        payBackPerYear2 = Math.Round(payBackPerYear2,2);

                        payBackTimeInYears2 = Math.Floor(totalLoan / payBackPerYear2);
                        if (payBackTimeInYears2 > 25)
                        {
                            IncreasedResult.Text = "If your current salary increases by " + rateIncrement + "% after " + NoOfIncrementYear + " year(s), then you will pay £"
                                + payBackPerYear2 + " per year. You will have paid off £" + ((payBackPerYear * NoOfIncrementYear) + ((25 - NoOfIncrementYear) * payBackPerYear2)) + " before your debt is wiped.";

                            drawChart(payBackPerYear, totalLoan, NoOfIncrementYear, payBackPerYear2);
                        }
                        else
                        {
                            double payBackMonthsRounded2 = Math.Floor(totalLoan / payBackPerYear2);
                            payBackMonths2 = Math.Ceiling((totalLoan - (payBackMonthsRounded2 * payBackPerYear2)) / (payBackPerYear2 / 12));
                            IncreasedResult.Text = "If your current salary increases by " + rateIncrement + "% after " + NoOfIncrementYear + " year(s), then you will pay back £" + payBackPerYear2 + " per year. Therefore it will take you "
                                + payBackTimeInYears2 + " years, " + payBackMonths2 + " month(s) to pay off your loan.";

                            drawChart(payBackPerYear, totalLoan, NoOfIncrementYear, payBackPerYear2);

                        }
                    }
                }
            }

            else
            {
                if (salary < payBackSalary)
                {
                    Result.Text = "You are earning under the payback threshold and so do not repay any loan on your current salary.";
                }
                else
                {
                    payBackPerYear = (salary - payBackSalary) * 0.09;
                    payBackTimeInYears = Math.Floor(totalLoan / payBackPerYear);
                    if (payBackTimeInYears > 25)
                    {
                        Result.Text = "Your total loan is £" + totalLoan + ". There is a cut-off of 25 years on paying back a student loan. So if you stay on your current salary, you will pay £"
                            + payBackPerYear + " per year. You will have paid off £" + 25 * payBackPerYear + " before your debt is wiped.";

                        drawChart(payBackPerYear, totalLoan, NoOfIncrementYear, payBackPerYear2);
                    }
                    else
                    {
                        double payBackMonthsRounded = Math.Floor(totalLoan / payBackPerYear);
                        payBackMonths = Math.Ceiling((totalLoan - (payBackMonthsRounded * payBackPerYear)) / (payBackPerYear / 12));
                        Result.Text = "Your total loan is £" + totalLoan + ". On a salary of £" + salary + ", you will pay back £" + payBackPerYear + " per year." + "<br/>" + " Therefore it will take you "
                            + payBackTimeInYears + " years, " + payBackMonths + " month(s) to pay off your loan.";

                        drawChart(payBackPerYear, totalLoan, NoOfIncrementYear, payBackPerYear2);
                    }
                }
            }

        }
        else
        {
            Result.Text = "There were no student loans issued by the Student Loans Company before 2004.";
        }
    }

    private void drawChart(double payBackPerYear, int totalLoan, int NoOfIncrementYear, double payBackPerYear2)
    {
        ScriptManager.RegisterStartupScript(this.Page,this.Page.GetType(), "draw", "draw(" + payBackPerYear + "," + totalLoan + "," + NoOfIncrementYear + "," + payBackPerYear2 + ");", true);
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        YearInput.Text = "";
        LengthList.SelectedValue = "1";
        MaintenanceInput.Text = "";
        Salary.Text = "";
        Result.Text = "";
        increaseRate.Text = "";
        increaseYear.Text = "";
        IncreasedResult.Text = "";

    }


}
