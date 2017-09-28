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
        private static List<Product> AvailableProducts = new List<Product>();

        public delegate void MessageDelegate(string message);
        public static event MessageDelegate OnMessage;

        public static void Initialize()
        {
            UpdateProductList();
        }

        public static List<Product> GetProductList()
        {
            return AvailableProducts;
        }

        public static List<string> GetProductNameList()
        {
            List<string> ProductNameList = new List<string>();
            foreach (Product product in GetProductList())
            {
                if (product.name != null && product.name != "")
                {
                    ProductNameList.Add(product.name);
                }
            }
            return ProductNameList;
        }

        public static void UpdateProductList()
        {
            AvailableProducts.Clear();
            DirectoryInfo d = new DirectoryInfo(@GlobalVars.ProductPath);
            foreach (var file in d.GetFiles("*.xml"))
            {
                Product productToAdd = XMLManager.DeserializeProductData(file.Name.Substring(0, file.Name.Length - 4));
                if (productToAdd != null)
                {
                    AvailableProducts.Add(productToAdd);
                }
            }
        }

        public static Product GetProductByName(string name)
        {
            Product productToAdd = AvailableProducts.Find(x => x.name == name);
            DebugManager.AddLine(productToAdd.ToString());
            if (productToAdd != null)
                return productToAdd;
            else
                return null;
        }

        public static Tuple<bool, string> DeleteProduct(string product)
        {
           
            if (XMLManager.DeserializeProductData(product).stock != 0)
            {   
                return Tuple.Create(false, "Cannot delete unempty stock");
            }
            if (!XMLManager.DeleteProductData(product))
            {
                return Tuple.Create(false, "Cannot delete this: " + product);
            }
            UpdateProductList();
            return Tuple.Create(true, product + " has been deleted");

        }

        public static bool IsUnique(string name)
        {
            foreach (var product in GetProductNameList())
            {
                if (name + ".xml" == product)
                    return false;
            }
            return true;

           
        }
        

        public static void UpdateStock(Product product)
        {

            Product productToUpdate = AvailableProducts.Find(x => x.name == product.name);
            if (productToUpdate != null)
            {
                if (productToUpdate.notifyWhenLow && productToUpdate.stock == 0)
                     OnMessage?.Invoke(productToUpdate.name + " - продукт закончился");
                XMLManager.SerializeProductData(productToUpdate, product.name);
            }


        }

        public static void EditProductStock(Product product, int amount)
        {
            Product productToUpdate = AvailableProducts.Find(x => x.name == product.name);
            if (productToUpdate != null)
            {
                productToUpdate.stock = productToUpdate.stock + amount;
                XMLManager.SerializeProductData(productToUpdate, product.name);
            }
        }
    }
}
