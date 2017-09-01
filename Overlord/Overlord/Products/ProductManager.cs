using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Overlord
{
    public static class ProductManager
    {
        public static List<Product> AvailableProducts = new List<Product>();

        public static List<string> ListAllProducts()
        {
            AvailableProducts.Clear();
            List<string> productList = new List<string>();
            DirectoryInfo d = new DirectoryInfo(@GlobalVars.ProductPath);
            foreach (var file in d.GetFiles("*.xml"))
            {
                Product productToAdd = Program.xmlmanager.DeserializeProductData(file.Name.Substring(0, file.Name.Length - 4));
                if (productToAdd != null)
                {
                    AvailableProducts.Add(productToAdd);
                    productList.Add(file.Name);
                }
            }
            return productList;
        }

        public static Product GetSelectedProductByName(string name)
        {
            Product productToAdd = ProductManager.AvailableProducts.Find(x => x.name == name);
            if (productToAdd != null)
                return productToAdd;
            else
                return null;
        }

        public static bool IsUnique(string name)
        {
            foreach (var product in ListAllProducts())
            {
                if (name + ".xml" == product)
                    return false;
            }
            return true;
        }

        public static void UpdateAvailableProducts()
        {
            ListAllProducts();
        }

        public static void UpdateStock(Product product)
        {

            Product productToUpdate = AvailableProducts.Find(x => x.name == product.name);
            if (productToUpdate != null)
            {
                if (productToUpdate.notifyWhenLow && productToUpdate.stock == 0)
                    TelegramManager.SendMessageToChat(productToUpdate.name + " - продукт закончился");
                Program.xmlmanager.SerializeProductData(productToUpdate, product.name);
            }


        }

        public static void EditProductStock(Product product, int amount)
        {
            Product productToUpdate = AvailableProducts.Find(x => x.name == product.name);
            if (productToUpdate != null)
            {
                productToUpdate.stock = productToUpdate.stock + amount;
                Program.xmlmanager.SerializeProductData(productToUpdate, product.name);
            }
        }
    }
}
