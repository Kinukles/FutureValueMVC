namespace FutureValueMVC.Models
{
    public class FutureValueModelMVC
    {
        public decimal MonthlyInvestment { get; set; }

        public decimal YearlyInterestRate { get; set; }

        public int Years { get; set; }

        public decimal CalculateFutureValue()
        {
            decimal monthlyInterestRate = YearlyInterestRate / 12 / 100;
            int months = Years * 12;

            decimal futureValue = 0;

            for (int i = 0; i < months; i++)
            {
                futureValue += MonthlyInvestment;
                futureValue += futureValue * monthlyInterestRate;
            }

            return futureValue;
        }
    }
}
