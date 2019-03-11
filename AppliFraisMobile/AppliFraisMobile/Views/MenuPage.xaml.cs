using AppliFraisMobile.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppliFraisMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                //new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                //new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.ListeUser, Title="Liste" },
                new HomeMenuItem {Id = MenuItemType.SelectUserSuivie, Title="SelectUserSuivie" },
                new HomeMenuItem {Id = MenuItemType.SelectUserValidation, Title="SelectUserValidation" },
                new HomeMenuItem {Id = MenuItemType.SuiviFrais, Title="SuiviFrais" },
                new HomeMenuItem {Id = MenuItemType.ValidationFrais, Title="ValidationFrais" },
                new HomeMenuItem {Id = MenuItemType.Connexion, Title="Connexion" },
                new HomeMenuItem {Id = MenuItemType.SaisiFrais, Title="SaisiFrais" },
                new HomeMenuItem {Id = MenuItemType.EtatFrais, Title="EtatFrais" },
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}