using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiish
{
    internal class Item
    {
        DbManager dbManager = new DbManager();

        public void Insertdatas(string a, string b, string c)
        {
            dbManager.InsertRecordItem("items", "item_name", a, "item_type", b, "item_price", c);
        }

        public void DeleleItem(int a)
        {
            dbManager.DeleteRecordById(a, "items");
        }

        public void ChangeItem(int a, string b, string c) 
        {
            dbManager.ChangeValue(a, "items", b, c);
        }

        public void test(int a) 
        {

        }

    }
}
