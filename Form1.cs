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
using System.Drawing.Text;

namespace CSharp_Quanlithongtin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAB1-MAY31\MISASME2022;Initial Catalog=QuangLiThongTin;Integrated Security=True");
        private  void opencon()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void closecon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(String cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
                throw;
            
            }
            closecon();
            return check;
            
                
            
        }
        private DataTable Red(string cmd)
        {
            opencon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda=new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            closecon();
            return dt;
        }
        private void load()
        {
            DataTable dt = Red("SELECT*FROM QuanLyThongTin");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
