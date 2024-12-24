using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using androidTEST.Views;


namespace androidTEST.ViewModels;

public class MenuViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand PhotoCommand { get; private set; }
    private string _loginID = "";
    private bool _isDeepLink = false;
    private ImageSource _displayPhoto = "";

    public string LoginID
    {
        get { return _loginID; }
        private set
        {
            _loginID = value;
            OnPropertyChanged(nameof(LoginID));
        }
    }

    public bool IsDeepLink
    {
        get { return _isDeepLink; }
        private set
        {
            _isDeepLink = value;
            OnPropertyChanged(nameof(IsDeepLink));
        }
    }

    public ImageSource DisplayPhoto
    {
        get { return _displayPhoto; }
        private set
        {
            _displayPhoto = value;
            OnPropertyChanged(nameof(DisplayPhoto));
        }
    }

    public MenuViewModel()
    {
        PhotoCommand = new Command(async () => await GoToPhotoPage());
    }

    public async Task GoToPhotoPage()
    {
        MauiProgram.NextPage = nameof(PhotoPage);
        await Shell.Current.GoToAsync("..", false);
    }

    public async Task NavigatedTo()
    {
        LoginID = MauiProgram.UserID;
        IsDeepLink = MauiProgram.DeepLink;
        DisplayPhoto = MauiProgram.PhotoData;
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

}
