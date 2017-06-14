using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public static class Semestres
    {


        public static List<Semestre> getAllSemestre()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
            string select = "SELECT * FROM \"Semestre\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();



            List<Semestre> semestre = MyData.AsEnumerable().Select(row =>

                new Semestre(row.Field<string>("date_debut"), row.Field<string>("date_fin"), row.Field<int>("numero_semestre"))
                {
                    DateDebut = row.Field<string>("date_debut"),
                    DateFin = row.Field<string>("date_fin"),
                    NumSemestre = row.Field<int>("numero_semestre")

                }

            ).ToList();
            semestre.Cast<Semestre>();



            return semestre;


            
        }


    }
}