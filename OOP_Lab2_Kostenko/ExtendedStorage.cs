using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2_Kostenko
{
    class ExtendedStorage : Storage
    {
        double currentTime;
        double shutDownTime;
        double readyTime;

        public bool IsHeated()
        {
            return currentTime > readyTime;
        }

        public override bool Is_Avalable_To_Cook(IIngredientable order)
        {
            if (order is IExtendedIngrediantable extendedOrder)
            {

                if (currentTime > shutDownTime && extendedOrder.GetRequiresThermic())
                {
                    return false;
                }

            }
            return base.Is_Avalable_To_Cook(order); 
        }
        public void SetTime(double currentTime, double shutDownTime, double readyTime)
        {
            this.currentTime = currentTime;
            this.shutDownTime = shutDownTime;
            this.readyTime = readyTime;
        }
    }
}
