using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Reservation_systemmm
{
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }

        private void client_TBLBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.client_TBLBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.modelDataSet);

        }

        private void Reservation_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'modelDataSet.Client_TBL' table. You can move, or remove it, as needed.
            this.client_TBLTableAdapter.Fill(this.modelDataSet.Client_TBL);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.labelTimenow.Text = dateTime.ToString();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN back = new LOGIN();
            back.ShowDialog();
            

        }
    }
}
