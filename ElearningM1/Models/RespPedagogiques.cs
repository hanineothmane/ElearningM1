using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Web.Mvc;
using ElearningM1.BD;


namespace ElearningM1.Models
{
    public static class RespPedagogiques
    {


        public static void Aff_A_Module(int id_module , int id_A)
        {

            string select = "Insert Into \"Affecter_A_Module\"(id_module,id_apprenant) Values(" + id_module + "," + id_A + ") ";
            BDD.ExecuteNonQuery(select);
        }

        public static void Aff_A_Te(int id_app, int id_tuteur)
        {
            string select = "Insert Into \"Affecter_A_TE\"(id_apprenant,id_te) Values(" + id_app + "," + id_tuteur + ") ";
            BDD.ExecuteNonQuery(select);

        }

        public static void Aff_Module_Semestre(int id_semestre, int id_module)
        {
            string select = "Insert Into \"Affecter_Module_Semestre\"(id_semestre,id_module) Values(" + id_semestre + "," + id_module + ") ";
            BDD.ExecuteNonQuery(select);

        }



        public static void Aff_A_Exam(int id_app, int id_exam)
        {
            string select = "Insert Into \"Affecter_Module_Semestrex\"(id_semestre,id_module) Values(" + id_app + "," + id_exam + ") ";
            BDD.ExecuteNonQuery(select);
        }





    }
}