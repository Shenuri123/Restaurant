using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantTuto
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
        }
        Functions Con;

        private void ShowItems()
        {
            try
            {
                string Query = "select * from ItemTbl";
                ItemsList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        int n = 0;
        int GrdTotal = 0;

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                int Qte = Convert.ToInt32(QtyTb.Text);
                int Total = Convert.ToInt32(PriceTb.Text) * Qte;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ItemTb.Text;
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QtyTb.Text;
                newRow.Cells[4].Value = "Rs " + Total;

                BillDGV.Rows.Add(newRow);
                n++;
                GrdTotal = GrdTotal + Total;
                GrdTotalLbl.Text = "Rs " + GrdTotal;
            }
        }
        int key = 0;

        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            //CatCb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            if (ItemTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
