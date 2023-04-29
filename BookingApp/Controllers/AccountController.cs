using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BookingApp.Models;

namespace BookingApp.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BookingApp;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        }

        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Admin where AdminName='"+acc.Name+"' and Password'"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}