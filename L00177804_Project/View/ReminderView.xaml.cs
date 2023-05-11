namespace L00177804_Project.View;

public partial class ReminderView : ContentPage
{
	public ReminderView(ReminderViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
       
    }
}