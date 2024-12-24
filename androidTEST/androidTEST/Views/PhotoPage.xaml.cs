using androidTEST.ViewModels;

namespace androidTEST.Views;

public partial class PhotoPage : ContentPage
{
    private PhotoViewModel _vM;
    
    public PhotoPage(PhotoViewModel viewModel)
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