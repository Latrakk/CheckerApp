using System;
using Xamarin.Forms;

namespace CheckerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

        }

        public async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (LoginEntry.Text == null || PasswordEntry.Text == null)
            {
                ErrorText.Text = "Поля не могут быть пустыми";
                ErrorText.IsVisible = true;
            }

            else
            {

                try
                {
                    DataProcessor data = new DataProcessor();
                    var user = data.GetUser(LoginEntry.Text);

                    if (user.Login == LoginEntry.Text && user.Password == PasswordEntry.Text)
                    {
                        await Navigation.PushAsync(new MenuPage());
                    }
                    else
                    {
                        ErrorText.Text = "Неправильный логин или пароль";
                        ErrorText.IsVisible = true;
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.ToString(), "Ok");
                }
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
