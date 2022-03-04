using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace OOP_Lab2_Kostenko
{
    [DataContract]
    [Serializable]
    public class Dish : IIngredientable, IComparable<Dish>
    {
        Dictionary<Products, int> ingredients = new Dictionary<Products, int>();
        [DataMember]
        public string dish_name;
        [DataMember]
        public double time_for_cooking;

        public Dish()
        {

        }

        public Dish(string dish_name, double time_for_cooking)
        {
            this.dish_name = dish_name;
            this.time_for_cooking = time_for_cooking;
        }

        public void AddIngredient(Products ingredient, int quantity)
        {
            if (!ingredients.ContainsKey(ingredient))
            {
                ingredients.Add(ingredient, quantity);
            }
        }

        public int GetIngredientQuantity(Products ingredient)
        {
            if (!ingredients.ContainsKey(ingredient))
            {
                return 0;
            }
            else
            {
                return ingredients[ingredient];
            }
        }

        public double GetTime()
        {
            return time_for_cooking;
        }

        public int CompareTo(Dish obj)
        {
            if (this.time_for_cooking > obj.time_for_cooking)
                return 1;
            if (this.time_for_cooking < obj.time_for_cooking)
                return -1;
            else
                return 0;
        }

       

            public override string ToString()
            {
                string res = dish_name + "(";
                bool is_first_comma = true;
                foreach (Products i in Enum.GetValues(typeof(Products)))
                {
                    if (GetIngredientQuantity(i) > 0)
                    {
                        if (is_first_comma)
                        {
                            res += i;
                            is_first_comma = false;
                        }
                        else
                        {
                            res += ", " + i;
                        }
                    }

                }
                res += ")";

                return res;
            }
        class IComparables : IComparable<IComparables>
        {
            public string DISH_NAME { set; get; }
            public double TIME_FOR_COOKING { get; set; }
            public IComparables() { }
            public IComparables(string dish_name, double time_for_cookind)
            {
                this.DISH_NAME = DISH_NAME;
                this.TIME_FOR_COOKING = TIME_FOR_COOKING;
            }
            public int CompareTo(IComparables obj)
            {
                if (this.TIME_FOR_COOKING > obj.TIME_FOR_COOKING)
                    return 1;
                if (this.TIME_FOR_COOKING < obj.TIME_FOR_COOKING)
                    return -1;
                else
                    return 0;
            }
        }
        }
    }


