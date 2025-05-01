using CQRSLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLib.Repo
{
    public interface IItemRepo
    {
        public List<Item> GetItems();
        public Item Item(int id);

        public int InsertItem(Item item);
        public int UpdateItem(Item item);
        public int DeleteItem(int id);

    }
}
