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
using System.IO;


namespace EmployeeTrackerApp
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlParameter imageParam = new SqlParameter("@image", SqlDbType.Image);
        Image img;
        string pictureName;


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

        //Capture Screenshots
        public void Capture()
        {
            SendKeys.Send("{PRTSC}");
            img = Clipboard.GetImage();
            pictureName = DateTime.Now.ToString("ddmmyyhmmss");
        }

        //Save Picture into Database
        public void SavePicture()
        {
            // save image from clipboard as data of bytes to be inserted into database
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.ToArray();
            ms.Close();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@image", data);
            cmd.CommandText = "insert into Screenshots (Name,Image) values ('"
                + pictureName + "', @image)";
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}
