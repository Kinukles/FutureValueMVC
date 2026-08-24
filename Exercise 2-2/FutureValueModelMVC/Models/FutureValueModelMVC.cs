namespace FutureValueModelMVC.Models
{
    public class FutureValueModel
    {
        public decimal MonthlyInvestment { get; set; }
        public decimal InterestRate { get; set; }
        public int Years { get; set; }
        public decimal FutureValue { get; set; }

        public void CalculateFutureValue()
        {
            decimal monthlyRate = InterestRate / 100 / 12;
            int months = Years * 12;

            FutureValue = 0;

            for (int i = 0; i < months; i++)
            {
                FutureValue = (FutureValue + MonthlyInvestment) *
                               (1 + monthlyRate);
            }
        }
    }
}
