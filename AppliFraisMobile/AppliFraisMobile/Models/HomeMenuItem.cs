using System;
using System.Collections.Generic;
using System.Text;

namespace AppliFraisMobile.Models
{
    public enum MenuItemType
    {
        //Browse,
        //About,
        ListeUser,
        SelectUserSuivie,
        SelectUserValidation,
        SuiviFrais,
        ValidationFrais,
        Connexion,
        SaisiFrais,
        EtatFrais,

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
