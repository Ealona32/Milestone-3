using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone3
{
    public class InventoryManagerUnitTests
    {
        public InventoryManagerUnitTests()
        {
            
        }

        public void RunTests()
        {
            VerifyAddItem();
            VerifyRemoveItem();
            VerifyDisplay();
            VerifyReStock();
            VerifySearch();
        }

        public void VerifySearch()
        {
            var t = new InventoryManager();
            Random rnd = new Random();
            var id = rnd.Next();
            t.Add(new ItemModel
            {
                Name = "Apple",
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                Quantity = 64,
                Id = id
            });

            var y = t.Search("Apple");

            if (y.Any(c => c.Id.ToString() == id.ToString()))
                Console.WriteLine("VerifySearch() - OK");
            else
                Console.WriteLine("VerifySearch() - Failed");
        }

        public void VerifyReStock()
        {
            var t = new InventoryManager();
            Random rnd = new Random();
            var id = rnd.Next();
            t.Add(new ItemModel
            {
                Name = "Apple",
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                Quantity = 64,
                Id = id
            });

            t.ReStock(100, id);

            if (t.GetInventoryList()[0].Quantity == 164)
                Console.WriteLine("VerifyReStock() - OK");
            else
                Console.WriteLine("VerifyReStock() - Failed");
        }

        public void VerifyDisplay()
        {
            var t = new InventoryManager();
            Random rnd = new Random();
            var id = rnd.Next();
            t.Add(new ItemModel
            {
                Name = "Apple",
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                Quantity = 64,
                Id = id
            });

            try
            {
                t.Display();
                Console.WriteLine("VerifyDisplay() - OK");
            }
            catch (Exception)
            {
                Console.WriteLine("VerifyDisplay() - Failed");
            }
        }

        public void VerifyRemoveItem()
        {
            var t = new InventoryManager();
            Random rnd = new Random();
            var id = rnd.Next();
            t.Add(new ItemModel
            {
                Name = "Apple",
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                Quantity = 64,
                Id = id
            });

            t.Remove(id);

            if (t.GetInventoryCount() == 0)
                Console.WriteLine("VerifyRemoveItem() - OK");
            else
                Console.WriteLine("VerifyRemoveItem() - Failed");
        }

        public void VerifyAddItem()
        {
            var t = new InventoryManager();
            Random rnd = new Random();   
            t.Add(new ItemModel
            {
                Name = "Apple",
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                Quantity = 64,
                Id = rnd.Next()
            }); 

            if(t.GetInventoryCount() == 1)
            {
                Console.WriteLine("VerifyAddItem() - OK");
                return;
            }

            Console.WriteLine("VerifyAddItem() - Failed");
        }
    }
}
