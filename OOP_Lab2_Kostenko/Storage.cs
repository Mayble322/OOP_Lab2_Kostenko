using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2_Kostenko
{
    class Storage
    {
        Dictionary<Products, int> ingredients = new Dictionary<Products, int>();

        public void AddIngredient(Products ingredient, int quantity)
        {
            if (!ingredients.ContainsKey(ingredient))
            {
                ingredients.Add(ingredient, quantity);
            }
            else
            {
                ingredients[ingredient] += quantity;
            }
        }

        public virtual bool Is_Avalable_To_Cook(IIngredientable order)
        {
            foreach(Products i in Enum.GetValues(typeof(Products)))
            {
                if (!ingredients.ContainsKey(i))
                {
                    if (order.GetIngredientQuantity(i) > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (order.GetIngredientQuantity(i) > ingredients[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Reduce_Ingredients(IIngredientable order)
        {
            if (Is_Avalable_To_Cook(order))
            {
                foreach(Products i in Enum.GetValues(typeof(Products)))
                {
                    if(order.GetIngredientQuantity(i) > 0)
                    {
                        ingredients[i] -= order.GetIngredientQuantity(i);
                    }
                }
            }
        }
    }
}
