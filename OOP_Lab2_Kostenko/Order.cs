using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2_Kostenko
{
    class Order : IIngredientable
    {
        protected List<Dish> dishes = new List<Dish>();

        public int GetIngredientQuantity(Products ingredient)
        {
           return dishes.Sum(x => x.GetIngredientQuantity(ingredient));
        }

        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }

        public double GetMaxTime()
        {
            return dishes.Max(x => x.GetTime());
        }
    }
}
