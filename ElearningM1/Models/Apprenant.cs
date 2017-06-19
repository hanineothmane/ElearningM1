using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElearningM1.Models
{
    public class Apprenant
    {
        private string nom, dateNaiss, prenom, email, telephone, adresse, dateInscription;
        private int id;
        private List<Module> lesModules;

        public Apprenant()
        {

        }

        public Apprenant(string nom, string dateNaiss, string prenom, string email, int id, string telephone, string dateInscription, string adresse)
        {
            this.nom = nom;
            this.dateNaiss = dateNaiss;
            this.prenom = prenom;
            this.email = email;
            this.id = id;
            this.telephone = telephone;
            this.dateInscription = dateInscription;
            this.adresse = adresse;
        }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get => nom; set => nom = value; }
        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        public string DateNaiss { get => dateNaiss; set => dateNaiss = value; }
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string Prenom { get => prenom; set => prenom = value; }
        [Required(ErrorMessage = "L'email est obligatoire.")]
        public string Email { get => email; set => email = value; }
        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        public string Telephone { get => telephone; set => telephone = value; }
        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        public string Adresse { get => adresse; set => adresse = value; }
        [Required(ErrorMessage = "La date d'inscription est obligatoire.")]
        public string DateInscription { get => dateInscription; set => dateInscription = value; }
        public int Id { get => id; set => id = value; }
        public List<Module> LesModules { get => Modules.getModules(Id); set => lesModules = value; }
        
    }
}