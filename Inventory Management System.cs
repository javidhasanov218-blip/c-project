namespace Inventory_management_system
{
    

        class Product
        {

            public string Name { get; set; }
            public double Price { get; set; }
            public int StockQuantity { get; set; }

            public Product(string name, double price, int stockQuantity)
            {
                Name = name;
                Price = price;
                StockQuantity = stockQuantity;
            }


        }

        class Inventory
        {
            static List<Product> products = new List<Product>();


            static void Main()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("\n ==  Inventory Management  ==");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. View Product");
                    Console.WriteLine("3. Sell Product");
                    Console.WriteLine("4. Restore Product");
                    Console.WriteLine("5. Remove Product");
                    Console.WriteLine("6. Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddProduct();
                            break;

                        case 2:
                            ViewProduct();
                            break;

                        case 3:
                            SellProduct();
                            break;
                    case 4:
                            RestoreProduct();
                            break;

                    case 5:
                        RemoveProduct();
                        break;
 


                    }



                }



            }


            static void AddProduct()
            {

                Console.WriteLine("Enter product Name :");
                string name = Console.ReadLine();
                Console.WriteLine("Enter product price ");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter product quantity :");
                int quantity = Convert.ToInt32(Console.ReadLine());
                if (price <= 0 || quantity < 0)
                {
                    Console.WriteLine("Invalid Price or stock quantitiy");
                    return;
                }
                Product product = new Product(name, price, quantity);
                products.Add(product);
                Console.WriteLine("Product added succesfully.");

            }

            static void ViewProduct()
            {

                if (products.Count == 0)
                {
                    Console.WriteLine("No product in inventory");
                }

                Console.WriteLine("\n  Inventory ");
                foreach (Product product in products)
                {

                    Console.WriteLine(

                     $"Name{product.Name} |" +
                     $"Price{product.Price} |" +
                     $"Quantity{product.StockQuantity}");


                }


            }


            static void SellProduct()
            {
                Console.WriteLine("Enter product name ");
                string productname = Console.ReadLine();
                Product product = FindProduct(productname);
                
                Console.WriteLine("Enter product quantity");
                int productquantity = Convert.ToInt32(Console.ReadLine());
                if (productquantity <= 0)
                {
                    Console.WriteLine("Invalid quantity");
                    return;

                }

                else if (productquantity > product.StockQuantity)
                {

                    Console.WriteLine("Not enough product");

                }

                else
                {


                    product.StockQuantity -= productquantity;
                    Console.WriteLine("Product sold succesfully");


                }




            }
              static Product FindProduct(string productName)
        {
                 foreach (Product product in products)
            {
                   if (product.Name.ToLower() == productName.ToLower())
                   {
                    return product;
                   }
            }

            return null; 
        }

            static void RestoreProduct() {
   
                 Console.WriteLine("Enter product name to restore");
                string productname = Console.ReadLine();
                 Product product = FindProduct(productname);
                
                  


                 if (productname == null)
               {
                Console.WriteLine("Product not found");

                return;

                   }

            Console.WriteLine("Enter quantity to add:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            product.StockQuantity += quantity;
            Console.WriteLine("Stock restored successfully");



             }

           static void RemoveProduct() { 
        
            Console.Write("Enter product name to remove: ");
            string productName = Console.ReadLine();
           

            Product product = FindProduct(productName);

           
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            Console.WriteLine("Enter quantity to remove");
            int quantity = Convert.ToInt32(Console.ReadLine());




            product.StockQuantity -= quantity ;

            Console.WriteLine("Product removed successfully.");
        }

    }


    


}
