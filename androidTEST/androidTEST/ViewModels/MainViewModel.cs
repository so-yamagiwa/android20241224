using androidTEST.Views;

namespace androidTEST.ViewModels;

public class MainViewModel
{

    public async Task NavigatedTo()
    {
        await Task.Delay(1);
        await ChangePage();
    }

    private async Task ChangePage()
    {
        await Shell.Current.GoToAsync(MauiProgram.NextPage, false);
    }

}
