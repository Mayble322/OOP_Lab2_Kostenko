using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace OOP_Lab2_Kostenko
{
    class Program
    {
        static Menu menu;
        public  void  CreateRestaurant()
        {
            Dish pizza = new Dish("Pizza", 7);
            pizza.AddIngredient(Products.Tomato, 10);
            pizza.AddIngredient(Products.Sauce, 5);
            pizza.AddIngredient(Products.Flour, 20);
            pizza.AddIngredient(Products.Meat, 10);

            Dish sushi = new Dish("Sushi", 30);
            sushi.AddIngredient(Products.Rice, 5);
            sushi.AddIngredient(Products.Fish, 5);

            Dish french_fries = new Dish("French fries", 10);
            french_fries.AddIngredient(Products.Potato, 30);
            french_fries.AddIngredient(Products.Sauce, 5);

            Storage storage = new Storage();
            menu = new Menu( storage);

            menu.AddDish(pizza);
            menu.AddDish(sushi);
            menu.AddDish(french_fries);

            storage.AddIngredient(Products.Carrot, 0);
            storage.AddIngredient(Products.Cucucmber, 0);
            storage.AddIngredient(Products.Fish, 5);
            storage.AddIngredient(Products.Flour, 200);
            storage.AddIngredient(Products.Meat, 100);
            storage.AddIngredient(Products.Potato, 300);
            storage.AddIngredient(Products.Rice, 50);
            storage.AddIngredient(Products.Sauce, 20);
            storage.AddIngredient(Products.Tomato, 100);

           

        }

        static void Serve()
        {
            FileStrm f = new FileStrm();
            f.WriteFile(menu);
            string filetext = f.Read_file();
            Console.WriteLine(filetext);
            menu.ReadOrder();
        }
        static ExtendedMenu eMenu;
        static void ECreateRestaurant(double currentTime, double shutDownTime , double readyTime)
        {
            ExtendedDish pizza = new ExtendedDish("Pizza", 7, true, 1.7);
            pizza.AddIngredient(Products.Tomato, 10);
            pizza.AddIngredient(Products.Sauce, 5);
            pizza.AddIngredient(Products.Flour, 20);
            pizza.AddIngredient(Products.Meat, 10);

            ExtendedDish sushi = new ExtendedDish("Sushi", 30, false, 1);
            sushi.AddIngredient(Products.Rice, 5);
            sushi.AddIngredient(Products.Fish, 5);

            ExtendedDish french_fries = new ExtendedDish("French fries", 10, true, 1.5);
            french_fries.AddIngredient(Products.Potato, 30);
            french_fries.AddIngredient(Products.Sauce, 5);

            ExtendedStorage storage = new ExtendedStorage();
            eMenu = new ExtendedMenu(storage);

            eMenu.AddDish(pizza);
            eMenu.AddDish(sushi);
            eMenu.AddDish(french_fries);

            storage.AddIngredient(Products.Carrot, 0);
            storage.AddIngredient(Products.Cucucmber, 0);
            storage.AddIngredient(Products.Fish, 5);
            storage.AddIngredient(Products.Flour, 200);
            storage.AddIngredient(Products.Meat, 100);
            storage.AddIngredient(Products.Potato, 300);
            storage.AddIngredient(Products.Rice, 50);
            storage.AddIngredient(Products.Sauce, 20);
            storage.AddIngredient(Products.Tomato, 100);
            storage.SetTime( currentTime, shutDownTime ,  readyTime);

            ExtendedDish[] dishes = new ExtendedDish[] { pizza, sushi, french_fries };

            JsonSerialization js = new JsonSerialization();

            js.SerializeToJson(dishes, "Laba7");
            Console.WriteLine(js.DeserializeFromJson("Laba7"));

            Dish dish1 = new Dish("Pizza", 7);
            File.Delete("dish.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(Dish));
            using (FileStream fs = new FileStream("dish.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, dish1);
            }

            using (FileStream fs = new FileStream("dish.xml", FileMode.OpenOrCreate))
            {
                Dish newDish = (Dish)formatter.Deserialize(fs);
                Console.WriteLine($"Название блюда: {newDish.dish_name} --- Время Приготовления: {newDish.time_for_cooking}");
            }
        }
        public static void EServe()
        {
            FileStrm f = new FileStrm();
            f.WriteFile(eMenu);
            string filetext = f.Read_file();
            Console.WriteLine(filetext);
            eMenu.ReadOrder();

        }


        static void Main(string[] args)
        {
            //CreateRestaurant();
            //File.WriteAllText(@"C:\LabaOOP\Lab3.txt", string.Empty);
            //while (true)
            //{
            //    Serve();
            //    File.WriteAllText(@"C:\LabaOOP\Lab3.txt", string.Empty);
            //}
            ECreateRestaurant(9,22,10);
            File.WriteAllText(@"C:\LabaOOP\Lab3.txt", string.Empty);
            while (true)
            {
                EServe();
                File.WriteAllText(@"C:\LabaOOP\Lab3.txt", string.Empty);
            }
        }
    }
}
