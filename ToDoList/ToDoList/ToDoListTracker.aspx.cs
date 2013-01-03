using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList
{
    public partial class ToDoListTracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringsSection csSection = new ConnectionStringsSection();
            ConnectionStringSettings connectionSettings = csSection.ConnectionStrings["SqlConnectionString1"];
            string connectionString = connectionSettings.ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            
        }
    }
}