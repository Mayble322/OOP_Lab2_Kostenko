using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2_Kostenko
{
    interface IExtendedIngrediantable : IIngredientable
    {
        bool GetRequiresThermic();
    }
}
