using System;
using System.Collections.Generic;

namespace Lab3_3MenuClassBased
{
    class MenuItem
    {
        public string name; 
        public int quantity;
        public decimal price;


    }
    class Program
    {


        
        static bool KeepGoing()
        {

            while (true)
            {

                Console.WriteLine("Would you like make a further change to the menu?");

                string response = Console.ReadLine();
                response = response.ToLower();
                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }
            }
        }
       
        static void Main(string[] args)
        {
            Dictionary<string, MenuItem> MenuItems = new Dictionary<string, MenuItem>();

            MenuItem item1 = new MenuItem();
            item1.name = "Reuben";
            item1.quantity = 100;
            item1.price = 12.95m;
            MenuItems["Reuben"] = item1;

            MenuItem item2 = new MenuItem();
            item2.name = "Lobster";
            item2.quantity = 15;
            item2.price = 27.95m;
            MenuItems["Lobster"] = item2;

            MenuItem item3 = new MenuItem();
            item3.name = "Orange Julius";
            item3.quantity = 50;
            item3.price = 3.95m;
            MenuItems["Orange Julius"] = item3;

            MenuItem item4 = new MenuItem();
            item4.name = "Creme Brulee";
            item4.quantity = 30;
            item4.price = 6.95m;
            MenuItems["Creme Brulee"] = item4;



            Console.WriteLine("Here is the menu and prices!");
            Console.WriteLine("");
            foreach (var next in MenuItems)
            {
                Console.WriteLine($"Food name:{next.Value.name}\tPrice: ${next.Value.price}\tQuantity:{next.Value.quantity}");
            }
            Console.WriteLine("");
            Console.WriteLine("You have the option to update the menu!  You can add remove and even change the price of items! Please let me know what you want to do!");
            do
            {
                Console.Write("Please press A to add an item, R to remove an item, C to change and item, S to sell an item or Q to quit: ");
                bool categoryOK = false;
                while (categoryOK == false)
                {


                    string choice = Console.ReadLine();

                    if (choice.ToLower() == "a")
                    {
                        Console.Write("Which item would you like to add? ");
                        string food = Console.ReadLine();
                        categoryOK = true;
                        if (MenuItems.ContainsKey(food))
                        {
                            Console.WriteLine("That item already exists! Please enter a different item.");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.Write("What is this items price? ");
                            string price = Console.ReadLine();
                            decimal.TryParse(price, out decimal result);
                            Console.WriteLine($"How many of the {food} are you adding to inventory? ");
                            string quant = Console.ReadLine();
                            int.TryParse(quant, out int result2);
                            Console.WriteLine("");
                            MenuItem tempItem = new MenuItem();
                            tempItem.name = food;
                            tempItem.price = result;
                            tempItem.quantity = result2;
                            MenuItems[food] = tempItem;

                        }


                    }
                    else if (choice.ToLower() == "r")
                    {

                        Console.WriteLine("Which item would you like to remove?");
                        Console.Write("Please enter the name of the item. ");
                        string eightysix = Console.ReadLine();
                        MenuItems.Remove(eightysix);
                        Console.WriteLine($"{eightysix} has been removed from the menu!");
                        Console.WriteLine();
                        categoryOK = true;
                    }
                    else if (choice.ToLower() == "c")
                    {
                        categoryOK = true;
                        Console.Write("Which item would you like to change the price of? ");
                        string food = Console.ReadLine();
                        Console.Write("What is this items new price?");
                        string price = Console.ReadLine();
                        decimal.TryParse(price, out decimal result);
                        MenuItems[food].price = result;
                    }
                    else if (choice.ToLower() == "cq")
                    {
                        categoryOK = true;
                        Console.Write("Which item would you like to change the quantity of? ");
                        string food = Console.ReadLine();
                        Console.Write("What is this items new quantity?");
                        string quantity = Console.ReadLine();
                        int.TryParse(quantity, out int result);
                        MenuItems[food].quantity = result;
                    }
                    else if (choice.ToLower() == "s")
                    {
                        categoryOK = true;
                        Console.Write("Which item would you like sell? ");
                        string food = Console.ReadLine();
                        Console.Write("How many are you selling?");
                        string total = Console.ReadLine();
                        int.TryParse(total, out int result);
                        int final = MenuItems[food].quantity-result;
                        MenuItems[food].quantity = final;

                    }
                    else if (choice.ToLower() == "q")
                    {
                        categoryOK = true;
                        Console.WriteLine("Thank you for viewing the menu!");
                    }
                    else
                    {
                        categoryOK = false;
                        Console.WriteLine("Please press A to add an item, R to remove an item, C to change and item or Q to quit:");
                    }


                }
                Console.WriteLine("");
                Console.WriteLine("Here is the updated menu and prices!");
                Console.WriteLine("**********************");
                foreach (var next in MenuItems)
                {
                    Console.WriteLine($"Food name:{next.Value.name}\tPrice: ${next.Value.price}\tQuantity:{next.Value.quantity}");
                    Console.WriteLine();
                }
                Console.WriteLine("**********************");
                Console.WriteLine("");
                }
                while (KeepGoing());

            
            }
    }
}

