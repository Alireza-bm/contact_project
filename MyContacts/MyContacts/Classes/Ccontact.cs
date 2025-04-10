using MyContacts.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts.Classes
{
    class Ccontact : RUles
    {
        private string conection = "Data Source =. ; Initial Catalog = DB_1;Integrated Security=true";

        public bool Delete(int pid)
        {
            SqlConnection conect = new SqlConnection(conection);
            try {
                string query = "Delete  From Table_1 Where PId=@ID";
                SqlCommand command = new SqlCommand(query,conect);
                command.Parameters.AddWithValue("@ID", pid);
                conect.Open();
                command.ExecuteNonQuery();
                conect.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conect.Close();
            }
        }

        /*public void Insert(TextBox txtName, TextBox txtFamily, decimal value, TextBox txtEmail, TextBox txtAddress)
        {
            throw new NotImplementedException();
        }*/

        public bool Insert(string name, string family, int age, string email,string mobilePhone,string phone, string address)
        {
            SqlConnection conect = new SqlConnection(conection);
            try {
                string query = "Insert Into Table_1 (Name,Family,Age,Email,MobilePhone,Phone,Address) values (@Name,@Family,@Age,@Email,@MobilePhone,@Phone,@Address)";
                SqlCommand command = new SqlCommand(query, conect);
                command.Parameters.AddWithValue("@Name",name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);
                conect.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conect.Close();
            }
            
        }

        public DataTable Row(int pid)
        {
            string query = "Select * From Table_1 where PId=" + pid;
           // SqlConnection connections = new SqlConnection(conection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
            DataTable data = new DataTable();
        
            adapter.Fill(data);
            return data;


            //string query = "Select * From MyContacts where ContactID=" + contactId;
            //SqlConnection connection = new SqlConnection(connectionString);
            //SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            //DataTable data = new DataTable();
            //adapter.Fill(data);
          //  return data;
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From Table_1 where Name LIKE @parameter or Family LIKE @parameter";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
            DataTable datas = new DataTable();
            adapter.Fill(datas);
            return datas;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From Table_1";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
            DataTable datas = new DataTable();
            adapter.Fill(datas);
            return datas;

        }

        public bool Update(int pid, string name, string family, int age, string email, string mobilePhone, string phone, string address)
        {
            SqlConnection conect = new SqlConnection(conection);
            try
            {
                string query = "Update Table_1 Set Name=@Name,Family=@Family,Age=@Age,Email=@Email,MobilePhone=@MobilePhone,Phone=@Phone,Address=@Address Where PId=@ID";
                SqlCommand command = new SqlCommand(query, conect);
                command.Parameters.AddWithValue("@ID", pid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);
                conect.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                conect.Close();
            }
        }

       

        /*DataTable RUles.Row(int pid)
        {
            throw new NotImplementedException();
        }*/

       

        /*bool RUles.Update(int pid, string name, string family, int age, string email,string mobilePhone,string phone, string address)
        {
            throw new NotImplementedException();
        }*/
    }
}
