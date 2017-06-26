using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class IDisp:IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~Utilisateurs() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }
        #endregion


        #region Utilisateurs Methodes

        public int AjouterUtilisateurs(String Nom , String Mdp)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Utilisateur utilisateur = new Utilisateur { Prenom = nom, MotDePasse = motDePasseEncode };
            bdd.Utilisateurs.Add(utilisateur);
            bdd.SaveChanges();
            return utilisateur.Id;
            
        }

        public Utilisateurs Authentifier(String Nom, String Mdp)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            return bdd.Utilisateurs.FirstOrDefault(u => u.Prenom == nom && u.MotDePasse == motDePasseEncode);
           
        }

        public Utilisateurs ObtenirUtilisateur(int id)
        {

            return bdd.Utilisateurs.FirstOrDefault(u => u.Id == id);
           
        }

     

        #endregion

    }
}