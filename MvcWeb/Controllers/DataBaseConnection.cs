using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MvcWeb.Controllers
{
    public class DataBaseConnection
    {
        private SqlConnection connection;
        public DataBaseConnection()
        {
            connection = new SqlConnection
                ("server=25fa972d-13ee-46be-84e5-a1d200e1e4a8.sqlserver.sequelizer.com;Initial Catalog=db25fa972d13ee46be84e5a1d200e1e4a8;User Id=pappkebdjsggdhkc;Password=kkavjDmnjZeget23P7BRdm7ojtyvHDXq6WuBSnqgXwAFf6dbZuHjXQc8nTkYeXLM");
        }
        public void Connec()
        {            
            connection.Open();
        }
        public void UnConnec()
        {
            connection.Close();
        }
    }
}