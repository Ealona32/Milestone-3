using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone3
{
    public class ItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public string Description { get; set; }

        public ItemModel()
        {
            Random rnd = new Random();
            Id = rnd.Next();
        }

        public void Receive(int qty)
        {
            Quantity = qty;
        }

        public override string ToString()
        {
            return $"id:{Id} -  {Name} - Price:{Price} - Quantity: {Quantity}";
        }

    }
}
