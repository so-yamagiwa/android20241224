using androidTEST.ViewModels;

namespace androidTEST;

public partial class MainPage : ContentPage
{

    private MainViewModel _vM;

    public MainPage(MainViewModel viewModel)
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
