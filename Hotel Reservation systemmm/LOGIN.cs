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

namespace Hotel_Reservation_systemmm
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\HotelDatBase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)from LOG_TBL Where username = '" + textBoxUsername.Text + "'and password = '" 
                + textBoxPassword.Text + "' and Type = '" + TypeCB.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select Type from LOG_TBL Where username = '" + textBoxUsername.Text + "'and password = '" 
                    + textBoxPassword.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "SERVER")
                {
                    this.Hide();
                   Reservation ss = new Reservation();
                    ss.Show();


                }
             


            }
        }

        private void Passcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Passcheckbox.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
