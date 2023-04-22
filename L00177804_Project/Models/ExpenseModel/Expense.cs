namespace L00177804_Project.Models.ExpenseModel
{
    public class Expense
    {

        public string ExpenseName { get; set; }
        public DateOnly ExpenseDate { get; set; }
        public double ExpenseCost { get; set; }
        public string ExpenseDateAsString { get; set; }

    }
}
