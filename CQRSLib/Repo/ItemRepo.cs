using CQRSLib.Data;
using CQRSLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLib.Repo
{
    public class ItemRepo : IItemRepo
    {
        private readonly AppdbContext _db;

        public ItemRepo(AppdbContext db)
        {
             _db=db;
        }

        public int DeleteItem(int id)
        {
            Item item= _db.Items.FirstOrDefault(x => x.Id == id);
            _db.Items.Remove(item);

            return _db.SaveChanges();

        }

        public List<Item> GetItems()
        {

            List<Item> item = _db.Items.ToList();

            return item ?? new();
        }

         public int InsertItem(Item item)  
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return _db.SaveChanges(); ;
        }

        public Item Item(int id)
        {
           Item item = _db.Items.Where(x=> x.Id==id).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public int UpdateItem(Item item)
        {
           
            Item it = _db.Items.FirstOrDefault(x => x.Id == item.Id);
            if (it == null)
            {
                return it.Id;
            }

            it.Id = item.Id;
            it.Name = item.Name;
            it.Price = item.Price;
             

            return _db.SaveChanges();

        }
    }
}
