using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=integra-net4;Initial Catalog=iPMS;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserDetails";
            cmd.Connection = con;

            try
            {
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
                gridControl1.Show();
            }
            catch (Exception )
            {}
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
