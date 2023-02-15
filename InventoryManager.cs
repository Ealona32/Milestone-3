using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone3
{
    public class InventoryManager
    {
        private ItemModel[] items = new ItemModel[0];

        public int GetInventoryCount() => items.Length;


        public ItemModel[] GetInventoryList() => items;

        public void Add(ItemModel i)
        {
            var l = items.Length + 1;
            Array.Resize<ItemModel>(ref items, l);
            items[l - 1] = i;
        }

        public void Remove(int id)
        {
            if (items == null) return;

            if (items.Any(c => c.Id.ToString() == id.ToString()))
            {
                ItemModel[] temp = new ItemModel[items.Length - 1];
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Id != id)
                    {
                        temp[i - 1] = items[i];
                    }
                }

                Array.Resize<ItemModel>(ref items, items.Length - 1);
                temp.CopyTo(items, 0);
            }
        }

        public void Display(bool UI = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in items)
                sb.AppendLine(i.ToString());

            if (sb.Length > 0)
            {
                if (UI)
                    System.Windows.Forms.MessageBox.Show(sb.ToString());
                else
                    System.Diagnostics.Debug.WriteLine(sb.ToString());
            }
            else
            {
                if (UI)
                    System.Windows.Forms.MessageBox.Show("No items in inventory");
                else
                    System.Diagnostics.Debug.WriteLine("No items in inventory");
            }
        }


        public ItemModel[] Search(string name)
        {
            var l = new List<ItemModel>();
            foreach (var i in items)
            {
                if (i.Name == name)
                    l.Add(i);
            }
            return l.ToArray();
        }

        public ItemModel[] SearchNQ(string name, int Qty = -1)
        {
            var l = new List<ItemModel>();
            foreach (var i in items)
            {
                if (Qty == -1)
                {
                    if (i.Name == name)
                        l.Add(i);
                }
                else
                {
                    if (i.Name == name && i.Quantity == Qty)
                        l.Add(i);
                }
            }
            return l.ToArray();
        }

        public ItemModel[] SearchNP(string name, int price = -1)
        {
            var l = new List<ItemModel>();
            foreach (var i in items)
            {
                if (i.Name == name && i.Price == price)
                    l.Add(i);
            }
            return l.ToArray();
        }

        public void ReStock(int Qty, int id)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Id.ToString() == id.ToString())
                    items[i].Quantity += Qty;
            }
        }
    }
}
