using AppliFraisMobile.Models;
using AppliFraisMobile.Views.Comptable;
using AppliFraisMobile.Views.Visiteur;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppliFraisMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.ListeUser, new NavigationPage(new ListeUser()));
            Detail = MenuPages[(int)MenuItemType.ListeUser];
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    //case (int)MenuItemType.Browse:
                    //    MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                    //    break;
                    //case (int)MenuItemType.About:
                    //                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                    //                        break;
                    case (int)MenuItemType.ListeUser:
                        MenuPages.Add(id, new NavigationPage(new ListeUser()));
                        break;
                    case (int)MenuItemType.SelectUserSuivie:
                        MenuPages.Add(id, new NavigationPage(new SelectUserSuivie()));
                        break;
                    case (int)MenuItemType.SelectUserValidation:
                        MenuPages.Add(id, new NavigationPage(new SelectUserValidation()));
                        break;
                    case (int)MenuItemType.SuiviFrais:
                        MenuPages.Add(id, new NavigationPage(new SuiviFrais()));
                        break;
                    case (int)MenuItemType.ValidationFrais:
                        MenuPages.Add(id, new NavigationPage(new ValidationFrais()));
                        break;
                    case (int)MenuItemType.Connexion:
                        MenuPages.Add(id, new NavigationPage(new Connexion()));
                        break;
                    case (int)MenuItemType.SaisiFrais:
                        MenuPages.Add(id, new NavigationPage(new SaisiFrais()));
                        break;
                    case (int)MenuItemType.EtatFrais:
                        MenuPages.Add(id, new NavigationPage(new EtatFrais()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}