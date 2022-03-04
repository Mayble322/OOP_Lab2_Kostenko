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
    class ExtendedDish : Dish, IExtendedIngrediantable
    {
        [DataMember]
        bool requiresThermic = false;
        [DataMember]
        double thermicmultiplier = 1;
        
        public ExtendedDish(string dish_name, double  time_for_cooking, bool requiresThermic = false, double thermicmultiplier = 1): base(dish_name, time_for_cooking)
        {
            this.requiresThermic = requiresThermic;
            this.thermicmultiplier = thermicmultiplier;

        }
        
        public bool GetRequiresThermic()
        {
            return requiresThermic;
        }
        public double GetThermicMultiplier()
        {
            return thermicmultiplier;
        }
    }
}
