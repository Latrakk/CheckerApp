
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageFlyout : ContentPage
    {
        public ListView ListView;

        public MenuPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuPageFlyoutViewModel();
            ListView = MenuItemsListView;

        }

        public class MenuPageFlyoutViewModel : INotifyPropertyChanged
        {

            public ObservableCollection<MenuPageFlyoutMenuItem> MenuItems { get; set; }

            public MenuPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuPageFlyoutMenuItem>(new[]
                {

                    new MenuPageFlyoutMenuItem { Id = 0, Title = "Объекты",TargetType = typeof(LocationsPage)},
                    new MenuPageFlyoutMenuItem { Id = 1, Title = "Админ",TargetType = typeof(AdminPage)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}