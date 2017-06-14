using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public static class RespPedagogiques
    {


        public static void Aff_A_Module(int id_module , int id_A)
        {

            String insert = "Insert Into \"Affecter_A_Module\"(id_module,id_apprenant) Values(" + id_module + "," + id_A + ") ";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");
            conn.Open();
            NpgsqlCommand MyCmd = new NpgsqlCommand(insert, conn);

            MyCmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void Aff_A_Te(int id_app, int id_tuteur)
        {
            String insert = "Insert Into \"Affecter_A_TE\"(id_apprenant,id_te) Values(" + id_app + "," + id_tuteur + ") ";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");
            conn.Open();
            NpgsqlCommand MyCmd = new NpgsqlCommand(insert, conn);
            MyCmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void Aff_Module_Semestre(int id_semestre, int id_module)
        {
            String insert = "Insert Into \"Affecter_Module_Semestrex\"(id_semestre,id_module) Values(" + id_semestre + "," + id_module + ") ";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");
            conn.Open();
            NpgsqlCommand MyCmd = new NpgsqlCommand(insert, conn);
            MyCmd.ExecuteNonQuery();
            conn.Close();

        }



        public static void Aff_A_Exam(int id_app, int id_exam)
        {
            String insert = "Insert Into \"Affecter_Module_Semestrex\"(id_semestre,id_module) Values(" + id_app + "," + id_exam + ") ";
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");
            conn.Open();
            NpgsqlCommand MyCmd = new NpgsqlCommand(insert, conn);
            MyCmd.ExecuteNonQuery();
            conn.Close();
        }





    }
}