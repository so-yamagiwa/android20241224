using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;
using androidTEST.Views;

namespace androidTEST
{
    [Activity(Theme = "@style/Maui.SplashTheme"
        , MainLauncher = true
        , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density
        , LaunchMode =LaunchMode.SingleTop
        )]
    [IntentFilter(
     actions: new[] { Intent.ActionView }
    , Categories = new[] { Intent.ActionView, Intent.CategoryDefault, Intent.CategoryBrowsable }
    , DataHost = ""
    , DataScheme = "androidtest"
    , DataPathPrefix = "/"
    )]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if (this.Intent != null)
            {
                this.Intent.SetAction(intent.Action);
                this.Intent.SetData(intent.Data);
                this.Intent.SetFlags(intent.Flags);
            }

        }

        protected override void OnResume()
        {
            base.OnResume();

            var intent = this.Intent;

            if (Intent.ActionView.Equals(intent.Action))
            {
                CheckAndLaunch(intent);
                if (Intent.Data != null)
                {
                    Intent.SetData(null);
                }
            }
        }

        private async void CheckAndLaunch(Intent intent)
        {
            var uri = intent.Data;

            if (uri == null) return;

            MauiProgram.DeepLink = true;
            MauiProgram.UserID = uri.GetQueryParameter("userid");

            MauiProgram.NextPage = nameof(LoginPage);
            await Shell.Current.GoToAsync("///" + nameof(MainPage), false);
        }

    }
}
