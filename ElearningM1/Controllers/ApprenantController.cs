using ElearningM1.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningM1.Controllers
{
    public class ApprenantController : Controller
    {
       


       

        public DataTable Connexion(String requette)
        {

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearning;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();

            NpgsqlCommand MyCmd = new NpgsqlCommand(requette, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();

            return MyData;
        }

    }
}