using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EmployeeTrackerApp
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionPath;
            connectionPath = "C:\\Users\\dinan\\Documents\\GitHub\\EmployeeTrackerApp\\EmployeeTrackerApp\\EmployeeTrackerApp\\EmployeeTracker.mdf";
            connection.ConnectionString = @"Data Source=(LocalDB)\v11.0;"+
                "AttachDbFilename="+connectionPath+"Integrated Security=True";
            cmd.Connection = connection;

        }


    }
}
