draw = function (payBackPerYear, totalLoan, NoOfIncrementYear, payBackPerYear2) {

    var dataPoints = new Array();
    var dataPoints2 = new Array();
    var yValue;
    var xValue = 0;
    var yValue2;
    var xValue2 = 0;

    var loanAfterIncrement = 0;

    for (i = 1; i < 26; i++) {
        yValue = totalLoan - (i * payBackPerYear);
        xValue++;
        if (yValue <= 0) { break; }
        dataPoints.push({ x: xValue, y: yValue });
    }


    if (NoOfIncrementYear != 0 && payBackPerYear != 0) {

        NoOfIncrementYear = NoOfIncrementYear + 1;

        for (j = 1; j < NoOfIncrementYear; j++) {
            yValue2 = totalLoan - (j * payBackPerYear);
            xValue2++;
            if (yValue2 <= 0) { break; }
            dataPoints2.push({ x: xValue2, y: yValue2 });
        }

        loanAfterIncrement = yValue2;
        var yearUpto = 25 - (NoOfIncrementYear - 1);

        if (j == NoOfIncrementYear) {
            for (p = 1; p <= yearUpto; p++) {
                yValue2 = loanAfterIncrement - (p * payBackPerYear2);
                xValue2++;
                if (yValue2 <= 0) { break; }
                dataPoints2.push({ x: xValue2, y: yValue2 });
            }
        }

    }

    var chart = new CanvasJS.Chart("chartContainer", {

        backgroundColor: "rgba(255, 255, 255, 0.6)",
        animationEnabled: true,
        theme: "theme2",//theme2
        title: {
            text: "Graph showing the value of the loan through repayments",
            fontSize: 27,
        },
        axisX: {
            title: "Time in years"

        },
        axisY: {
            title: "Amount left to pay (£)",
            //interlacedColor: "azure"
        },
        animationEnabled: true,
        data: [
            {
                type: "line",
                dataPoints: dataPoints
            },
            {
                type: "line",
                dataPoints: dataPoints2
            }
        ]
    });
    chart.render();
}



