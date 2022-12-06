using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        public LocationsPage()
        {
            InitializeComponent();
            SuccessText.IsVisible = false;
            try
            {

                DataProcessor data = new DataProcessor();
                var location = data.GetLocations();
                LocationsListView.ItemsSource = location;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var location = LocationsListView.ItemsSource as List<Location>;

            try
            {
                for (int i = 1; i != location.Count; i++)
                {

                    var locationItem = location[i];

                    var json = JsonConvert.SerializeObject(locationItem);
                    var StringContent = new StringContent(json);
                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), "http://checkerapi.ru/location/" + locationItem.Id.ToString());
                    request.Content = StringContent;
                    var response = client.SendAsync(request);
                    SuccessText.IsVisible = true;

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Ok");
            }

        }


        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            try
            {
                DataProcessor data = new DataProcessor();
                var location = data.GetLocations();

                LocationsListView.ItemsSource = location;
                RefreshView.IsRefreshing = false;

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
    }
}