using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2_Kostenko
{
    class ExtendedMenu : Menu
    {
        public ExtendedMenu(Storage storage) : base(storage)
        {
            
        }
        protected override double GetOrderTime(Order order)
        {
            if (!storage.Is_Avalable_To_Cook(order))
            {
                return -1;
            }
            else
            {
                storage.Reduce_Ingredients(order);
                if(storage is ExtendedStorage extendedStorage && order is ExtendedOrder extendedOrder)
                {
                    return extendedOrder.GetMaxTime(!extendedStorage.IsHeated());
                }
                return order.GetMaxTime();
            }
            
        }
        public override void ReadOrder()
        {
            Console.WriteLine("Input your order: ");
            string order_string = Console.ReadLine();
            string[] dish_strings = order_string.Split(',');
            ExtendedOrder order = new ExtendedOrder();
            List<Dish> menu = GetAvalableDishes();
            foreach (string dish_string in dish_strings)
            {
                int menu_number = int.Parse(dish_string);

                order.AddDish(menu[menu_number - 1]);
            }
            double res = GetOrderTime(order);
            if (res == -1)
            {
                Console.WriteLine("Not enough ingridients for this order");
            }
            else
            {
                Console.WriteLine("your order will be ready in " + res + " minutes");
            }
        }
    }    
}
