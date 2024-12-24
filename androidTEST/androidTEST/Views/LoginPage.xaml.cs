using androidTEST.ViewModels;

namespace androidTEST.Views;

public partial class LoginPage : ContentPage
{

    private LoginViewModel _vM;

    public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _vM = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _vM.NavigatedTo();
    }

}