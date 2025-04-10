using MyContacts.Classes;
using MyContacts.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class add_and_edite : Form
    {
        RUles add_edite;
        public int pid = 0;
        public add_and_edite()
        {
            InitializeComponent();
            add_edite = new Ccontact();
        }
        private void add_and_edite_Load(object sender, EventArgs e)
        {
            if (pid == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش";
                DataTable dt =add_edite.Row(pid);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                numAge.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtPhoneH.Text = dt.Rows[0][5].ToString();
                txtPhoneS.Text = dt.Rows[0][6].ToString();


                btnSubmit.Text = "ویرایش";
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        bool validInput()                   
        {
            bool valid = true;                                                                                  
             if (txtName.Text == "") 
            {
                valid = false;
                MessageBox.Show("لطفا نام را وارد کنید","هشدار",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
             else if (txtFamily.Text == "")       
            {
                valid = false;
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (numAge.Value == 0)
            {
                valid = false;
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtEmail.Text == "")
            {
                valid = false;
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPhoneH.Text == "")
            {
                valid = false;
                MessageBox.Show("لطفا شماره تلفن همراه را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return valid;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validInput())
            {
                bool success;
                if (pid == 0)
                {
                    success= add_edite.Insert(txtName.Text, txtFamily.Text, (int)numAge.Value, txtEmail.Text, txtPhoneH.Text, txtPhoneS.Text, txtAddress.Text);
                }
                else
                {
                    success = add_edite.Update(pid, txtName.Text, txtFamily.Text,(int)numAge.Value, txtEmail.Text, txtPhoneH.Text, txtPhoneS.Text, txtAddress.Text);
                }
                if (success == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
