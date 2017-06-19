using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Examens
    {

        public static List<Examen> getAllExamen()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
            string select = "SELECT * FROM \"Examen\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();



            List<Examen> examen = MyData.AsEnumerable().Select(row =>

                new Examen()
                {
                    Type =  row.Field<string>("type_examen"), 
                    Date = row.Field<string>("date"),
                    LeModule = Modules.getModules().FirstOrDefault(c => c.Id == row.Field<int>("id_module"))
                }

            ).ToList();
            examen.Cast<Examen>();
            
            return examen;
        }
    }


    }

