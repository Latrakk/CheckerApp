using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                User user = new User();
                user.Login = LoginEntry.Text;
                user.Password = PasswordEntry.Text;
                user.Name = NameEntry.Text;
                user.Password = PasswordEntry.Text;
                user.Surname = SurnameEntry.Text;
                user.Permission = "User";
                DataProcessor data = new DataProcessor();
                data.PostUser(user);
                StatusText.Text = "Успешно";
                StatusText.TextColor = Color.Green;
                StatusText.IsEnabled = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
    }
}