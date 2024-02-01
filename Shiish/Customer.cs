using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiish
{
    internal class Customer : DbManager
    {
        DbManager dbManager = new DbManager();
        
        public void Insertdatas(string a, string b, string c, string g)
        {
            dbManager.InsertRecordUser("users", "user_name", a, "user_surname", b, "user_email", c, "user_password", g);
        }

        public string FoundId(string a)
        {
            return dbManager.GetValueByColumn("user_email", a, "users", "user_id");
        }

        public string FoundRole(string a)
        {
            return dbManager.GetValueByColumn("user_email", a, "users", "user_role");
        }

        public string FoundPass(string a)
        {
            return dbManager.GetValueByColumn("user_email", a, "users", "user_password");
        }

    }
}
