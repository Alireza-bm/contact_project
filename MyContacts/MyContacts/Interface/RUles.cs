using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts.Interface
{
    interface RUles
    {
        DataTable SelectAll();
        DataTable Row(int pid);
        DataTable Search(string parameter);
        bool Insert(string name, string family, int age, string email, string mobilePhone, string phone, string address);
        bool Update(int pid, string name, string family, int age, string email,string mobilePhone,string phone, string address);
        bool Delete(int pid);
        //bool Insert(string name, string family, int age, string email, string address);
    }
}
