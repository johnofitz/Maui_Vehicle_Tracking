namespace L00177804_Project.View;

public partial class ExpenseView : ContentPage
{
	public ExpenseView(ExpensesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}