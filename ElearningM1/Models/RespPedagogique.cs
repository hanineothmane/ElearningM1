using ElearningM1.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class RespPedagogique : Profil
    {

        public RespPedagogique() : base() { }

        public RespPedagogique(string nom, string dateNaiss, string prenom, string email, int id, string mdp, string telephone, string adresse) : base(nom, dateNaiss, prenom, email, id, mdp, telephone, adresse) { }

        #region Note
        public void AjouterNote(Affecter_A_Module aff, int id_app, int id_module)
        {
            Apprenant app = Apprenants.getApprenants().FirstOrDefault(a => a.Id == id_app);
            Module mod = Modules.getModules().FirstOrDefault(m => m.Id == id_module);
            aff.Apprenant = app;
            aff.Module = mod;
            Affecter_A_Modules.AddNote(aff);
        }
        #endregion

        #region Module
        public void AjouterModule(Module m, int id_te, int id_sr)
        {
            TuteurEnseignant te = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == id_te);
            SessionRegroupement sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == id_sr);
            m.Ens = te;
            m.Sr = sr;
            Modules.AddModule(m);
        }

        public void ModifierModule(int id, Module m, int id_te, int id_sr)
        {
            var mod = Modules.getModules().Single(mo => mo.Id == id);

            TuteurEnseignant te = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == id_te);
            SessionRegroupement sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == id_sr);

            mod.Id = m.Id;
            mod.Nom = m.Nom;
            mod.DateCreation = m.DateCreation;
            mod.Coef = m.Coef;
            mod.TypeModule = m.TypeModule;
            mod.Ens = te;
            mod.Sr = sr;

            Modules.Update(mod);
        }

        public void SupprimerModule(int id, Module m)
        {
            var mod = Modules.getModules().Single(mo => mo.Id == id);

            mod.Id = m.Id;
            mod.Nom = m.Nom;
            mod.DateCreation = m.DateCreation;
            mod.Coef = m.Coef;
            mod.TypeModule = m.TypeModule;


            Modules.DeleteModule(mod);

        }

        public List<Affecter_A_Module> LesApprenantsParModule(int id)
        {
            var mod = Modules.getModules().Single(m => m.Id == id);
            return Affecter_A_Modules.getAffectations(mod);
        }
        #endregion

        #region Apprenant
        public void AjouterApprenant(Apprenant a)
        {
            Apprenants.AddApprenant(a);
        }

        public void ModifierApprenant(int id, Apprenant a)
        {
            var app = Apprenants.getApprenants().Single(ap => ap.Id == id);

            app.Id = a.Id;
            app.Nom = a.Nom;
            app.Prenom = a.Prenom;
            app.DateNaiss = a.DateNaiss;
            app.Email = a.Email;
            app.Telephone = a.Telephone;
            app.Adresse = a.Adresse;
            app.DateInscription = a.DateInscription;

            Apprenants.Update(app);
        }

        public void SupprimerApprenant(int id, Apprenant a)
        {
            var app = Apprenants.getApprenants().Single(ap => ap.Id == id);

            app.Id = a.Id;
            app.Nom = a.Nom;
            app.Prenom = a.Prenom;
            app.DateNaiss = a.DateNaiss;
            app.Email = a.Email;
            app.Telephone = a.Telephone;
            app.Adresse = a.Adresse;
            app.DateInscription = a.DateInscription;


            Apprenants.DeleteApprenant(app);

        }

        public List<Affecter_A_Module> LesModulesParApprenant(int id)
        {
            var app = Apprenants.getApprenants().Single(ap => ap.Id == id);
            return Affecter_A_Modules.getAffectations(app);
        }
        #endregion

        #region Examen
        public void AjouterExamen(Examen e, int id_module)
        {
            Module module = Modules.getModules().FirstOrDefault(m => m.Id == id_module);
            e.LeModule = module;
            Examens.AddExamen(e);
        }


        public void ModifierExamen(int id, Examen e, int id_m)
        {
            var examen = Examens.getExamens().Single(ex => ex.Id == id);

            Module m = Modules.getModules().FirstOrDefault(mo => mo.Id == id_m);

            examen.Id = e.Id;
            examen.Type = e.Type;
            examen.LeModule = m;

            Examens.Update(examen);
        }

        public void SupprimerExamen(int id,Examen e)
        {
            var examen = Examens.getExamens().Single(ex => ex.Id == id);

            examen.Id = e.Id;
            examen.Type = e.Type;
            Examens.DeleteExamen(e);
        }

        public List<Examen> LesExamensParModule(int id)
        {
            var mod = Modules.getModules().Single(m => m.Id == id);
            return Modules.getAffectations(mod);
        }
        #endregion

        #region Session Regroupement
        public void AjouterSessionReg(SessionRegroupement sr)
        {
            SessionsRegroupement.AddSessionReg(sr);
        }

        public void ModifierSessionReg(int id, SessionRegroupement sr)
        {
            var s = SessionsRegroupement.getSessionsRegroupement().Single(ser => ser.Id == id);

            s.Id = sr.Id;
            s.Nom = sr.Nom;
            s.Date = sr.Date;

            SessionsRegroupement.UpdateSessionReg(s);
        }

        public void SupprimerSessionReg(int id, SessionRegroupement sr)
        {
            var s = SessionsRegroupement.getSessionsRegroupement().Single(ser => ser.Id == id);

            s.Id = sr.Id;
            s.Nom = sr.Nom;
            s.Date = sr.Date;

            SessionsRegroupement.DeleteSessionReg(s);

        }
        #endregion

        #region Affectations
        public void AffecterApprenantExamen(int id_A, int id_Exam)
        {
            RespPedagogiques.Aff_A_Exam(id_A, id_Exam);
        }

        public void AffecterApprenantModule(int id_module, int id_A)
        {
            RespPedagogiques.Aff_A_Module(id_module, id_A);
        }

        public void AffecterEnseignantApprenant(int id_app, int id_tuteur)
        {
            RespPedagogiques.Aff_A_Te(id_app, id_tuteur);
        }


        public void AffecterModuleSemestre(int id_semestre, int id_module)
        {
            RespPedagogiques.Aff_Module_Semestre(id_semestre, id_module);
        }
        #endregion

        #region Profil
        public void AjouterProfil(string type, Profil p)
        {
            if(type=="TE")
                TuteursEnseignant.AddTE(p);
            if (type == "RP")
                RespPedagogiques.AddRP(p);
        }

        public void ModifierProfil(string type, int id, Profil p)
        {
            if (type == "TE")
            {
                var tut = TuteursEnseignant.getTuteursEnseignant().Single(t => t.Id == id);

                tut.Id = p.Id;
                tut.Nom = p.Nom;
                tut.Prenom = p.Prenom;
                tut.DateNaiss = p.DateNaiss;
                tut.Email = p.Email;
                tut.Telephone = p.Telephone;
                tut.Adresse = p.Adresse;
                tut.Mdp = p.Mdp;

                TuteursEnseignant.UpdateTE(tut);
            }

            if (type == "RP")
            {
                var rp = RespPedagogiques.getRPs().Find(r => r.Id == id);
                rp.Id = p.Id;
                rp.Nom = p.Nom;
                rp.Prenom = p.Prenom;
                rp.DateNaiss = p.DateNaiss;
                rp.Email = p.Email;
                rp.Telephone = p.Telephone;
                rp.Adresse = p.Adresse;
                rp.Mdp = p.Mdp;

                RespPedagogiques.UpdateRP(rp);
            }
        }

        public void SupprimerProfil(string type, int id, Profil profil)
        {
            if (type == "TE")
            {
                var tu = TuteursEnseignant.getTuteursEnseignant().Find(t => t.Id == id);
                tu.Id = profil.Id;
                tu.Nom = profil.Nom;
                tu.Prenom = profil.Prenom;
                tu.DateNaiss = profil.DateNaiss;
                tu.Email = profil.Email;
                tu.Telephone = profil.Telephone;
                tu.Adresse = profil.Adresse;
                tu.Mdp = profil.Mdp;

                TuteursEnseignant.DeleteTE(tu);
            }

            if (type == "RP")
            {
                var rp = RespPedagogiques.getRPs().Find(r => r.Id == id);
                rp.Id = profil.Id;
                rp.Nom = profil.Nom;
                rp.Prenom = profil.Prenom;
                rp.DateNaiss = profil.DateNaiss;
                rp.Email = profil.Email;
                rp.Telephone = profil.Telephone;
                rp.Adresse = profil.Adresse;
                rp.Mdp = profil.Mdp;

                RespPedagogiques.DeleteRP(rp);
            }

        }
        #endregion
    }
}