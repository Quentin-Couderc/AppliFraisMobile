using System;
using System.Collections.Generic;
using System.Text;

namespace AppliFraisMobile.Models                                              
{                                                                              
    public class Visiteur                                                      
    {                                                                          
        public int Id { get; set; }                                            
        public string Nom { get; set; }                                        
        public string Prenom { get; set; }                                     
        public string Login { get; set; }                                      
        public string Mdp { get; set; }                                        
        public string Groupe { get; set; }                                     
        public string Adresse { get; set; }                                    
        public string Cp { get; set; }                                         
        public string Ville { get; set; }                                      
        public string DateEmbauche { get; set; }                               
    }                                                                          
}                                                                              
                                                                               