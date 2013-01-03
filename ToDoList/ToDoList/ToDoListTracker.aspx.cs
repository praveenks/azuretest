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
            string connectionString = GetConnectionString();
            
            if (!IsPostBack)
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    //to check stored proc
                    sqlCmd.CommandText = "GetToDoList";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlCmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        sqlDataAdapter.SelectCommand = sqlCmd;
                        sqlDataAdapter.Fill(dt);
                        grdToDoList.DataSource = dt;
                        grdToDoList.DataBind();
                        btnUpdate.Visible = dt.Rows.Count > 0;
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                //to check plain query
                sqlCmd.CommandText = string.Format("Insert into ToDoList (Name, Completed) Values('{0}','{1}')", txtTask.Text, 0);
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                //to check stored proc
                sqlCmd.CommandText = "GetToDoList";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    sqlDataAdapter.SelectCommand = sqlCmd;
                    sqlDataAdapter.Fill(dt);
                    grdToDoList.DataSource = dt;
                    grdToDoList.DataBind();
                    btnUpdate.Visible = dt.Rows.Count > 0;
                }
            }

            txtTask.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            foreach (GridViewRow row in grdToDoList.Rows)
            {
                
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    //to check plain query

                    sqlCmd.CommandText = string.Format("Update ToDoList SET Completed='{0}' Where Id = '{1}'", ((CheckBox)row.FindControl("chkCompleted")).Checked ? 1 : 0, ((Label)row.FindControl("lblId")).Text);
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlCmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        SqlTransaction transaction = sqlConnection.BeginTransaction("SampleTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                //to check stored proc
                sqlCmd.CommandText = "GetToDoList";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    sqlDataAdapter.SelectCommand = sqlCmd;
                    sqlDataAdapter.Fill(dt);
                    grdToDoList.DataSource = dt;
                    grdToDoList.DataBind();
                    btnUpdate.Visible = dt.Rows.Count > 0;
                }
            }
        }

        private string GetConnectionString()
        {
            ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings["SqlConnectionString1"];
            return connectionSettings.ConnectionString;
        }
    }
}