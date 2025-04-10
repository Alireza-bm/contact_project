using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyContacts.Classes;
using MyContacts.Interface;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        RUles contact;
        add_and_edite frm;
        public Form1()
        {
            InitializeComponent();
            contact = new Ccontact();
            frm = new add_and_edite();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listData();
        }
        
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            listData();
        }

        #region Function
        private void listData()
        {
            dgContanct.AutoGenerateColumns = false;
            dgContanct.DataSource = contact.SelectAll();
        }
        #endregion

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                listData();
            }
        }
        private void btnEdite_Click(object sender, EventArgs e)
        {
            if (dgContanct.CurrentRow != null)
            {
                int pid =int.Parse(dgContanct.CurrentRow.Cells[0].Value.ToString());
                frm.pid = pid;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    listData();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک سطر را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContanct.CurrentRow != null)
            {
                string name = Convert.ToString(dgContanct.CurrentRow.Cells[1].Value);
                string family = Convert.ToString(dgContanct.CurrentRow.Cells[2].Value);
                string fullName = name + " " + family;
                if ( MessageBox.Show("مطمئن هستید ؟؟  "+fullName+"  آیا از حذف","توجه",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    contact.Delete(Convert.ToInt32(dgContanct.CurrentRow.Cells[0].Value));
                    listData();
                    
                }
            }
            else
            {
                MessageBox.Show("لطفا یک سطر را انتخاب کنید");
              
            }
        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {
            dgContanct.DataSource = contact.Search(txtSerch.Text);
        }
    }
}
