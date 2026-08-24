using FutureValueModelMVC.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Content("""
<!DOCTYPE html>
<html>
<head>
    <title>Future Value Calculator</title>
</head>
<body>
    <h1>Future Value Calculator</h1>

    <form method="post" action="/calculate">

        <p>
            <label>Monthly Investment:</label>
            <input type="number" name="monthlyInvestment"
                   step="0.01" value="100" />
        </p>

        <p>
            <label>Interest Rate (%):</label>
            <input type="number" name="interestRate"
                   step="0.01" value="5" />
        </p>

        <p>
            <label>Number of Years:</label>
            <input type="number" name="years"
                   value="10" />
        </p>

        <button type="submit">Calculate</button>

    </form>
</body>
</html>
""", "text/html"));

app.MapPost("/calculate", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();

    decimal monthlyInvestment =
        decimal.Parse(form["monthlyInvestment"].ToString());

    decimal interestRate =
        decimal.Parse(form["interestRate"].ToString());

    int years =
        int.Parse(form["years"].ToString());

    var model = new FutureValueModel
    {
        MonthlyInvestment = monthlyInvestment,
        InterestRate = interestRate,
        Years = years
    };

    model.CalculateFutureValue();

    return Results.Content($"""
<!DOCTYPE html>
<html>
<head>
    <title>Future Value Calculator</title>
</head>
<body>
    <h1>Future Value Calculator</h1>

    <h2>Future Value: {model.FutureValue:C2}</h2>

    <a href="/">Calculate Another Value</a>
</body>
</html>
""", "text/html");
});

app.Run();
