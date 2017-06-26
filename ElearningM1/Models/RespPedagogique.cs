using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class RespPedagogique : Profil
    {
        public RespPedagogique(string nom, string dateNaiss, string prenom, string email, int id, string mdp, string telephone, string adresse) : base(nom, dateNaiss, prenom, email, id, mdp, telephone, adresse)
        {

        }

        //public void affecterEnseignantModule(TuteurEnseignant te, Module m) { }

        

        public void affecterEnseignantApprenant(TuteurEnseignant te, Apprenant a) { }

        public void AjouterNote(Affecter_A_Module aff, int id_app, int id_module)
        {
            Apprenant app = Apprenants.getApprenants().FirstOrDefault(a => a.Id == id_app);
            Module mod = Modules.getModules().FirstOrDefault(m => m.Id == id_module);
            aff.Apprenant = app;
            aff.Module = mod;
            Affecter_A_Modules.AddNote(aff);
        }
        
        public void AjouterProfil(Profil p)
        {
            TuteursEnseignant.AddTE(p);
        }

        public void ModifierProfil(int id, Profil p)
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

        public void SupprimerTE(int id, TuteurEnseignant te)
        {
            var tu = TuteursEnseignant.getTuteursEnseignant().Single(t => t.Id == id);

            tu.Id = te.Id;
            tu.Nom = te.Nom;
            tu.Prenom = te.Prenom;
            tu.DateNaiss = te.DateNaiss;
            tu.Email = te.Email;
            tu.Telephone = te.Telephone;
            tu.Adresse = te.Adresse;
            tu.Mdp = te.Mdp;

            TuteursEnseignant.DeleteTE(tu);

        }

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

        public void AjouterModule(Module m, int id_te, int id_sr)
        {
            TuteurEnseignant te = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == id_te);
            SessionRegroupement sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == id_sr);
            m.Ens = te;
            m.Sr = sr;
            Modules.AddModule(m);
        }

        public void ModifierModule(int id, Module m, int id_te, int id_sr) {
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

        public void consulterInfoApprenant(Apprenant a) { }

        public void consulterInfoTE(TuteurEnseignant te) { }

        public void affecterApprenantModule(Apprenant a, Module m) {
        }

        public void AffecterApprenantExamen(int id_A, int id_Exam)
        { 
            RespPedagogiques.Aff_A_Exam(id_A, id_Exam);
        }

        public List<Affecter_A_Module> LesModulesParApprenant(int id)
        {
            var app = Apprenants.getApprenants().Single(ap => ap.Id == id);
            return Affecter_A_Modules.getAffectations(app);
        }

        public void AjouterExamen(Examen e, int id_module)
        {
            Module module = Modules.getModules().FirstOrDefault(m => m.Id == id_module);
            e.LeModule = module;
            Examens.AddExamen(e);
        }

        public void ModifierModule(int id, Examen e, int id_m)
        {
            var examen = Examens.getExamens().Single(ex => ex.Id == id);

            Module m = Modules.getModules().FirstOrDefault(mo => mo.Id == id_m);

            examen.Id = e.Id;
            examen.Type = e.Type;
            examen.LeModule = m;

            Examens.Update(examen);
        }

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

    }
}