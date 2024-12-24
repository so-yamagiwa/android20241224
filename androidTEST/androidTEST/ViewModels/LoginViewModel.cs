using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using androidTEST.Views;

namespace androidTEST.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand LoginCommand { get; private set; }
    private string _loginID = "";
    private bool _isDeepLink = false;

    public string LoginID
    {
        get { return _loginID; }
        set
        {
            if(_loginID != value)
            {
                _loginID = value;
                OnPropertyChanged(nameof(LoginID));
            }
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

    public LoginViewModel()
    {
        LoginCommand = new Command(async () => await GoToMenuPage());
    }

    public async Task GoToMenuPage()
    {
        MauiProgram.UserID = _loginID;
        MauiProgram.NextPage = nameof(MenuPage);
        await Shell.Current.GoToAsync("//" + nameof(MainPage), false);
    }

    public async Task NavigatedTo()
    {
        if (MauiProgram.DeepLink == true)
        {
            string msg = "Launched with deep link";
            await Shell.Current.DisplayAlert("", msg, "OK");
        }

        LoginID = MauiProgram.UserID;
        IsDeepLink = MauiProgram.DeepLink;
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

}
