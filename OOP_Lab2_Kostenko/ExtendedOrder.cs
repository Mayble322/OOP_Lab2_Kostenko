using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2_Kostenko
{
    class ExtendedOrder: Order, IExtendedIngrediantable
    {
        public bool GetRequiresThermic()
        {
            return dishes.Select(x =>
            {
                if (x is ExtendedDish extendedDish)
                {
                    return extendedDish.GetRequiresThermic();
                }
                return false;

            }).Contains(true);
        }
        public double GetMaxTime(bool increasedTime)
        {
            if (increasedTime)
            {
               return dishes.Max(x => 
               {
                   if(x is ExtendedDish extendedDish)
                   {
                       return extendedDish.GetTime() * extendedDish.GetThermicMultiplier();
                   }
                   return x.GetTime();
               });
            }
            return base.GetMaxTime();
        }
    }
}
