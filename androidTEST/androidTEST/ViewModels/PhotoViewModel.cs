using androidTEST.Views;

namespace androidTEST.ViewModels;

public class PhotoViewModel
{
    public async Task NavigatedTo()
    {

        MauiProgram.PhotoData = "";
        var photo = await MediaPicker.Default.CapturePhotoAsync();
        if (photo != null)
        {
            byte[] readData = [];
            using (var stream = await photo.OpenReadAsync())
            {
                Array.Resize(ref readData, (int)stream.Length);
                stream.Read(readData, 0, readData.Length);
                stream.Close();
            }
            MemoryStream memory = new MemoryStream(readData);
            MauiProgram.PhotoData = ImageSource.FromStream(() => memory);
        }

        MauiProgram.NextPage = nameof(MenuPage);
        await Shell.Current.GoToAsync("..", false);
    }

}
