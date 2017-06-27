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
        [RegularExpression(@"^([a-zA-Z'àâéèêëôùûçîïÀÂÉÈÔÙÛÇ\s-]{1,30})$", ErrorMessage = "Veuillez saisir un nom correct.")]
        public string Nom { get => nom; set => nom = value; }

        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})", ErrorMessage = "Le format saisit doit être de type : jj/mm/aaaa.")]
        public string DateNaiss { get => dateNaiss; set => dateNaiss = value; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [RegularExpression(@"^([a-zA-Z'àâéèêëôùûçîïÀÂÉÈÔÙÛÇ\s-]{1,30})$", ErrorMessage = "Veuillez saisir un nom correct.")]
        public string Prenom { get => prenom; set => prenom = value; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", 
            ErrorMessage = "Veuillez saisir une adresse mail correcte.")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [RegularExpression(@"(0|\\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Veuillez saisir un numéro de téléphone à 10 chiffres.")]
        public string Telephone { get => telephone; set => telephone = value; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        public string Adresse { get => adresse; set => adresse = value; }

        [Required(ErrorMessage = "La date d'inscription est obligatoire.")]
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})", ErrorMessage = "Le format saisit doit être de type : jj/mm/aaaa.")]
        public string DateInscription { get => dateInscription; set => dateInscription = value; }

        public int Id { get => id; set => id = value; }

        public List<Module> LesModules { get => Modules.getModules(Id); set => lesModules = value; }
        
    }
}