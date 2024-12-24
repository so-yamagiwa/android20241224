using androidTEST.ViewModels;

namespace androidTEST.Views;

public partial class MenuPage : ContentPage
{
    private MenuViewModel _vM;
    
    public MenuPage(MenuViewModel viewModel)
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