using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Profil
    {
        private string nom, dateNaiss, prenom, email, mdp, telephone, adresse;
        private int id;

        public Profil()
        { }

        public Profil(string nom, string dateNaiss, string prenom, string email, int id, string mdp, string telephone, string adresse)
        {
            this.nom = nom;
            this.dateNaiss = dateNaiss;
            this.prenom = prenom;
            this.email = email;
            this.id = id;
            this.mdp = mdp;
            this.telephone = telephone;
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

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        public string Mdp { get => mdp; set => mdp = value; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [RegularExpression(@"(0|\\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Veuillez saisir un numéro de téléphone à 10 chiffres.")]
        public string Telephone { get => telephone; set => telephone = value; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        public string Adresse { get; set; }
    }
}