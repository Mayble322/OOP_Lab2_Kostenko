using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Lab2_Kostenko
{
    class Menu
    {
        List<Dish> list_of_dishes = new List<Dish>();
        protected Storage storage;

        public Menu(Storage storage)
        {
            this.storage = storage;
        }

        public void AddDish(Dish dish)
        {
            list_of_dishes.Add(dish);
        }

        public  List<Dish> GetAvalableDishes()
        {
           return list_of_dishes.Where(storage.Is_Avalable_To_Cook).ToList();
        }

        public void PrintAvalableDishes()
        {
            int id = 1;
            foreach(Dish dish in GetAvalableDishes())
            {
                Console.WriteLine(id++ + ": " + dish.ToString());
                Console.WriteLine("Time: " + dish.GetTime());
                
            }
        }

        public virtual void ReadOrder()
        {
            Console.WriteLine("Input your order: ");
            string order_string = Console.ReadLine();
            string[] dish_strings =  order_string.Split(',');
            Order order = new Order();
            List<Dish> menu = GetAvalableDishes();
            foreach(string dish_string in dish_strings)
            {
                int menu_number = int.Parse(dish_string);

                order.AddDish(menu[menu_number - 1]);
            }
            double res = GetOrderTime(order);  
            if(res == -1)
            {
                Console.WriteLine("Not enough ingridients for this order");
            }
            else
            {
                Console.WriteLine("your order will be ready in " + res + " minutes");
            }
        }
       protected virtual double  GetOrderTime(Order order)
        {
            if (!storage.Is_Avalable_To_Cook(order))
            {
                return -1; 
            }
            else
            {
                storage.Reduce_Ingredients(order);
                return order.GetMaxTime();
            }
        }

       
    }
}
